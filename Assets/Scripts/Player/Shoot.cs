using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using Int32 = System.Int32;

public class Shoot : MonoBehaviour
{
    private WeaponSelect _weaponSelect;

    private Ammo _ammo;

    public RaycastShooter _raycastShooter;

    private bool isShooting = false;

    private float shotDelay = 0.05f;

    private const int MAX_MAGAZINE_SIZE = 30;

    private bool isReloading = false;

    private float reloadTime = 1f;

    public int bulletsInMagazine = 0;

    void Start()
    {
        _weaponSelect = GetComponent<WeaponSelect>();
        _raycastShooter = GetComponent<RaycastShooter>();
        _ammo = GetComponent<Ammo>();
    }

    private IEnumerator AutoShoot()
    {
        isShooting = true;
        bool wasShootingBeforeReload = false; // Flag to track if shooting was active before reload

        while (isShooting &&
            _ammo.magazineSizes[_weaponSelect.currentWeaponIndex] > 0
        )
        {
            _ammo.magazineSizes[_weaponSelect.currentWeaponIndex]--;
            _raycastShooter.HandleRayCast();

            if (_ammo.magazineSizes[_weaponSelect.currentWeaponIndex] == 0)
            {
                // If the magazine is empty, wait for reloading to finish
                wasShootingBeforeReload = true;
                yield return StartCoroutine(ReloadCoroutine(() =>
                    {
                        // Reload completed callback
                    }));
            }

            yield return new WaitForSeconds(shotDelay);
        }

        // Resume shooting if the player was holding down the mouse button during reload
        if (wasShootingBeforeReload && isShooting)
        {
            StartCoroutine(AutoShoot());
        }
    }

    public void HandleShooting()
    {
        bool isAuto =
            _weaponSelect.currentWeaponIndex == 2 ||
            _weaponSelect.currentWeaponIndex == 4;

        int magazineSize =
            _ammo.magazineSizes[_weaponSelect.currentWeaponIndex];

        if (_ammo.magazineSizes.ContainsKey(_weaponSelect.currentWeaponIndex))
        {
            if (magazineSize > 0)
            {
                isReloading = false;
                if (isAuto && Input.GetMouseButton(0))
                {
                    if (!isShooting)
                    {
                        StartCoroutine(AutoShoot());
                    }
                }
                else if (!isAuto && Input.GetMouseButtonDown(0))
                {
                    // detuct ammo from the magazine when shooting
                    _ammo.magazineSizes[_weaponSelect.currentWeaponIndex]--;
                    _raycastShooter.HandleRayCast();
                }
            }
            else
            {
                ReloadWeapon(_weaponSelect.currentWeaponIndex);
            }
        }

        if (!Input.GetMouseButton(0))
        {
            isShooting = false;
        }
    }

    private void ReloadWeapon(int currentWeaponIndex)
    {
        Debug.Log("Reloading weapon");

        if (isReloading)
        {
            return;
        }

        isReloading = true;

        Debug.Log("isReloading" + isReloading);

        StartCoroutine(ReloadCoroutine(() =>
        {
            int magazineSize = _ammo.magazineSizes[currentWeaponIndex];
            int bulletsInMagazine = magazineSize;
            int bulletsToReload =
                Mathf.Max(0, MAX_MAGAZINE_SIZE - bulletsInMagazine);

            // calc available ammo for reloading from current reserve
            int availableAmmo = _ammo.reserveAmmo[currentWeaponIndex];
            Debug.Log("Available ammo: " + availableAmmo);
            bulletsToReload = Mathf.Min(bulletsToReload, availableAmmo);

            // deductt bullets from reserve and add to the magazine
            if (bulletsToReload > 0)
            {
                _ammo.magazineSizes[currentWeaponIndex] += bulletsToReload;
                _ammo.reserveAmmo[currentWeaponIndex] -= bulletsToReload;
            }
        }));
    }

    private IEnumerator ReloadCoroutine(Action onComplete)
    {
        yield return new WaitForSeconds(reloadTime);

        onComplete?.Invoke();

        isReloading = false;
    }
}

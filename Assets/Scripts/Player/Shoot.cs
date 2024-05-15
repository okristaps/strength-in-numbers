using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private WeaponSelect _weaponSelect;

    public RaycastShooter _raycastShooter;

    [SerializeField]
    public TextMeshProUGUI bulletsInMagazineText;

    int bulletsInMagazine = 0;

    private bool isShooting = false;

    private float shotDelay = 0.05f;

    private const int MAX_MAGAZINE_SIZE = 30;

    private Dictionary<int, int> magazineSizes = new Dictionary<int, int>();

    private Dictionary<int, int> reserveAmmo = new Dictionary<int, int>();

    void Start()
    {
        _weaponSelect = GetComponent<WeaponSelect>();
        _raycastShooter = GetComponent<RaycastShooter>();

        magazineSizes.Add(0, 10);
        reserveAmmo.Add(0, 100);

        magazineSizes.Add(1, 6);
        reserveAmmo.Add(1, 50);
    }

    private void Update()
    {
        bulletsInMagazine = magazineSizes[_weaponSelect.currentWeaponIndex];
        bulletsInMagazineText.text = bulletsInMagazine.ToString();
        HandleShooting();
    }

    private IEnumerator AutoShoot()
    {
        isShooting = true;
        while (isShooting)
        {
            _raycastShooter.HandleRayCast();
            yield return new WaitForSeconds(shotDelay);
        }
    }

    public void HandleShooting()
    {
        bool isAuto =
            _weaponSelect.currentWeaponIndex == 2 ||
            _weaponSelect.currentWeaponIndex == 4;

        if (
            magazineSizes.ContainsKey(_weaponSelect.currentWeaponIndex) &&
            magazineSizes[_weaponSelect.currentWeaponIndex] > 0
        )
        {
            Debug
                .Log("Bullets in magazine: " +
                magazineSizes[_weaponSelect.currentWeaponIndex]);

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
                magazineSizes[_weaponSelect.currentWeaponIndex]--;
                _raycastShooter.HandleRayCast();
            }
        }
        else
        {
            ReloadWeapon();
        }

        if (!Input.GetMouseButton(0))
        {
            isShooting = false;
        }
    }

    private void ReloadWeapon()
    {
        int currentWeaponIndex = _weaponSelect.currentWeaponIndex;

        // check if reserve ammo is available and the magazine is not full
        if (
            reserveAmmo.ContainsKey(currentWeaponIndex) &&
            reserveAmmo[currentWeaponIndex] > 0 &&
            magazineSizes.ContainsKey(currentWeaponIndex) &&
            magazineSizes[currentWeaponIndex] < MAX_MAGAZINE_SIZE
        )
        {
            int bulletsToReload =
                Mathf
                    .Min(MAX_MAGAZINE_SIZE - magazineSizes[currentWeaponIndex],
                    reserveAmmo[currentWeaponIndex]);

            // detuct bullets from reserve and add to the magazine
            reserveAmmo[currentWeaponIndex] -= bulletsToReload;
            magazineSizes[currentWeaponIndex] += bulletsToReload;
        }
    }
}

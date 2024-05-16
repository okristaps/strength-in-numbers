using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Shoot : MonoBehaviour {
	private WeaponSelect _weaponSelect;
	private Ammo _ammo;
	public RaycastShooter _raycastShooter;

	// shooting state
	private bool isShooting = false;
	private int cwIndex;


	void Start() {
		_weaponSelect = GetComponent<WeaponSelect>();
		_raycastShooter = GetComponent<RaycastShooter>();
		_ammo = GetComponent<Ammo>();

	}

	void Update() {
		cwIndex = _weaponSelect.currentWeaponIndex;
	}

	private IEnumerator AutoShoot() {
		isShooting = true;
		bool wasShootingBeforeReload = false;
		float timeBetweenShots = 60f / _ammo.fireRates[cwIndex];

		while (isShooting && _ammo.bulletsInMag[cwIndex] > 0) {
			HandleBulletShot();

			// apply bullet damage
			// applydmg(cwBulletDamage);

			if (_ammo.bulletsInMag[cwIndex] == 0) {
				// wait for reloading to finish when mag  empty
				wasShootingBeforeReload = true;
				yield return StartCoroutine(_ammo.ReloadCoroutine(() => {
					// empty reload callback
				}));
			}

			yield return new WaitForSeconds(timeBetweenShots);
		}

		// resume shooting if msbtndown on while reloading
		if (wasShootingBeforeReload && isShooting) {
			StartCoroutine(AutoShoot());
		}
	}
	public void HandleShooting() {
		bool isAuto = cwIndex == 2 || cwIndex == 4;
		int bulletsInMag = _ammo.bulletsInMag[cwIndex];

		if (_ammo.bulletsInMag.ContainsKey(cwIndex)) {
			if (bulletsInMag > 0) {
				_ammo.isReloading = false;
				if (isAuto && Input.GetMouseButton(0)) {
					if (!isShooting) {
						StartCoroutine(AutoShoot());
					}
				}
				else if (!isAuto && Input.GetMouseButtonDown(0)) {
					// detuct ammo from the magazine when shooting
					HandleBulletShot();
				}
			}
			else {
				_ammo.ReloadWeapon();
			}
		}

		if (!Input.GetMouseButton(0)) {
			isShooting = false;
		}
	}

	private void HandleBulletShot() {
		_ammo.DeductBullet();
		_raycastShooter.HandleRayCast();
	}
}

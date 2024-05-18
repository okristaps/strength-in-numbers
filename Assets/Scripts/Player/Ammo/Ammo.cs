using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Ammo : MonoBehaviour {
	private WeaponSelect _weaponSelect;

	private DisplayAmmo _displayAmmo;
	public int grenadeCount;


	// bullets in magazine
	public Dictionary<int, int> bulletsInMag = new Dictionary<int, int>
	{
		{ 0, 30 },
		{ 1, 6 },
		{ 2, 30 },
		{ 3, 6 },
		{ 4, 2000 }
	};


	// magazine size
	public Dictionary<int, int> magSizes = new Dictionary<int, int>
	{
		{ 0, 20 },
		{ 1, 6 },
		{ 2, 60 },
		{ 3, 6 },
		{ 4, 500 }
	};

	// ammo in reserve
	public Dictionary<int, int> reserveAmmo = new Dictionary<int, int>
	{
		{ 0, 100 },
		{ 1, 36 },
		{ 2, 60 },
		{ 3, 50 },
		{ 4, 5000 }
	};

	// 1 bullet damage points
	public Dictionary<int, int> weaponDamages = new Dictionary<int, int>
{
		{ 0, 34 },
		{ 1, 100 },
		{ 2, 34 },
		{ 3, 100 },
		{ 4, 30 }
	};


	// Bullets per minute
	public Dictionary<int, int> fireRates = new Dictionary<int, int>
{
		{ 0, 200 },
		{ 1, 100 },
		{ 2, 10000 },
		{ 3, 60 },
		{ 4, 10000 }
	};

	public Dictionary<int, float> reloadTimes = new Dictionary<int, float>
{
		{ 0, 5f },
		{ 1, 5f },
		{ 2, 6f },
		{ 3, 10f },
		{ 4, 7f }
	};


	public Dictionary<int, float> weaponRanges = new Dictionary<int, float>
{
		{ 0, 1f },
		{ 1, 2f },
		{ 2, 3f },
		{ 3, 4f },
		{ 4, 5f }
	};



	// weapon ammo handle stuff
	public bool isReloading = false;

	private int cwIndex;

	void Start() {
		_weaponSelect = GetComponent<WeaponSelect>();
		_displayAmmo = GetComponent<DisplayAmmo>();
	}

	void Update() {
		if (_weaponSelect == null) {
			return;
		}
		cwIndex = _weaponSelect.currentWeaponIndex;
		_displayAmmo.UpdateAmmoText();
	}


	public void ReloadWeapon() {

		if (isReloading) {
			return;
		}

		isReloading = true;

		StartCoroutine(
			ReloadCoroutine(() => {
				int magazineSize = magSizes[cwIndex];
				int cwBulletsInMagazine = bulletsInMag[cwIndex];
				int bulletsToReload = Mathf.Max(0, magazineSize - cwBulletsInMagazine);

				// calc available ammo for reloading from current reserve
				int availableAmmo = reserveAmmo[cwIndex];
				bulletsToReload = Mathf.Min(bulletsToReload, availableAmmo);

				// deductt bullets from reserve and add to the magazine
				if (bulletsToReload > 0) {
					reserveAmmo[cwIndex] -= bulletsToReload;
					bulletsInMag[cwIndex] += bulletsToReload;

				}
			})
		);
	}




	public IEnumerator ReloadCoroutine(Action onComplete) {
		yield return new WaitForSeconds(reloadTimes[cwIndex]);
		onComplete?.Invoke();
		isReloading = false;
	}


	public void DeductBullet() {
		bulletsInMag[cwIndex]--;
	}

}

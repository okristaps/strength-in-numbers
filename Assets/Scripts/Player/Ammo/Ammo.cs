using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ammo : MonoBehaviour {
	private WeaponSelect _weaponSelect;

	private DisplayAmmo _displayAmmo;

	public Dictionary<int, int> magazineSizes = new Dictionary<int, int>
	{
		{ 0, 30 },
		{ 1, 6 },
		{ 2, 6 },
		{ 3, 6 },
		{ 4, 2000 }
	};

	public Dictionary<int, int> reserveAmmo = new Dictionary<int, int>
	{
		{ 0, 100 },
		{ 1, 36 },
		{ 2, 50 },
		{ 3, 50 },
		{ 4, 50 }
	};

	// 1 bullet damage points
	public Dictionary<int, int> WeaponDamages = new Dictionary<int, int>
{
		{ 0, 25 },
		{ 1, 70 },
		{ 2, 25 },
		{ 3, 100 },
		{ 4, 25 }
	};


	// Bullets per minute
	public Dictionary<int, int> FireRate = new Dictionary<int, int>
{
		{ 0, 200 },
		{ 1, 100 },
		{ 2, 400 },
		{ 3, 60 },
		{ 4, 10000 }
	};

	public int currentBullets = 0;

	public int totalBulletsLeft = 0;

	void Start() {
		_weaponSelect = GetComponent<WeaponSelect>();
		_displayAmmo = GetComponent<DisplayAmmo>();
	}

	void Update() {
		if (_weaponSelect == null) {
			return;
		}

		currentBullets = GetCurrentBulletsInMagazine(_weaponSelect.currentWeaponIndex);
		totalBulletsLeft = GetTotalBulletsLeft(_weaponSelect.currentWeaponIndex);

		_displayAmmo.UpdateAmmoText();
	}

	public int GetCurrentBulletsInMagazine(int weaponIndex) {
		if (magazineSizes.ContainsKey(weaponIndex)) {
			return magazineSizes[weaponIndex];
		}
		else {
			return 0;
		}
	}

	public int GetTotalBulletsLeft(int weaponIndex) {
		int totalBulletsLeft = 0;

		if (reserveAmmo.ContainsKey(weaponIndex)) {
			totalBulletsLeft += reserveAmmo[weaponIndex];
		}

		if (magazineSizes.ContainsKey(weaponIndex)) {
			totalBulletsLeft += magazineSizes[weaponIndex];
		}

		return totalBulletsLeft;
	}
}

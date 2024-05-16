using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ammo : MonoBehaviour
{
	private WeaponSelect _weaponSelect;

	private DisplayAmmo _displayAmmo;

	public Dictionary<int, int> magazineSizes = new Dictionary<int, int>
	{
		{ 0, 30 },
		{ 1, 6 },
		{ 2, 6 },
		{ 3, 6 },
		{ 4, 6 }
	};

	public Dictionary<int, int> reserveAmmo = new Dictionary<int, int>
	{
		{ 0, 100 },
		{ 1, 36 },
		{ 2, 50 },
		{ 3, 50 },
		{ 4, 50 }
	};

	public int currentBullets = 0;

	public int totalBulletsLeft = 0;

	void Start()
	{
		_weaponSelect = GetComponent<WeaponSelect>();
		_displayAmmo = GetComponent<DisplayAmmo>();
	}

	void Update()
	{
		if (_weaponSelect == null)
		{
			return;
		}

		currentBullets = GetCurrentBulletsInMagazine(_weaponSelect.currentWeaponIndex);
		totalBulletsLeft = GetTotalBulletsLeft(_weaponSelect.currentWeaponIndex);

		_displayAmmo.UpdateAmmoText();
	}

	public int GetCurrentBulletsInMagazine(int weaponIndex)
	{
		if (magazineSizes.ContainsKey(weaponIndex))
		{
			return magazineSizes[weaponIndex];
		}
		else
		{
			return 0;
		}
	}

	public int GetTotalBulletsLeft(int weaponIndex)
	{
		int totalBulletsLeft = 0;

		if (reserveAmmo.ContainsKey(weaponIndex))
		{
			totalBulletsLeft += reserveAmmo[weaponIndex];
		}

		if (magazineSizes.ContainsKey(weaponIndex))
		{
			totalBulletsLeft += magazineSizes[weaponIndex];
		}

		return totalBulletsLeft;
	}
}

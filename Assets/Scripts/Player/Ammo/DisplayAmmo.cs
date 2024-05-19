using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayAmmo : MonoBehaviour {
	private Ammo _ammo;
	int ammoLeft = 0;

	int ammoInMagazine = 0;

	private WeaponSelect _weaponSelect;

	[SerializeField]
	TextMeshProUGUI ammoText;

	[SerializeField]
	TextMeshProUGUI hpText;


	void Start() {
		_ammo = GetComponent<Ammo>();
		_weaponSelect = GetComponent<WeaponSelect>();

	}

	private void Update() {
		if (_weaponSelect == null) {
			ammoLeft = 0;
			ammoInMagazine = 0;
			return;
		}
		// If doesnt work check if you have added ammo text from ammo canvas to the DisplayAmmo script	
		ammoLeft = _ammo.reserveAmmo[_weaponSelect.currentWeaponIndex];
		ammoInMagazine = _ammo.bulletsInMag[_weaponSelect.currentWeaponIndex];


	}

	public void UpdateAmmoText() {
		//ammoText.text = ammoInMagazine.ToString() + " / " + ammoLeft.ToString();

		//hpText.text = GetComponent<PlayerController>().health.ToString();
		
	}

}

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AmmoDisplay : MonoBehaviour {
	Slider slider;
	private Ammo _ammo;
	private WeaponSelect _weaponSelect;

	void Start() {
		_ammo = GameObject.FindGameObjectWithTag("Player").GetComponent<Ammo>();
		_weaponSelect = GameObject.FindGameObjectWithTag("Player").GetComponent <WeaponSelect>();
		slider = GetComponent<Slider>();
		slider.maxValue = _ammo.magSizes[_weaponSelect.currentWeaponIndex]; //magSize
	}


	void Update() {
		slider.value = _ammo.bulletsInMag[_weaponSelect.currentWeaponIndex]; //ammo left
		TextMeshProUGUI ammoText = GetComponentInChildren<TextMeshProUGUI>();
		slider.maxValue = _ammo.magSizes[_weaponSelect.currentWeaponIndex];
		ammoText.text = slider.value.ToString() + "/" + _ammo.reserveAmmo[_weaponSelect.currentWeaponIndex].ToString();
	}


}

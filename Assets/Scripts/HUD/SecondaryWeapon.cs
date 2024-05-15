using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SecondaryWeapon : MonoBehaviour {
	public Image EmptySprite;
	public Sprite[] Weapons;

	private int currentWeaponIndex = 0;
	private int previousWeaponIndex = 0;

	void Start() {
		GetComponent<Image>().overrideSprite =
			Weapons[previousWeaponIndex];
	}


	void Update() {
		for (int i = 0; i < Weapons.Length; i++) {
			if (Input.GetKeyDown(KeyCode.Alpha1 + i)) {
				ChangeWeapon(i);
				break;
			}
		}

		if (Input.GetKeyDown(KeyCode.Q)) {
			ChangeToPreviousWeapon();
		}

		float scroll = Input.GetAxis("Mouse ScrollWheel");
		if (scroll != 0) {
			if (scroll > 0) {
				ChangeWeapon(currentWeaponIndex + 1);
			}
			else {
				// Scroll down
				ChangeWeapon(currentWeaponIndex - 1);
			}
		}
	}
	void ChangeWeapon(int weaponIndex) {
		weaponIndex = Mathf.Clamp(weaponIndex, 0, Weapons.Length - 1);

		previousWeaponIndex = currentWeaponIndex;
		currentWeaponIndex = weaponIndex;
		GetComponent<Image>().overrideSprite =
			Weapons[previousWeaponIndex];
	}

	void ChangeToPreviousWeapon() {
		int temp = currentWeaponIndex;
		currentWeaponIndex = previousWeaponIndex;
		previousWeaponIndex = temp;

		GetComponent<Image>().overrideSprite =
			Weapons[previousWeaponIndex];
	}
}

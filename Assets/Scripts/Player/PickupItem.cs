using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupItem : MonoBehaviour {

	Ammo ammo;
	WeaponSelect ws;
	void Start() {
		ammo = GameObject.FindGameObjectWithTag("Player").GetComponent<Ammo>();
		ws = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponSelect>();
	}

	private void OnTriggerEnter2D(Collider2D other) {

		if (!other.CompareTag("Player")) return;

		Dictionary<int, int> reserveAmmo = ammo.reserveAmmo;
		Dictionary<int, int> magSizes = ammo.magSizes;

		switch (gameObject.tag) {
			case "Grenade":
				if (ammo.grenadeCount < 10)
					ammo.grenadeCount++;
				Destroy(gameObject);
				break;

			case "PistolAmmo":
				if (ws.currentWeaponIndex == 0 || ws.previousWeaponIndex == 0) {
					reserveAmmo[0] += 3 * magSizes[0];
					Destroy(gameObject);
				}
				break;

			case "ShotgunAmmo":
				if (ws.currentWeaponIndex == 1 || ws.previousWeaponIndex == 1) {
					reserveAmmo[1] += 3 * magSizes[1];
					Destroy(gameObject);
				}
				break;

			case "RifleAmmo":
				if (ws.currentWeaponIndex == 2 || ws.currentWeaponIndex == 3 || ws.currentWeaponIndex == 4) {
					reserveAmmo[ws.currentWeaponIndex] += 3 * magSizes[ws.currentWeaponIndex];
					Destroy(gameObject);
				}
				if (ws.previousWeaponIndex == 2 || ws.previousWeaponIndex == 3 || ws.previousWeaponIndex == 4) {
					reserveAmmo[ws.previousWeaponIndex] += 3 * magSizes[ws.previousWeaponIndex];
					Destroy(gameObject);
				}
				break;

		}

	}


}






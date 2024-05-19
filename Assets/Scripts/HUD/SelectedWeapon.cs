using UnityEngine;
using UnityEngine.UI;

public class SelectedWeapon : MonoBehaviour {
	public Sprite[] Weapons;
	WeaponSelect ws;

	void Start() {
		ws = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponSelect>();
		GetComponent<Image>().overrideSprite = Weapons[ws.currentWeaponIndex];
	}

	void Update() {
		GetComponent<Image>().overrideSprite = Weapons[ws.currentWeaponIndex];
	}
}

using UnityEngine;
using UnityEngine.UI;

public class SecondaryWeapon : MonoBehaviour
{
	public Sprite[] Weapons;
	WeaponSelect ws;

	void Start()
	{
		ws = GameObject.FindGameObjectWithTag("Player").GetComponent<WeaponSelect>();
		GetComponent<Image>().overrideSprite = Weapons[ws.previousWeaponIndex];	
	}

	void Update() {
		GetComponent<Image>().overrideSprite = Weapons[ws.previousWeaponIndex];
	}
}

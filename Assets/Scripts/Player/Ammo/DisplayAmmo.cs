using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayAmmo : MonoBehaviour
{
	private Ammo _ammo;

	int ammoLeft;

	int ammoInMagazine;

	[SerializeField]
	TextMeshProUGUI ammoText;

	void Start()
	{
		_ammo = GetComponent<Ammo>();
	}

	private void Update()
	{
		ammoLeft = _ammo.totalBulletsLeft;
		ammoInMagazine = _ammo.currentBullets;
	}

	public void UpdateAmmoText()
	{
		ammoText.text = ammoInMagazine.ToString() + " / " + (ammoLeft - ammoInMagazine).ToString();
	}
}

using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponSelect : MonoBehaviour {
	public Sprite[] weaponSprites;

	public int currentWeaponIndex = 0;

	public int previousWeaponIndex = 0;

	public void Start()
	{

	}

	private void Update()
	{
		for (int i = 0; i < weaponSprites.Length; i++)
		{
			if (Input.GetKeyDown(KeyCode.Alpha1 + i))
			{
				if (i != currentWeaponIndex) {
					ChangeWeapon(i);
					break;
				}			
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
				ChangeWeapon(currentWeaponIndex - 1);
			}
		}
	}

	void ChangeWeapon(int weaponIndex) {
		weaponIndex = Mathf.Clamp(weaponIndex, 0, weaponSprites.Length - 1);
		previousWeaponIndex = currentWeaponIndex;
		currentWeaponIndex = weaponIndex;
		GetComponent<SpriteRenderer>().sprite = weaponSprites[currentWeaponIndex];
	}

	void ChangeToPreviousWeapon()
	{	
		
			if (previousWeaponIndex >= 0) {

				int temp = currentWeaponIndex;
				currentWeaponIndex = previousWeaponIndex;
				previousWeaponIndex = temp;
				GetComponent<SpriteRenderer>().sprite = weaponSprites[currentWeaponIndex];
			} 		
		
	}
}

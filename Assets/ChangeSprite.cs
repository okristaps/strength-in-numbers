using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public Sprite[] weaponSprites;

    private int currentWeaponIndex = 0;

    void Start()
    {
        GetComponent<SpriteRenderer>().sprite =
            weaponSprites[currentWeaponIndex];
    }

    private void Update()
    {
        for (int i = 0; i < weaponSprites.Length; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                ChangeWeapon (i);
                break;
            }
        }
    }

    // Method to change weapon
    void ChangeWeapon(int weaponIndex)
    {
        if (weaponIndex >= 0 && weaponIndex < weaponSprites.Length)
        {
            GetComponent<SpriteRenderer>().sprite = weaponSprites[weaponIndex];
            currentWeaponIndex = weaponIndex; // Update current weapon index
        }
    }
}

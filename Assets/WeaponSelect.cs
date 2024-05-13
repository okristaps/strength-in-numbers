using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelect : MonoBehaviour
{
    public Sprite[] weaponSprites;

    private int currentWeaponIndex = 0;

    private int previousWeaponIndex = 0;

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

        if (Input.GetKeyDown(KeyCode.Q))
        {
            ChangeToPreviousWeapon();
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            if (scroll > 0)
            {
                ChangeWeapon(currentWeaponIndex + 1);
            }
            else
            {
                // Scroll down
                ChangeWeapon(currentWeaponIndex - 1);
            }
        }
    }

    void ChangeWeapon(int weaponIndex)
    {
        weaponIndex = Mathf.Clamp(weaponIndex, 0, weaponSprites.Length - 1);

        previousWeaponIndex = currentWeaponIndex;
        currentWeaponIndex = weaponIndex;
        GetComponent<SpriteRenderer>().sprite =
            weaponSprites[currentWeaponIndex];
    }

    void ChangeToPreviousWeapon()
    {
        int temp = currentWeaponIndex;
        currentWeaponIndex = previousWeaponIndex;
        previousWeaponIndex = temp;

        GetComponent<SpriteRenderer>().sprite =
            weaponSprites[currentWeaponIndex];
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseMenu : MonoBehaviour
{
    public GameObject vendingMachineMenu;

    public void CloseVendingMachine()
    {
        vendingMachineMenu.SetActive(false);
        Time.timeScale = 1;
    }
}

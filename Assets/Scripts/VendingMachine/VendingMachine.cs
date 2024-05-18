using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachine : MonoBehaviour
{
    public GameObject vendingMachineMenu;
    private bool isPlayerInRange = false;
    private float interactionRange = 1.5f;

    void Start()
    {
        vendingMachineMenu.SetActive(false);
    }

    void Update()
    {
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            OpenVendingMachine();
        }
    }

    void OpenVendingMachine()
    {
        vendingMachineMenu.SetActive(true);
        Time.timeScale = 0;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
        }
    }

    public void SetInteractionRange(float range)
    {
        interactionRange = range;
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_rune_puzzle_key : MonoBehaviour
{
    public GameObject panel;
    private bool isPlayerNearby = false;

    void Update()
    {
        // Check if the player is nearby and if they press 'E'
        Debug.Log(isPlayerNearby);
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            if (panel != null)
            {
                panel.SetActive(!panel.activeSelf);  // Toggle the visibility of the panel
            }
            else
            {
                Debug.Log("Panel reference is missing");
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("player inside the trigger");
        if (other.CompareTag("Player"))
        {
            Debug.Log("triggered");
            isPlayerNearby = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Open_rune_puzzle_key : MonoBehaviour
{
    public GameObject panel;

    private void OnMouseDown()
    {
        if (panel != null)
        {
            panel.SetActive(!panel.activeSelf);
        }
        else
        {
            Debug.Log("Panel reference is missing");
        }
    }

    // This method TO BE used when player sprite has colliders
    // void Update()
    // {
    //     if (Input.GetKeyDown(KeyCode.E))
    //     {
    //         if (panel != null)
    //         {
    //             panel.SetActive(!panel.activeSelf);
    //         }
    //         else
    //         {
    //             Debug.Log("Panel reference is missing");
    //         }
    //     }
    // }
}

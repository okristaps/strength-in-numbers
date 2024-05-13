using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector2 movementInput;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // private void FixedUpdate() {
    //     if (movementInput != Vector2)
    // }

    // void OnMove(InputValue movementValue)
    // {
    //     movementInput = movementValue.Get<Vector2>();
    // }
}

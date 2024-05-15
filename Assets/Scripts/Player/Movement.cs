using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;

    public ContactFilter2D movementFilter;

    public float moveSpeed = 1f;

    float

            speedX,
            speedY;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void HandleMovement()
    {
        // walk
        speedX = Input.GetAxis("Horizontal");
        speedY = Input.GetAxis("Vertical");
        rb.velocity = new Vector2(speedX * moveSpeed, speedY * moveSpeed);

        // look at mouse
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.up =
            mousePos - new Vector2(transform.position.x, transform.position.y);
    }
}

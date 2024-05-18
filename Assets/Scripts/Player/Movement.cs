using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour {
	private Rigidbody2D rb;
	private Vector2 movementInput;
	private List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
	public ContactFilter2D movementFilter;

	public float moveSpeed = 0.5f;
	public float collisionOffset = 0.05f;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate() {
		if (movementInput != Vector2.zero) {
			int count = rb.Cast(movementInput, movementFilter, castCollisions, moveSpeed * Time.fixedDeltaTime + collisionOffset);
			if (count == 0) {
				rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
			}
		}

		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.up = mousePos - (Vector2)transform.position;
	}

	private void OnMove(InputValue value) {
		movementInput = value.Get<Vector2>();
	}


}

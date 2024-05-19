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

	public PlayerController player;

	public float moveSpeed = 0.5f;
	public float collisionOffset = 0.05f;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
		player = GetComponent<PlayerController>();
	}

	private void FixedUpdate() {
		int count = rb.Cast(movementInput, movementFilter, castCollisions, moveSpeed * Time.fixedDeltaTime + collisionOffset);

		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.up = mousePos - (Vector2)transform.position;

		if (count == 0) {
			rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
		}
		else if (count > 0) {
			if (castCollisions[0].collider.gameObject.tag == "Enemy"
			) {
				rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime / 3);
			}

			if (castCollisions[0].collider.gameObject.tag == "PistolAmmo"
			|| castCollisions[0].collider.gameObject.tag == "ShotgunAmmo" || castCollisions[0].collider.gameObject.tag == "RifleAmmo" || castCollisions[0].collider.gameObject.tag == "GrenadeAmmo" || castCollisions[0].collider.gameObject.tag == "HealthPack") {
				rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
			}
		}

		if (castCollisions[0].collider.gameObject.tag == "Enemy") {
			player.TakeDamage(0.1);
		}

	}




	private void OnMove(InputValue value) {
		movementInput = value.Get<Vector2>();
	}


}

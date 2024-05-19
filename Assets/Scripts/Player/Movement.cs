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


		string[] allowedTags = { "Enemy", "PistolAmmo", "ShotgunAmmo", "RifleAmmo", "GrenadeAmmo", "HealthPack", "Grenade_Throw", "Grenade" };

		if (count > 0) {
			string collidedTag = castCollisions[0].collider.gameObject.tag;

			if (System.Array.Exists(allowedTags, tag => tag == collidedTag)) {
				rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
			}

			switch (collidedTag) {
				case "Enemy":
					player.TakeDamage(0.1f);
					break;

			}
		}
		else {
			rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
		}
	}

	private void OnMove(InputValue value) {
		movementInput = value.Get<Vector2>();
	}


}

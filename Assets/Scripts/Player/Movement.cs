using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour {
	private Rigidbody2D rb;
	private Vector2 movementInput;
	private List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
	public ContactFilter2D movementFilter;

	//

	public float moveSpeed = 1f;
	public float collisionOffset = 0.05f;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate() {
		if (movementInput != Vector2.zero) {

			Vector2 movement = movementInput * moveSpeed * Time.fixedDeltaTime;


			int count = rb.Cast(movement, movementFilter, castCollisions, movement.magnitude + collisionOffset);


			if (count == 0) {
				rb.MovePosition(rb.position + movement);
			}
		}


		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.up = mousePos - new Vector2(transform.position.x, transform.position.y);
	}

	private void OnMove(InputValue value) {
		movementInput = value.Get<Vector2>();
	}
}

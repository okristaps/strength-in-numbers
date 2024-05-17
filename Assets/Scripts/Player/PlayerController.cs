using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {
	[SerializeField]
	private GameObject _bulletTrail;

	private WeaponSelect _weaponSelect;

	Rigidbody2D rb;

	Vector2 movementInput;
	List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();
	public ContactFilter2D movementFilter;

	public float moveSpeed = 1f;
	public float collisionOffset = 0.05f;






	[SerializeField]
	public Shoot _shoot;

	public int currentWeaponIndex = 0;

	void Start() {
		rb = GetComponent<Rigidbody2D>();
		_weaponSelect = GetComponent<WeaponSelect>();
		_shoot = GetComponent<Shoot>();

	}

	void Update() {
		_shoot.HandleShooting();
		currentWeaponIndex = _weaponSelect.currentWeaponIndex;
	}


	private void FixedUpdate() {

		Debug.Log("Happened?");
		if (movementInput != Vector2.zero) {


			int count = rb.Cast(movementInput, movementFilter, castCollisions, moveSpeed * Time.fixedDeltaTime + collisionOffset);
			rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);

			if (count == 0) {
				rb.MovePosition(rb.position - movementInput * moveSpeed * Time.fixedDeltaTime);
			}
		}

		Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.up = mousePos - new Vector2(transform.position.x, transform.position.y);
	}

	private void onMove(InputValue value) {
		movementInput = value.Get<Vector2>();
	}
}

public interface IHittable {
	void Hit();
}
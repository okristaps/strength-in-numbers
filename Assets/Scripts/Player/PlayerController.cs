using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;


public class PlayerController : MonoBehaviour {
	[SerializeField]
	private GameObject _bulletTrail;

	private WeaponSelect _weaponSelect;

	public ContactFilter2D movementFilter;

	public double health = 100;


	[SerializeField]
	public Shoot _shoot;

	public int currentWeaponIndex = 0;



	void Start() {

		_weaponSelect = GetComponent<WeaponSelect>();
		_shoot = GetComponent<Shoot>();

	}

	void Update() {
	
		_shoot.HandleShooting();
		currentWeaponIndex = _weaponSelect.currentWeaponIndex;
	}


	void OnCollisionEnter(Collision col) {
		
	}

	public void TakeDamage(double amount) {
		health -= amount;
		if (health <= 0) {
			Destroy(gameObject);
		}
	}

}





public interface IHittable {
	void Hit();
}

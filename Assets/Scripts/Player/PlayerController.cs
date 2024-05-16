using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	private GameObject _bulletTrail;

	private WeaponSelect _weaponSelect;

	private Movement _movement;

	[SerializeField]
	public Shoot _shoot;

	public int currentWeaponIndex = 0;

	void Start()
	{
		_weaponSelect = GetComponent<WeaponSelect>();
		_shoot = GetComponent<Shoot>();
		_movement = GetComponent<Movement>();
	}

	void Update()
	{
		_shoot.HandleShooting();
		_movement.HandleMovement();
		currentWeaponIndex = _weaponSelect.currentWeaponIndex;
	}
}

public interface IHittable
{
	void Hit();
}

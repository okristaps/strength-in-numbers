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

	public ContactFilter2D movementFilter;




	[SerializeField]
	public Shoot _shoot;

	public int currentWeaponIndex = 0;

	void Start()
	{

		_weaponSelect = GetComponent<WeaponSelect>();
		_shoot = GetComponent<Shoot>();

	}

	void Update()
	{
		_shoot.HandleShooting();
		currentWeaponIndex = _weaponSelect.currentWeaponIndex;
	}


}

public interface IHittable
{
	void Hit();
}
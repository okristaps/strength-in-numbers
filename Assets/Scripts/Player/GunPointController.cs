using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPointController : MonoBehaviour
{
	private PlayerController player;

	private Vector3 initialPosition;

	private Vector3 initialScale;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		initialPosition = transform.localPosition;
		initialScale = transform.localScale;
	}

	void Update()
	{
		MoveGunPointToLeft();
	}

	// Ugly but works
	public void MoveGunPointToLeft()
	{
		Vector3 newPosition = Vector3.zero;

		if (player.currentWeaponIndex == 0)
		{
			newPosition = initialPosition;
			transform.localScale = initialScale.WithAxis(Axis.X, value: 0.5f).WithAxis(Axis.Y, value: 0.5f);
		}

		if (player.currentWeaponIndex == 1)
		{
			newPosition = initialPosition.WithAxis(Axis.X, value: -0.21f).WithAxis(Axis.Y, value: 3.1f).WithAxis(Axis.Z, value: 1.0f);

			transform.localScale = initialScale.WithAxis(Axis.X, value: 1.0f).WithAxis(Axis.Y, value: 1.0f);
		}

		if (player.currentWeaponIndex == 2)
		{
			newPosition = initialPosition.WithAxis(Axis.X, value: -0.3f).WithAxis(Axis.Y, value: 2.8f);

			transform.localScale = initialScale.WithAxis(Axis.X, value: 1.0f);
		}

		if (player.currentWeaponIndex == 3)
		{
			newPosition = initialPosition.WithAxis(Axis.X, value: -0.21f).WithAxis(Axis.Y, value: 3.6f).WithAxis(Axis.Z, value: 1.0f);

			transform.localScale = initialScale.WithAxis(Axis.X, value: 1.0f);
		}

		if (player.currentWeaponIndex == 4)
		{
			newPosition = initialPosition.WithAxis(Axis.X, value: -0.1f).WithAxis(Axis.Y, value: 3f);

			transform.localScale = initialScale.WithAxis(Axis.X, value: 2.0f);
		}

		transform.localPosition = newPosition;
	}
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using System.Timers;

public class ItemDespawn : MonoBehaviour {
	private float timer;
	private float interval = 1f;

	private void Start() {
		Destroy(gameObject, 15f);


	}

	private void Update() {
		Invoke("Blinking", 9.5f);
	}


	private void Blinking() {
		timer += Time.deltaTime;
		if (timer % 1.2 < interval) {

			gameObject.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 1f); // Transparent		

		}
		else {
			gameObject.GetComponent<SpriteRenderer>().material.color = new Color(1f, 1f, 1f, 0f);
		}
	}
}

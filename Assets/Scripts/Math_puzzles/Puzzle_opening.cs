using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle_opening : MonoBehaviour
{
	private GameObject currentPuzzlePanel;
	public GameObject mathPuzzlePrefab;

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Player")) {
			// Check and activate the puzzle panel
			if (currentPuzzlePanel != null) {
				mathPuzzlePrefab.SetActive(true);
				currentPuzzlePanel.SetActive(true);
				Debug.Log("Puzzle opened!");
			}
			else {
				Debug.LogError("Puzzle panel not assigned!");
			}
		}
	}

	void OnTriggerExit(Collider other) {
		// Check if the collider belongs to the player
		if (other.CompareTag("Player")) {
			// Deactivate the puzzle panel
			if (currentPuzzlePanel != null) {
				mathPuzzlePrefab.SetActive(false);
				currentPuzzlePanel.SetActive(false);
				Debug.Log("Puzzle closed!");
			}
			else {
				Debug.LogError("Puzzle panel not assigned!");
			}
		}
	}
}

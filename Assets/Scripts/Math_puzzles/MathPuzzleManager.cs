using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MathPuzzleManager : MonoBehaviour {
	public GameObject mathPuzzlePanel1;
	public GameObject mathPuzzlePanel2;
	public TMP_InputField answerInputField1;
	public TMP_InputField answerInputField2;
	public Button submitButton1;
	public Button submitButton2;

	public TextMeshProUGUI correctText;
	public TextMeshProUGUI wrongText;

	private void Start() {
		// Hide the puzzle panels initially
		//mathPuzzlePanel1.SetActive(false);
		//mathPuzzlePanel2.SetActive(false);

		// Hide the feedback texts initially
		correctText.gameObject.SetActive(false);
		wrongText.gameObject.SetActive(false);

		// Add listeners to the buttons
		submitButton1.onClick.AddListener(CheckAnswer1);
		submitButton2.onClick.AddListener(CheckAnswer2);
	}

	public void ShowMathPuzzle1() {
		mathPuzzlePanel1.SetActive(true);
	}

	public void ShowMathPuzzle2() {
		mathPuzzlePanel2.SetActive(true);
	}

	public void CheckAnswer1() {
		string answer = answerInputField1.text;
		if (answer == "7") {
			StartCoroutine(ShowFeedback(correctText, 2));
			OpenDoor1();
		}
		else {
			StartCoroutine(ShowFeedback(wrongText, 2));
		}
	}

	public void CheckAnswer2() {
		string answer = answerInputField2.text;
		if (answer == "10") {
			StartCoroutine(ShowFeedback(correctText, 2));
			OpenDoor2();
		}
		else {
			StartCoroutine(ShowFeedback(wrongText, 2));
		}
	}

	private IEnumerator ShowFeedback(TextMeshProUGUI textElement, float duration) {
		textElement.gameObject.SetActive(true);
		yield return new WaitForSeconds(duration);
		textElement.gameObject.SetActive(false);
	}

	private void OpenDoor1() {
		// Placeholder method to open the door for puzzle 1
		Debug.Log("Opening Door 1");
	}

	private void OpenDoor2() {
		// Placeholder method to open the door for puzzle 2
		Debug.Log("Opening Door 2");
	}
}

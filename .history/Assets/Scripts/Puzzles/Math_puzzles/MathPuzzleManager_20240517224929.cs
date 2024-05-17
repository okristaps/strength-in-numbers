using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MathPuzzleManager : MonoBehaviour
{
    public GameObject mathPuzzlePanel1;
    public GameObject mathPuzzlePanel2;
    public TMP_InputField answerInputField1;
    public TMP_InputField answerInputField2;

    private void Start()
    {
        // Hide the puzzle panels initially
        mathPuzzlePanel1.SetActive(false);
        mathPuzzlePanel2.SetActive(false);
    }

    public void ShowMathPuzzle1()
    {
        mathPuzzlePanel1.SetActive(true);
    }

    public void ShowMathPuzzle2()
    {
        mathPuzzlePanel2.SetActive(true);
    }

    public void CheckAnswer1()
    {
        string answer = answerInputField1.text;
        if (answer == "6")
        {
            Debug.Log("Correct answer for Puzzle 1");
            OpenDoor1();
        }
        else
        {
            Debug.Log("Incorrect answer for Puzzle 1");
        }
    }

    public void CheckAnswer2()
    {
        string answer = answerInputField2.text;
        if (answer == "12")
        {
            Debug.Log("Correct answer for Puzzle 2");
            OpenDoor2();
        }
        else
        {
            Debug.Log("Incorrect answer for Puzzle 2");
        }
    }

    private void OpenDoor1()
    {
        // Placeholder method to open the door for puzzle 1
        Debug.Log("Opening Door 1");
    }

    private void OpenDoor2()
    {
        // Placeholder method to open the door for puzzle 2
        Debug.Log("Opening Door 2");
    }
}

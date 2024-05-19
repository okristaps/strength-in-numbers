using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class RuneManager : MonoBehaviour
{
    public static RuneManager Instance { get; private set; }

    public TextMeshProUGUI correctText;
    public TextMeshProUGUI wrongText;
    public GameObject panel;
    private Dictionary<string, bool> placementStatus = new Dictionary<string, bool>();
    public TextMeshProUGUI completionText;
    public GameObject endScreenPanel;

    void Update()
    {
        // Check if the Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleGameOptionsPanel();
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        InitializeTextElements();
    }

    public void FinishGame()
    {
        Application.Quit();
    }

    private void InitializeTextElements()
    {
        if (correctText == null)
        {
            correctText = GameObject.Find("correctText").GetComponent<TextMeshProUGUI>();
        }
        if (wrongText == null)
        {
            wrongText = GameObject.Find("wrongText").GetComponent<TextMeshProUGUI>();
        }

        if (correctText != null) correctText.gameObject.SetActive(false);
        if (wrongText != null) wrongText.gameObject.SetActive(false);
    }

    public void ShowCorrectMessage(string message, float duration)
    {
        StartCoroutine(ShowMessage(correctText, message, duration));
    }

    public void ShowWrongMessage(string message, float duration)
    {
        StartCoroutine(ShowMessage(wrongText, message, duration));
    }

    public void RegisterSlot(string slotName)
    {
        if (!placementStatus.ContainsKey(slotName))
        {
            placementStatus.Add(slotName, false);
        }
    }

    public void MarkSlotCorrect(string slotName)
    {
        if (placementStatus.ContainsKey(slotName))
        {
            placementStatus[slotName] = true;
            CheckAllPlacements();
        }
    }

    private void CheckAllPlacements()
    {
        foreach (var placement in placementStatus)
        {
            if (!placement.Value)
            {
                return;
            }
        }

        StartCoroutine(ClosePanelAfterDelay(2f));
        endScreenPanel.SetActive(true);
    }

    private IEnumerator ClosePanelAfterDelay(float delay)
    {
        ShowMessage(correctText, "The Door is now open", delay);
        yield return new WaitForSeconds(delay);
        panel.SetActive(!panel.activeSelf);
    }

    private IEnumerator ShowMessage(TextMeshProUGUI textElement, string message, float duration)
    {
        textElement.text = message;
        textElement.gameObject.SetActive(true);
        yield return new WaitForSeconds(duration);
        textElement.gameObject.SetActive(false);
    }

    public void ContinueGame()
    {
        endScreenPanel.SetActive(false);
    }

    public void RestartGame()
    {
        endScreenPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);  // Reload the current scene
    }

    public void ToggleGameOptionsPanel()
    {
        // Toggle the visibility of the game options panel
        endScreenPanel.SetActive(!endScreenPanel.activeSelf);
    }
}

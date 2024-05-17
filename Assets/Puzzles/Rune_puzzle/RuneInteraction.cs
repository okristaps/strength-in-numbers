using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class RuneInteraction : MonoBehaviour, IPointerClickHandler
{
    private static GameObject selectedRune = null;
    private static Outline selectedRuneOutline = null;

    private void Start()
    {
        if (this.CompareTag("AnswerRune"))
        {
            RuneManager.Instance.RegisterSlot(gameObject.name);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (this.CompareTag("Rune"))
        {
            if (selectedRune != null && selectedRuneOutline != null)
            {
                // Disable the outline of the previously selected rune
                selectedRuneOutline.enabled = false;
            }

            selectedRune = gameObject;
            selectedRuneOutline = selectedRune.GetComponent<Outline>();
            if (selectedRuneOutline != null)
            {
                selectedRuneOutline.enabled = true;
            }
        }
        else if (this.CompareTag("AnswerRune") && selectedRune != null)
        {
            CheckPlacement(selectedRune, gameObject);
            selectedRune = null;

            if (selectedRuneOutline != null)
            {
                selectedRuneOutline.enabled = false;
                selectedRuneOutline = null;
            }
        }
    }

    private void CheckPlacement(GameObject rune, GameObject slot)
    {
        if (slot.name == "answer_" + rune.name)
        {
            Image runeImage = rune.GetComponent<Image>();
            Image slotImage = slot.GetComponent<Image>();
            if (slotImage != null && runeImage != null)
            {
                slotImage.sprite = runeImage.sprite;
            }
            slot.GetComponent<Collider2D>().enabled = false;
            RuneManager.Instance.MarkSlotCorrect(slot.name);
            RuneManager.Instance.ShowCorrectMessage("Correct!", 2);

            Outline runeOutline = rune.GetComponent<Outline>();
            if (runeOutline != null)
            {
                runeOutline.enabled = false;
            }
        }
        else
        {
            RuneManager.Instance.ShowWrongMessage("Incorrect. Try again!", 2);

            Outline runeOutline = rune.GetComponent<Outline>();
            if (runeOutline != null)
            {
                runeOutline.enabled = false;
            }
        }
    }
}

using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GrenadeSlot : MonoBehaviour
{
	Ammo ammo;

    void Start()
    {
		ammo = GameObject.FindGameObjectWithTag("Player").GetComponent<Ammo>();
	}

    void Update()
    {
		TextMeshProUGUI Grenades = GetComponentInChildren<TextMeshProUGUI>();

		if (ammo.grenadeCount == 0) {
			GetComponent<Image>().color = new Color(0.4f, 0.4f, 0.4f, 1f);
			transform.GetChild(0).GetComponent<Image>().color = new Color(0f, 0f, 0f, 1f);
		}

		else {
			GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
			transform.GetChild(0).GetComponent<Image>().color = new Color(1f, 1f, 1f, 1f);
			Grenades.text = ammo.grenadeCount.ToString();
		}
		
	}
}

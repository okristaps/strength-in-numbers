using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
	PlayerController pc;
	Slider slider;

    void Start(){
		pc = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
		slider = GetComponent<Slider>();
		slider.maxValue = (int)pc.health;
	}

    
    void Update(){
		slider.value = (int)pc.health;
		TextMeshProUGUI healthText = GetComponentInChildren<TextMeshProUGUI>();
		healthText.text = slider.value.ToString();
	}
	
	
}

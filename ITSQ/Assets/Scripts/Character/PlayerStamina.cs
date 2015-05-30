using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStamina : MonoBehaviour {

	public int startingStamina = 100;
	public float currentStamina;
	public float staminaRegen = 10f;
	public Slider staminaSlider;



	void Awake(){
		currentStamina = startingStamina;
	}

	// Update is called once per frame
	void Update () {
		staminaSlider.value = currentStamina;
		StaminaRegen ();
	}

	void StaminaRegen(){
		if (staminaSlider.value < 100 && staminaSlider.value >= 0) {
			currentStamina += staminaRegen * Time.deltaTime;
			staminaSlider.value = currentStamina;
		}
	}
}

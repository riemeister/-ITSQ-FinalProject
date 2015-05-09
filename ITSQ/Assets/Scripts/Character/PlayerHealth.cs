using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	[SerializeField] private UILabel Health_Label;
	[SerializeField] private UILabel Stamina_Label;

	public float Health = 0.0f;
	public float Stamina = 0.0f;

	void Update () {

		float HealthUpdate = Health * 100f;
		float StaminaUpdate = Stamina * 100f;

		if (HealthUpdate >= 0 && (HealthUpdate <= 100)) {
			GameObject.Find ("HealthBar").GetComponent<UIProgressBar> ().value = this.Health;
			this.Health_Label.text = (HealthUpdate.ToString () + ("% Health"));
		}
		if (StaminaUpdate >= 0 && (StaminaUpdate <= 100)) {
			GameObject.Find ("StaminaBar").GetComponent<UIProgressBar> ().value = this.Stamina;
			this.Stamina_Label.text = (StaminaUpdate.ToString () + ("% Stamina"));
		}
	}
}

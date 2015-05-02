using UnityEngine;
using System.Collections;

public class GenericCountdownTimer : MonoBehaviour {

	[SerializeField] private UILabel textDisplay;
	[SerializeField] private float duration;

	private float goalTime = 0.0f;
	private bool countdownFinished = true;

	// Use this for initialization
	void Start () {
		this.textDisplay.text = string.Format ("{0:00}:{1:00}:{2:000}", 0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (this.countdownFinished == true)
			return;

		float currentTime = Mathf.Clamp (this.goalTime - Time.time, 0, float.MaxValue);

		if (currentTime > 0.000f) {
			int minutes = (int) currentTime / 60;
			int seconds = (int) currentTime % 60;
			int milliseconds =(int) (currentTime * 100) % 100;

			if (this.textDisplay != null) {
				this.textDisplay.text = string.Format ("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
			}
		} else {
			this.textDisplay.text = string.Format ("{0:00}:{1:00}:{2:000}", 0, 0, 0);
			this.countdownFinished = true;
			this.PerformFinishAction();
		}
	}

	public void StartTimer() {
		this.goalTime = Time.time + duration;
		this.countdownFinished = false;
	}

	public void PerformFinishAction() {
		Debug.LogWarning ("FINISHED TIMER!");
	}
}

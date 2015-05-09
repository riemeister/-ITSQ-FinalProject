using UnityEngine;
using System.Collections;

public class StatsHUDHandler : MonoBehaviour {

	[SerializeField] private UILabel Health_Label;
	[SerializeField] private UILabel Stamina_Label;

	public const string HEALTH_DATA_KEY = "HEALTH_DATA_KEY";
	public const string STAMINA_DATA_KEY = "STAMINA_DATA_KEY";

	// Use this for initialization
	void Start () {

		EventBroadcaster.Instance.AddObserver (EventNames.ON_UPDATE_GAME_STATUS, this.OnUpdateGameStatus);
	
	}

	private void OnUpdateGameStatus(Parameters parameters){
		int health = parameters.GetIntExtra (HEALTH_DATA_KEY, 0);
		int stamina = parameters.GetIntExtra (STAMINA_DATA_KEY, 0);

		this.Health_Label.text = "% Health" + health.ToString ();
		this.Stamina_Label.text = "% Stamina" + stamina.ToString ();
	}
}

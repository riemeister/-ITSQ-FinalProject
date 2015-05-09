using UnityEngine;
using System.Collections;

public class StatsEventCall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnUpdate(){

		Parameters dataParams = new Parameters ();
		dataParams.PutExtra (StatsHUDHandler.HEALTH_DATA_KEY, 45);
		dataParams.PutExtra (StatsHUDHandler.STAMINA_DATA_KEY, 45);

		EventBroadcaster.Instance.PostEvent (EventNames.ON_UPDATE_GAME_STATUS, dataParams);

	}
}

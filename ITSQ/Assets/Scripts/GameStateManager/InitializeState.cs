using UnityEngine;
using System.Collections;

/// <summary>
/// Handles game initialization.
/// </summary>
public class InitializeState : GameState {

	public override void OnStart ()
	{
		//TODO: temporarily set game mode. This can be moved on the main menu
		ModeManager.Instance.SetGameMode (ModeManager.ModeType.TIMED);

		EventBroadcaster.Instance.PostEvent (EventNames.ON_TRIGGER_PLAYER_SPAWN);
		EventBroadcaster.Instance.PostEvent (EventNames.ON_INITIALIZE_ITEM_SPAWN);
		EventBroadcaster.Instance.PostEvent (EventNames.ON_INITIALIZE_GAME_HUD);
		Debug.LogWarning ("Initialize state onStart()");
	}

	public override void OnUpdate ()
	{

	}

	public override void OnEnd ()
	{
		Debug.LogWarning ("Initialize state onEnd()");
	}
}

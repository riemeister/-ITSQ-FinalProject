using UnityEngine;
using System.Collections;

/// <summary>
/// Handles game initialization.
/// </summary>
public class InitializeState : GameState {

	public override void OnStart ()
	{
		EventBroadcaster.Instance.PostEvent (EventNames.ON_TRIGGER_PLAYER_SPAWN);
		Debug.LogWarning ("Initialize state onStart()");
	}

	public override void OnUpdate ()
	{
		Debug.LogWarning ("Initialize state onUpdate()");
	}

	public override void OnEnd ()
	{
		Debug.LogWarning ("Initialize state onEnd()");
	}
}

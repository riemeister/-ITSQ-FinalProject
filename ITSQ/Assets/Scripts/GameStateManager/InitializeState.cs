using UnityEngine;
using System.Collections;

/// <summary>
/// Handles game initialization.
/// </summary>
public class InitializeState : GameState {

	public override void OnStart ()
	{
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

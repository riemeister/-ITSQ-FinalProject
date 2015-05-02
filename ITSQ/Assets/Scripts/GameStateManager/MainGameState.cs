using UnityEngine;
using System.Collections;

/// <summary>
/// Main game state. Put functions that need to execute for the main game here.
/// </summary>
public class MainGameState : GameState {

	public override void OnStart ()
	{
		Debug.LogWarning ("Main game state onStart()");
	}

	public override void OnUpdate ()
	{

	}

	public override void OnEnd ()
	{
		Debug.LogWarning ("Main game state onEnd()");
	}
}

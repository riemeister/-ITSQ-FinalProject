using UnityEngine;
using System.Collections;

/// <summary>
/// End game state is called prior to exit of the game scene. Cleans up scene, save data should be here.
/// </summary>
public class EndGameState : GameState {

	public override void OnStart ()
	{
		Debug.LogWarning ("End game state onStart()");
	}

	public override void OnUpdate ()
	{
		Debug.LogWarning ("End game state onUpdate()");
	}

	public override void OnEnd ()
	{
		Debug.LogWarning ("End game state onEnd()");
	}
}

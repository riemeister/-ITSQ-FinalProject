using UnityEngine;
using System.Collections;

/// <summary>
/// Handles systems and functionalities after the game such as results tallying.
/// </summary>
public class PostGameState : GameState {

	public override void OnStart ()
	{
		Debug.LogWarning ("Post game state onStart()");
	}

	public override void OnUpdate ()
	{
		Debug.LogWarning ("Post game state onUpdate()");
	}

	public override void OnEnd ()
	{
		Debug.LogWarning ("Post game state onEnd()");
	}
}

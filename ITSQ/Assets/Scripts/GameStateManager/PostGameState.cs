using UnityEngine;
using System.Collections;

/// <summary>
/// Handles systems and functionalities after the game such as results tallying.
/// </summary>
public class PostGameState : GameState {

	public override void OnStart ()
	{
		Debug.LogWarning ("Post game state onStart()");

		//resolve results here
		
		ViewHandler.Instance.Show (ViewNames.RESULTS_PANEL_STRING);
	}

	public override void OnUpdate ()
	{

	}

	public override void OnEnd ()
	{
		Debug.LogWarning ("Post game state onEnd()");
	}
}

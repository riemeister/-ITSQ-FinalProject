using UnityEngine;
using System.Collections;

/// <summary>
/// Timed game mode.
/// </summary>
public class TimedGameMode : AGameMode {

	public const string TIMED_DURATION_KEY = "TIMED_DURATION_KEY";
	
	public override void Configure ()
	{
		this.modeValues [TIMED_DURATION_KEY] = 10.0f;
	}

	/// <summary>
	/// Reports that the timed game mode has finished and resolve the results of the round.
	/// </summary>
	public void ReportTimeFinished() {
		GameStateMachine.Instance.ChangeState (GameStateMachine.StateType.POST_GAME);
	}
}

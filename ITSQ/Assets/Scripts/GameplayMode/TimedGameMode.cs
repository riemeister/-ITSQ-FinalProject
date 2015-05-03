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
}

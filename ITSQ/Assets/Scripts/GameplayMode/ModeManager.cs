using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Holds possible game modes
/// </summary>
public class ModeManager {
	private static ModeManager sharedInstance = null;

	public static ModeManager Instance {
		get {
			if(sharedInstance == null) {
				sharedInstance = new ModeManager();
			}

			return sharedInstance;
		}
	}

	public enum ModeType
	{
		TIMED,
		LAST_MAN_STANDING
	}

	private AGameMode currentGameMode;
	private Dictionary<ModeType, AGameMode> gameModeTable = new Dictionary<ModeType, AGameMode>();

	private ModeManager() {
		this.InitializeGameModes ();
	}

	private void InitializeGameModes() {
		TimedGameMode timedGameMode = new TimedGameMode ();
		timedGameMode.Configure ();
		this.gameModeTable.Add (ModeType.TIMED, timedGameMode);
	}

	public void SetGameMode(ModeType modeType) {
		if (this.gameModeTable.ContainsKey (modeType)) {
			this.currentGameMode = this.gameModeTable [modeType];
		} else {
			Debug.LogError(modeType + " is not yet initialized! Have you put it in InitializeGameModes()?");
		}
	}

	public AGameMode GetCurrentGameMode() {
		if (this.currentGameMode != null) {
			return this.currentGameMode;
		} else {
			Debug.LogError("Game mode is not yet initialized!");
			return null;
		}
	}
}

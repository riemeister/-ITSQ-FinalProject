using UnityEngine;
using System.Collections;

/// <summary>
/// Game HUD view.
/// </summary>
public class GameHUDView : View {

	[SerializeField] GenericCountdownTimer countdownTimer;

	// Use this for initialization
	void Start () {
		EventBroadcaster.Instance.AddObserver (EventNames.ON_INITIALIZE_GAME_HUD, this.InitializeUIBasedFromMode);
	}

	void OnDestroy() {
		EventBroadcaster.Instance.RemoveActionAtObserver (EventNames.ON_INITIALIZE_GAME_HUD, this.InitializeUIBasedFromMode);
	}

	private void InitializeUIBasedFromMode() {
		AGameMode gameMode = ModeManager.Instance.GetCurrentGameMode ();
		if (gameMode.GetModeType () == ModeManager.ModeType.TIMED) {
			TimedGameMode timedGameMode = (TimedGameMode) gameMode;
			float duration = (float) timedGameMode.GetModeValue(TimedGameMode.TIMED_DURATION_KEY);

			this.countdownTimer.gameObject.SetActive(true);
			this.countdownTimer.SetDuration(duration);
			this.countdownTimer.StartTimer ();
			this.countdownTimer.AddFinishAction(timedGameMode.ReportTimeFinished);
		}
	}

	public override void OnShowEvent ()
	{
		base.OnShowEvent ();
		this.countdownTimer.gameObject.SetActive (false);
	}
}

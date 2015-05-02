using UnityEngine;
using System.Collections;

/// <summary>
/// Game HUD view.
/// </summary>
public class GameHUDView : View {

	[SerializeField] GenericCountdownTimer countdownTimer;

	// Use this for initialization
	void Start () {

	}

	public override void OnShowEvent ()
	{
		base.OnShowEvent ();
		this.countdownTimer.StartTimer ();
	}
}

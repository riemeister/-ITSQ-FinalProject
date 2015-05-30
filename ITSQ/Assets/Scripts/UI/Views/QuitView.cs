using UnityEngine;
using System.Collections;

public class QuitView : View {

	private bool confirmed = true;

	// Use this for initialization
	void Start () {

	}

	public void OnMainMenuClicked(){
		LoadManager.LoadScene (SceneNames.MAIN_MENU_SCENE, true);
	}


	public void OnQuitButtonClicked() {
		this.Hide ();
	}

	public void OnCancelButtonClicked() {
		this.confirmed = false;
		this.Hide ();
	}

	public override void OnHideEvent ()
	{
		base.OnHideEvent ();

		if (this.confirmed) {
			Application.Quit ();
		} else {
			GamePauseHandler.Instance.Resume();
		}

	}

	public override void OnShowEvent ()
	{
		base.OnShowEvent ();
		GamePauseHandler.Instance.Pause ();
	}
}

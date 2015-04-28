using UnityEngine;
using System.Collections;

/// <summary>
/// Represents the main menu view
/// </summary>
public class MainMenuView : View {

	// Use this for initialization
	void Start () {
	
	}

	public void OnServerClicked(){
		ViewHandler.Instance.Show (ViewNames.SERVER_PANEL_STRING);
	}

	public void OnClientClicked(){
		ViewHandler.Instance.Show (ViewNames.CLIENT_PANEL_STRING);
	}

	public void OnQuitClicked(){
		Application.Quit ();
	}
}

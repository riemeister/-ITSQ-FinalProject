using UnityEngine;
using System.Collections;

public class DebugView : View {

	// Use this for initialization
	void Start () {
	
	}

	public void OnMainMenuClicked() {
		ViewHandler.Instance.ShowViewWithNullProperty (ViewNames.MAIN_MENU_PANEL_STRING);
	}

	public void OnServerClicked() {

	}

	public void OnClientClicked() {

	}

	public void OnCharacterSelectionClicked() {

	}

	public void OnCharacterPreviewClicked() {

	}

	public void OnLobbyClicked() {

	}
}

using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {
	public UIPanel MainMenuPanel;
	public UIPanel ServerPanel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick(){
		MainMenuPanel.gameObject.SetActive (true);
		ServerPanel.gameObject.SetActive (false);
	}
}

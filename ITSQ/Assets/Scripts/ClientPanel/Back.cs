using UnityEngine;
using System.Collections;

public class Back : MonoBehaviour {
	public UIPanel MainMenuPanel;
	public UIPanel ClientPanel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick(){
		MainMenuPanel.gameObject.SetActive (true);
		ClientPanel.gameObject.SetActive (false);
	}
}

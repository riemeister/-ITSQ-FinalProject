using UnityEngine;
using System.Collections;

public class CreateServer : MonoBehaviour {
	public UIPanel ServerPanel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick(){
		ServerPanel.gameObject.SetActive (true);
	}
}

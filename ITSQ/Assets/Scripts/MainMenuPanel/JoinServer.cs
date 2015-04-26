using UnityEngine;
using System.Collections;

public class JoinServer : MonoBehaviour {
	public UIPanel ClientPanel;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick(){
		ClientPanel.gameObject.SetActive (true);
	}
}

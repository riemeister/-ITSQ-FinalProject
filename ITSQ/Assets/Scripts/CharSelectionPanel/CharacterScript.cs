using UnityEngine;
using System.Collections;

public class CharacterScript : MonoBehaviour {
	public UIPanel CharPreview;
	public UIPanel CharaSelecion;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnClick(){
		CharPreview.gameObject.SetActive (true);
		CharaSelecion.gameObject.SetActive (false);
	}
}

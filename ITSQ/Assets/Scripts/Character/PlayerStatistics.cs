using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStatistics : MonoBehaviour {
	
	public Text damageText;
	public Text defenseText;
	public Text speedText;

	GameObject player;
	PlayerControl playerControl;

	void Awake(){

		player = GameObject.FindGameObjectWithTag ("Player");
		playerControl = player.GetComponent<PlayerControl> ();
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		damageText.text = playerControl.currentDamage.ToString ();
		defenseText.text = playerControl.currentDefense.ToString ();
		speedText.text = playerControl.speed.ToString ();
	}
}

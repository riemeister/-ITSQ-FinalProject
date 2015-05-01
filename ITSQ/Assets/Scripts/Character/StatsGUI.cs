using UnityEngine;
using System.Collections;

public class StatsGUI : MonoBehaviour {
	private CharacterBase Ninja1 = new NinjaBase();
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUILayout.Label (Ninja1.characterName);
		GUILayout.Label ("Damage: " + Ninja1.Damage.ToString());
		GUILayout.Label ("Atk Spd: " + Ninja1.AtkSpd.ToString());
		GUILayout.Label ("Def: " + Ninja1.Def.ToString());
		GUILayout.Label ("Stamina: " + Ninja1.Stamina.ToString());
		GUILayout.Label ("Health: " + Ninja1.Health.ToString());

	}
}

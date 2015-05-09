using UnityEngine;
using System.Collections;

public class CharacterProfile {

	private static CharacterProfile sharedInstance = null;

	public static CharacterProfile Instance {
		get{
			if(sharedInstance == null){
				sharedInstance = new CharacterProfile();
			}
			return sharedInstance;
		}
	}

	public enum CharacterStats{
		AtkSpd,
		Damage,
		Def,
		Health,
		Stamina
	}

	private string characterName;
	private int AtkSpd;
	private int Damage;
	private int Def;
	private int Health;
	private int Stamina;

	private CharacterProfile(){
		this.InitializeCharacterProfile();
	}

	private void InitializeCharacterProfile(){

		int AtkSpd = 10;
		int Damage = 10;
		int Def = 10;
		int Health = 100;
		int Stamina = 100;
	}

	public void ChangeCharacterProfile(int AtkSpd, int Damage, int Def, int Health, int Stamina){
		this.AtkSpd = AtkSpd;
		this.Damage = Damage;
		this.Def = Def;
		this.Health = Health;
		this.Stamina = Stamina;
	}
}

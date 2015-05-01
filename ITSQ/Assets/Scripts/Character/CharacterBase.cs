using UnityEngine;
using System.Collections;

public class CharacterBase {

	public string characterName;

	public int damage;
	public int atkspd;
	public int def;
	public int stamina;
	public int health;

	public string CharacterName{
		get { return CharacterName; }
		set { characterName = value; }
	}

	public int Damage{
		get { return damage; }
		set { damage = value; }
	}

	public int AtkSpd {
		get { return atkspd; }
		set { atkspd = value; }
	}

	public int Def {
		get { return def; }
		set { def = value; }
	}

	public int Stamina{
		get { return stamina; }
		set { stamina = value; }
	}

	public int Health{
		get { return health; }
		set { health = value; }
	}
}

using UnityEngine;
using System.Collections;

public class CharacterBase {

	protected string characterName;
	protected int damage;
	protected int atkspd;
	protected int def;
	protected int stamina;
	protected int health;

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

using UnityEngine;
using System.Collections;

public class BaseStatItems : Items{

	private int damage;
	private int atkspd;
	private int def;
	private int stamina;
	private int health;

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

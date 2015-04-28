using UnityEngine;
using System.Collections;

public abstract class BaseWeapon {

	public abstract int Str { get; set; }
	public abstract int Agi { get; set; }
	public abstract int Int { get; set; }

	public abstract void getWeaponStats();
}

using UnityEngine;
using System.Collections;

public class BaseWeapon : BaseStatItems { //BaseWeapon <- BaseStatItem <- BaseItem

	public enum WeaponTypes{
		SWORD,
		DAGGER,
		KUNAI,
		SHURIKEN,
		THROWING_KNIVES,
		TEKKO
	}

	private WeaponTypes weaponType;
	private int weaponStatsEffectsID;
	
	public WeaponTypes WeaponType{
		get { return weaponType; }
		set { weaponType = value; }
	}

	public int WeaponEffectID{
		get { return weaponStatsEffectsID; }
		set { weaponStatsEffectsID = value; }
	}

}

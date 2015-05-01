using UnityEngine;
using System.Collections;

public class CreateWeapon : MonoBehaviour {
	//access the BaseWeapon, BaseStatItems, and Items
	public BaseWeapon newWeapon;


	void Start(){
		createWeapon ();
		Debug.Log (newWeapon.ItemName);
		Debug.Log (newWeapon.WeaponType.ToString());
	}

	public void createWeapon(){

		newWeapon = new BaseWeapon();
		//name
		newWeapon.ItemName = "Weapon: " + Random.Range(1,7);
		//id
		//newWeapon.ItemID = Random.Range (1, 7);
		//stats
		newWeapon.Health = Random.Range (1, 101);
		newWeapon.Stamina = Random.Range (1, 101);
		newWeapon.Def = Random.Range (1, 101);
		newWeapon.Damage = Random.Range (1, 101);
		newWeapon.AtkSpd = Random.Range (1, 101);
		//choose type of weapon
		ChooseWeaponType ();
		//effect
		newWeapon.WeaponEffectID = Random.Range (1, 101);
	}

	private void ChooseWeaponType(){
		int randomTemp = Random.Range (1, 7);
		if (randomTemp == 1) {
			newWeapon.WeaponType = BaseWeapon.WeaponTypes.SWORD;
		} else if (randomTemp == 2) {
			newWeapon.WeaponType = BaseWeapon.WeaponTypes.DAGGER;
		}else if (randomTemp == 3) {
			newWeapon.WeaponType = BaseWeapon.WeaponTypes.KUNAI;
		}else if (randomTemp == 4) {
			newWeapon.WeaponType = BaseWeapon.WeaponTypes.SHURIKEN;
		}else if (randomTemp == 5) {
			newWeapon.WeaponType = BaseWeapon.WeaponTypes.THROWING_KNIVES;
		}else if (randomTemp == 6) {
			newWeapon.WeaponType = BaseWeapon.WeaponTypes.TEKKO;
		}
	}
}

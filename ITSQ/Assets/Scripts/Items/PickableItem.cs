using UnityEngine;
using System.Collections;

/// <summary>
/// Represents a pickable item in the game world. Can be a weapon, booster or potion.
/// </summary>
public class PickableItem : MonoBehaviour {

	[SerializeField] private Items.ItemTypes itemType;
	[SerializeField] private BaseBoosters.BoosterTypes boosterType;
	[SerializeField] private BasePotions.PotionTypes potionType;
	[SerializeField] private BaseWeapon.WeaponTypes weaponType;
	[SerializeField] private BaseStatItems baseStats;

	private Items itemData;//your item data/class representation
	private BaseBoosters boosterData;
	private BasePotions potionData;
	private BaseWeapon weaponData;

	// Use this for initialization
	void Start () {
		this.Initialize ();
	}

	private void Initialize() {
		//initialize your item data based from the specified item type. This is just an example
		this.itemData = new Items ();
		this.itemData.ItemType = this.itemType;

		this.boosterData = new BaseBoosters ();
		this.boosterData.BoosterType = this.boosterType;

		this.potionData = new BasePotions ();
		this.potionData.PotionType = this.potionType;

		this.weaponData = new BaseWeapon ();
		this.weaponData.WeaponType = this.weaponType;

		this.baseStats = new BaseStatItems ();

	}

	public Items.ItemTypes GetItemType() {
		return this.itemData.ItemType;
	}

	public BaseBoosters.BoosterTypes GetBoosterType(){
		return this.boosterData.BoosterType;
	}

	public BasePotions.PotionTypes GetPotionType(){
		return this.potionData.PotionType;
	}

	public BaseWeapon.WeaponTypes GetWeaponType(){
		return this.weaponData.WeaponType;
	}

	public Items GetItemData() {
		return this.itemData;
	}

	public BaseBoosters GetBoosterData() {
		return this.boosterData;
	}

	public BasePotions GetPotionData() {
		return this.potionData;
	}

	public BaseWeapon GetWeaponData() {
		return this.weaponData;
	}

	void OnTriggerEnter(Collider other){
		Debug.Log (itemType);
		if (itemType == Items.ItemTypes.BOOSTER) {
			if (boosterType == BaseBoosters.BoosterTypes.ATKSPD) {
				baseStats.AtkSpd = Random.Range(0,49);
			}
			else if (boosterType == BaseBoosters.BoosterTypes.DAMAGE) {
				baseStats.Damage = Random.Range(0,49);
			}
			else if (boosterType == BaseBoosters.BoosterTypes.DEF) {
				baseStats.Def = Random.Range(0,49);
			}
		}

		if (itemType == Items.ItemTypes.POTIONS) {
			Debug.Log(potionType);
			if(potionType == BasePotions.PotionTypes.HEALTH){
				baseStats.Health = Random.Range(0,49);
			}
			if(potionType == BasePotions.PotionTypes.STAMINA){
				baseStats.Stamina = Random.Range(0,49);
			}
		}
		if (itemType == Items.ItemTypes.WEAPONS) {
			baseStats.AtkSpd = Random.Range(0,49);
			baseStats.Damage = Random.Range(0,49);
			baseStats.Def = Random.Range(0,49);
			baseStats.Health = Random.Range(0,49);
			baseStats.Stamina = Random.Range(0,49);
		}
		Destroy(gameObject);
	}
}
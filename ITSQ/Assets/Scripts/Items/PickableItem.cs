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

	private Items itemData;//your item data/class representation
	private BaseBoosters boosterData;
	private BasePotions potionData;
	private BaseWeapon weaponData;

	GameObject player;
	PlayerControl playerControl;
	PlayerHealth playerHealth;
	PlayerStamina playerStamina;

	void Awake(){
		player = GameObject.FindGameObjectWithTag ("Player");
		playerControl = player.GetComponent<PlayerControl> ();
		playerHealth = player.GetComponent<PlayerHealth> ();
		playerStamina = player.GetComponent<PlayerStamina> ();
	}

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
		if (itemType == Items.ItemTypes.BOOSTER) {
			if (boosterType == BaseBoosters.BoosterTypes.ATKSPD) {
				playerControl.speed += 100f;
			}
			else if (boosterType == BaseBoosters.BoosterTypes.DAMAGE) {
				playerControl.currentDamage += 20;
			}
			else if (boosterType == BaseBoosters.BoosterTypes.DEF) {
				playerControl.currentDefense = Random.Range(20,50);
			}
		}

		if (itemType == Items.ItemTypes.POTIONS) {
			playerHealth.currentHealth += 45;
			playerStamina.currentStamina += 25;
			playerHealth.healthSlider.value = playerHealth.currentHealth;
		}

		if (itemType == Items.ItemTypes.WEAPONS) {
			playerControl.currentDamage += Random.Range(20,50);
			playerControl.currentDefense = Random.Range(20,50);
		}
		Debug.Log (other);
		Destroy(gameObject);
	}
}
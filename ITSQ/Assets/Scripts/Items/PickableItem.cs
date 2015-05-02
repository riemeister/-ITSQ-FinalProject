using UnityEngine;
using System.Collections;

/// <summary>
/// Represents a pickable item in the game world. Can be a weapon, booster or potion.
/// </summary>
public class PickableItem : MonoBehaviour {

	[SerializeField] private Items.ItemTypes itemType;
	private Items itemData;	//your item data/class representation

	// Use this for initialization
	void Start () {
		this.Initialize ();
	}

	private void Initialize() {
		//initialize your item data based from the specified item type. This is just an example
		this.itemData = new Items ();
		this.itemData.ItemType = this.itemType;
	}

	public Items.ItemTypes GetItemType() {
		return this.itemData.ItemType;
	}

	public Items GetItemData() {
		return this.itemData;
	}
}

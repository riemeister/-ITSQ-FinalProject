using UnityEngine;
using System.Collections;

public class Items {

	private string itemName;
	private int itemID;
	public enum ItemTypes{
		WEAPONS,
		POTION,
		BOOSTER
	}

	private ItemTypes itemType;

	public string ItemName{
		get { return itemName; }
		set { itemName = value; }
	}

	public int ItemID{
		get { return itemID; }
		set { itemID = value; }
	}

	public ItemTypes ItemType{
		get { return itemType; }
		set { itemType = value; }
	}
}

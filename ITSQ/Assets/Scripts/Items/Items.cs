using UnityEngine;
using System.Collections;

public class Items {

	protected string itemName;
	protected int itemID;

	public enum ItemTypes{
		WEAPONS,
		POTION,
		BOOSTER
	}

	protected ItemTypes itemType;

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

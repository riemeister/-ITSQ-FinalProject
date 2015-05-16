using UnityEngine;
using System.Collections;

public class BasePotions : BaseStatItems {

	public enum PotionTypes{
		HEALTH,
		STAMINA
	}

	private PotionTypes potionType;
	private int potionStatsEffectsID;

	public PotionTypes PotionType{
		get { return potionType; }
		set { potionType = value; }
	}

	public int PotionEffectsID{
		get { return potionStatsEffectsID; }
		set { potionStatsEffectsID = value; }
	}
}

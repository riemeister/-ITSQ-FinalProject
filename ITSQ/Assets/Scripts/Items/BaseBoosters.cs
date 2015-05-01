using UnityEngine;
using System.Collections;

public class BaseBoosters : BaseStatItems{

	public enum BoosterTypes{
		DAMAGE,
		ATKSPD,
		DEF
	}

	private BoosterTypes boosterType;
	private int boosterStatsEffectID;

	public BoosterTypes BoosterType{
		get { return boosterType; }
		set { boosterType = value; }
	}

	public int BoosterStatsEffectID {
		get { return boosterStatsEffectID; }
		set { boosterStatsEffectID = value; }
	}
}

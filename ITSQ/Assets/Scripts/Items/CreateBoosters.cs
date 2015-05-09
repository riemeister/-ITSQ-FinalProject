using UnityEngine;
using System.Collections;

public class CreateBoosters : MonoBehaviour {

	private BaseBoosters newBooster;

	// Use this for initialization
	void Start () {
		createBooster ();
		Debug.Log (newBooster.ItemName);
		Debug.Log (newBooster.BoosterType.ToString());
		Debug.Log (newBooster.BoosterStatsEffectID.ToString());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void createBooster(){
		newBooster = new BaseBoosters ();
		newBooster.ItemName = "Booster";
		newBooster.BoosterStatsEffectID = Random.Range (1, 51);
		ChooseBoosterType ();
	}

	private void ChooseBoosterType(){
		int randomTemp = Random.Range (0, 3);
		Debug.Log (randomTemp);
		if (randomTemp == 0) {
			newBooster.BoosterType = BaseBoosters.BoosterTypes.DAMAGE;
		}else if (randomTemp == 1) {
			newBooster.BoosterType = BaseBoosters.BoosterTypes.ATKSPD;
		}else if (randomTemp == 2) {
			newBooster.BoosterType = BaseBoosters.BoosterTypes.DEF;
		} 
	}
	
}

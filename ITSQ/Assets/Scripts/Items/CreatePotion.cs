using UnityEngine;
using System.Collections;

public class CreatePotion : MonoBehaviour {

	private BasePotions newPotion;

	// Use this for initialization
	void Start () {

		createPotion ();
		Debug.Log (newPotion.ItemName);
		Debug.Log (newPotion.PotionType.ToString());
		//Debug.Log (newPotion.Health.ToString());
		//Debug.Log (newPotion.Stamina.ToString());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private void createPotion(){
		newPotion = new BasePotions();
		newPotion.ItemName = "Potion";
		newPotion.Health = Random.Range (1,101);
		newPotion.Stamina = Random.Range (1,101);
		ChoosePotionType ();
	}

	private void ChoosePotionType(){
		int randomTemp = Random.Range (0,2);
		Debug.Log (randomTemp);
		if (randomTemp == 0) {
			newPotion.PotionType = BasePotions.PotionTypes.HEALTH;
		}else if (randomTemp == 1) {
			newPotion.PotionType = BasePotions.PotionTypes.STAMINA;
		} 
	}
}

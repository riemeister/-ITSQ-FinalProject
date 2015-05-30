using UnityEngine;
using System.Collections;

public class GMTool : MonoBehaviour {
	public PlayerHealth playerHealth;
	public PlayerStamina playerStamina;
	public EnemyHealth enemyHealth;
	public EnemyWeapon enemyWeapon;
	public PlayerControl playerControl;
	public EnemyConstants enemyConstants;
	//public int gmPlayerHealth, gmPlayerStamina, gmEnemyHealth, gmEnemyAttackDamage;
	bool isToolActivate;
	void OnGUI(){
		if (isToolActivate == true) {
			GUI.Box (new Rect (100, 200, 400, 500), "GM Tool");

			GUI.Label (new Rect (120, 220, 200, 100), "Player Max Health: " + playerHealth.startingHealth);
			playerHealth.startingHealth = (int)GUI.HorizontalSlider (new Rect (120, 240, 380, 10), playerHealth.startingHealth, 0, 500);

			GUI.Label (new Rect (120, 260, 200, 100), "Player Max Stamina: " + playerStamina.startingStamina);
			playerStamina.startingStamina = (int)GUI.HorizontalSlider (new Rect (120, 280, 380, 10), playerStamina.startingStamina, 0, 500);

			GUI.Label (new Rect (120, 300, 200, 100), "Player Current Health: " + playerHealth.currentHealth);
			playerHealth.currentHealth = (int)GUI.HorizontalSlider (new Rect (120, 320, 380, 10), playerHealth.currentHealth, 0, playerHealth.startingHealth);

			GUI.Label (new Rect (120, 340, 200, 100), "Player Current Stamina: " + playerStamina.currentStamina);
			playerStamina.currentStamina = (int)GUI.HorizontalSlider (new Rect (120, 360, 380, 10), playerStamina.currentStamina, 0, playerStamina.startingStamina);

			GUI.Label (new Rect(120, 380, 200, 100), "Player Attack Damage: " + playerControl.currentDamage);
			playerControl.currentDamage = (int) GUI.HorizontalSlider (new Rect(120, 400, 380, 10), playerControl.currentDamage, 0, 500);

			GUI.Label (new Rect(120, 420, 200, 100), "Player Move Speed: " + playerControl.speed);
			playerControl.speed = (int) GUI.HorizontalSlider (new Rect(120, 440, 380, 10), playerControl.speed, 0 , 500);

			GUI.Label (new Rect(120, 460, 200, 100), "Player Defense:  " + playerControl.currentDefense);
			playerControl.currentDefense = (int) GUI.HorizontalSlider (new Rect(120, 480, 380, 10), playerControl.currentDefense, 0 , 500);

			GUI.Label(new Rect(120, 500, 200, 100), "Enemy Max Health: " + enemyHealth.startingHealth);
			enemyHealth.startingHealth = (int) GUI.HorizontalSlider(new Rect(120, 520, 380, 10), enemyHealth.startingHealth,0, 500);

			GUI.Label(new Rect(120, 540, 200, 100), "Enemy Current Health: " + enemyHealth.currentHealth);
			enemyHealth.currentHealth = (int) GUI.HorizontalSlider(new Rect(120, 560, 380, 10), enemyHealth.currentHealth, 0,enemyHealth.startingHealth);

			GUI.Label(new Rect(120, 580, 200, 100), "Enemy Attack Damage: " + enemyWeapon.attackDamage);
			enemyWeapon.attackDamage = (int) GUI.HorizontalSlider(new Rect(120, 600, 380, 10), enemyWeapon.attackDamage, 0, 500);


			playerHealth.healthSlider.value = playerHealth.currentHealth;
			playerHealth.healthSlider.maxValue = playerHealth.startingHealth;
			playerStamina.staminaSlider.value = playerStamina.currentStamina;
			playerStamina.staminaSlider.maxValue = playerStamina.startingStamina;
		} 
	}
	// Use this for initialization
	void Start () {
		isToolActivate = false;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.G) && isToolActivate == false) {
			isToolActivate = true;
		} else if (Input.GetKeyDown(KeyCode.G) && isToolActivate == true) {
			isToolActivate = false;
		}
	}
}

﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int startingHealth = 100;
	public int currentHealth;
	public Slider healthSlider;
	public Image damageImage;
	public float flashSpeed = 5f;
	public Color flashColor = new Color(1f,0f,0f,0.1f);

	Animator anim;
	PlayerControl playerControl;
	PlayerStamina playerStamina;
	bool isDead;
	bool damaged;

	void Awake(){

		anim = GetComponent<Animator> ();
		playerControl = GetComponent<PlayerControl> ();

		currentHealth = startingHealth;
	}

	void Update(){
		
		if (damaged) {
			damageImage.color = flashColor;
		} else {
			damageImage.color = Color.Lerp(damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		damaged = false;
	}

	public void TakeDamage(int amount){
		damaged = true;

		currentHealth -= amount;

		healthSlider.value = currentHealth;

		if (currentHealth <= 0 && !isDead) {
			Death();
		}
	}

	void Death(){
		isDead = true;
		anim.SetTrigger ("Die");
		playerControl.enabled = false;
	}
}

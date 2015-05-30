using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {
	public NavMeshAgent navMeshAgent;
	public int startingHealth = 100;
	public int currentHealth;
	public float sinkSpeed = 5f;

	EnemyManager enemyManager;
	PlayerControl playerControl;
	GameObject player, enemy;
	Animator anim;
	bool isDead;
	bool isSinking;

	void Awake(){
		anim = GetComponent<Animator> ();
		currentHealth = startingHealth;
		player = GameObject.FindGameObjectWithTag ("Player");
		playerControl = player.GetComponent<PlayerControl> ();
		enemy = GameObject.Find ("EnemySpawnPoints");
		enemyManager = enemy.GetComponent<EnemyManager> ();
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (isSinking) {
			transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
		}

		if (currentHealth <= 0 && !isDead) {
			Death();
		}
	}

	void OnTriggerStay(){
		return;
	}

	void Death(){

		isDead = true;
		isSinking = true;
		navMeshAgent.Stop ();
		GetComponent<Rigidbody> ().isKinematic = true;
		anim.SetTrigger ("Die");
		GetComponent<EnemyAI> ().enabled = false;
		Destroy (gameObject,2f);
		enemyManager.count -= 1;
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Kunai") {
			currentHealth -= playerControl.currentDamage;
			Destroy(col.gameObject);
		}
	}
}

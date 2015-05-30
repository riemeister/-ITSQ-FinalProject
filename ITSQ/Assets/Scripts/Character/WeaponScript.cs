using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {
	public float speed = 10.0f;
 	EnemyHealth enemyHealth;
 	PlayerControl playerControl;
	GameObject player;
	GameObject enemy;

	// Use this for initialization
	void Start () {
		this.StartCoroutine (this.DelayDestroy ());
		player = GameObject.FindGameObjectWithTag ("Player");
		enemy = GameObject.FindGameObjectWithTag ("Enemy");
		enemyHealth = enemy.GetComponent<EnemyHealth> ();
		playerControl = player.GetComponent<PlayerControl> ();

	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * speed);
//		Destroy(gameObject,2f);
	}

	private IEnumerator DelayDestroy() {
		yield return new WaitForSeconds(2.0f); //TEMPORARY. Destroy projectile after 2.0 seconds. Should destroy projectile upon hit.
		GameObject.Destroy (this.gameObject);
	}

//	void OnCollisionEnter(Collision col){
//		if (col.gameObject.tag == "Enemy") {
//			enemyHealth.currentHealth -= playerControl.currentDamage;
//			//EnemyHealth eh = enemy.GetComponent<EnemyHealth>();
//			//PlayerControl pC  = player.GetComponent<PlayerControl>();
////			enemyHealth.currentHealth -= playerControl.currentDamage;
//			//eh.currentHealth -= pC.currentDamage;
////			Destroy(col.gameObject);
//			Destroy(gameObject);
//		}
//	}
}
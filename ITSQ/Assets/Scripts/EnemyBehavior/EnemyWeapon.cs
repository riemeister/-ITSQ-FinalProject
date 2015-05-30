using UnityEngine;
using System.Collections;

public class EnemyWeapon : MonoBehaviour {
	public float speed = 10.0f;
	public int attackDamage = 20;

	GameObject player;
	PlayerHealth playerHealth;
	// Use this for initialization
	void Start () {
		this.StartCoroutine (this.DelayDestroy ());
		player = GameObject.FindGameObjectWithTag ("Player");
		playerHealth = player.GetComponent<PlayerHealth> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * speed);
		
	}
	
	private IEnumerator DelayDestroy() {
		yield return new WaitForSeconds(2.0f); //TEMPORARY. Destroy projectile after 2.0 seconds. Should destroy projectile upon hit.
		GameObject.Destroy (this.gameObject);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			if (playerHealth.currentHealth > 0) {
				playerHealth.TakeDamage(attackDamage);
			}
			Destroy(gameObject);
		}
	}
}

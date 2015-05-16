using UnityEngine;
using System.Collections;

public class WeaponScript : MonoBehaviour {
	public float speed = 20.0f;
	// Use this for initialization
	void Start () {
		this.StartCoroutine (this.DelayDestroy ());
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * speed);

	}

	private IEnumerator DelayDestroy() {
		yield return new WaitForSeconds(2.0f); //TEMPORARY. Destroy projectile after 2.0 seconds. Should destroy projectile upon hit.
		GameObject.Destroy (this.gameObject);
	}
}
using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour {
	public GameObject Weapon;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Fire1")) {
			Instantiate(Weapon,transform.position,transform.rotation);
		}
	}
}

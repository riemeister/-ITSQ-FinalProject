using UnityEngine;
using System.Collections;

public class BoosterSpawn : MonoBehaviour {

	public GameObject Cube;
	GameObject respawnPoint;

	public float timer = 10.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject.Find ("respawnPoint");
		Debug.Log (timer);
		timer ++;
		if (timer == 30) {
			Instantiate (Cube, new Vector3 (Random.Range (0, 1500), 0, (Random.Range (0, 1500))), transform.rotation);
		}
	}
}

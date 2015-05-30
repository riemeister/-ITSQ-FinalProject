using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour {
	
	public PlayerHealth playerHealth;
	public GameObject enemy;
	public float spawnTime = 5f;
	public Transform[] spawnPoints;

	public int count;
	int maxCount = 19;

	// Use this for initialization
	void Start () {
		count = 0;
		InvokeRepeating ("Spawn", spawnTime, spawnTime);

	}

	void Spawn () {

		if (count <= maxCount) {
			count ++;
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
		}
	}
}
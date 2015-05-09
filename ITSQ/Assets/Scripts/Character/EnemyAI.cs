using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

	[SerializeField] private NavMeshAgent navMeshAgent;
	[SerializeField] private Transform target;

	private Transform playerLocation;

	// Use this for initialization
	void Start () {
		this.playerLocation = GameObject.FindObjectOfType<PlayerControl> ().transform;
	}
	
	// Update is called once per frame
	void Update () {
		this.navMeshAgent.SetDestination (this.target.position);
	}
}

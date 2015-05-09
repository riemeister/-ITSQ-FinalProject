﻿using UnityEngine;
using System.Collections;

/// <summary>
/// The brain of the enemy
/// </summary>
public class EnemyAI : MonoBehaviour, IPauseCommand, IResumeCommand {

	[SerializeField] private NavMeshAgent navMeshAgent;
	[SerializeField] private Transform target;
	[SerializeField] private EnemyTriggerRadius enemyTriggerRadius;

	private Transform playerLocation;

	public enum EnemyState {
		ACTIVE,
		RESTRICTED
	}

	public enum EnemyActionType {
		IDLE,
		PATROLLING,
		CHASING,
		SHOOTING,
	}

	private EnemyState currentEnemyState = EnemyState.ACTIVE;
	private EnemyActionType currentActionType = EnemyActionType.IDLE;

	private bool playerInSight = false;
	private Vector3 lastPlayerSighting = Vector3.zero;

	private bool shouldWait = false;

	// Use this for initialization
	void Start () {
		this.playerLocation = GameObject.FindObjectOfType<PlayerControl> ().transform;
		this.StartCoroutine (this.DelaySwitchAction (1.0f, EnemyActionType.PATROLLING, this.TransitionToPatrolling));

		this.enemyTriggerRadius.SetOnTriggerDelegate (this.HandleTriggerEnter, this.HandleTriggerStay, this.HandleTriggerExit);
		GamePauseHandler.Instance.AttachClassToVisit (this, this);
	}
	
	// Update is called once per frame
	void Update () {
		switch (this.currentEnemyState) {
		case EnemyState.ACTIVE:
			this.HandleEnemyAction();
			break;
		case EnemyState.RESTRICTED:
			//do nothing
			break;
		}
	}

	private void HandleEnemyAction() {
		switch (this.currentActionType) {
		case EnemyActionType.IDLE:
			//do nothing
			break;
		case EnemyActionType.PATROLLING:
			if(this.navMeshAgent.remainingDistance <= EnemyConstants.PATROL_STOPPING_DISTANCE) {
				this.TransitionToIdle();
			}
			break;
		case EnemyActionType.CHASING:
			break;
		case EnemyActionType.SHOOTING: 
			break;
		}

		//Debug.Log ("Enemy action type: " + this.currentActionType);
	}

	/// <summary>
	/// Transitions to patrolling state.
	/// </summary>
	private void TransitionToPatrolling() {
		this.target = EnemyPatrolPointDirectory.Instance.GetRandomPatrolPoint ();
		this.navMeshAgent.SetDestination (this.target.position);
		this.navMeshAgent.speed = EnemyConstants.PATROL_SPEED;
	}

	/// <summary>
	/// Transitions to idle state. Automatically transitions to patrol state if no further action is triggered.
	/// </summary>
	private void TransitionToIdle() {
		this.currentActionType = EnemyActionType.IDLE;
		this.navMeshAgent.ResetPath ();
		this.StartCoroutine (this.DelaySwitchAction (2.0f, EnemyActionType.PATROLLING, this.TransitionToPatrolling));
	}

	private void TransitionToChasing() {
		this.currentActionType = EnemyActionType.CHASING;
		this.navMeshAgent.speed = EnemyConstants.CHASE_SPEED;
	}

	private void HandleTriggerEnter(Collider other) {
		PlayerControl playerControl = other.gameObject.GetComponent<PlayerControl> ();

		if (playerControl != null) {

		}
	}

	/// <summary>
	/// Handles the trigger event. This is used to check if the trigger event was caused by the player. This means that the player may be in sight for the enemy
	/// </summary>
	/// <param name="other">Other.</param>
	private void HandleTriggerStay(Collider other) {
		PlayerControl playerControl = other.gameObject.GetComponent<PlayerControl> ();

		if (playerControl != null) {
			this.playerInSight = false;

			// Create a vector from the enemy to the player and store the angle between it and forward.
			Vector3 direction = other.transform.position - transform.position;
			float angle = Vector3.Angle(direction, transform.forward);
			
			// If the angle between forward and where the player is, is less than half the angle of view...
			if(angle < EnemyConstants.FIELD_OF_VIEW_ANGLE * 0.5f)
			{
				RaycastHit hit;
				// ... and if a raycast towards the player hits something...
				if(Physics.Raycast(transform.position + transform.up, direction.normalized, out hit))
				{

					// ... and if the raycast hits the player...
					if(hit.collider.gameObject == playerControl.gameObject)
					{
						// ... the player is in sight.
						this.playerInSight = true;

						Debug.Log("Player can be seen by " +this.gameObject.name);
						this.lastPlayerSighting = playerControl.transform.position;

						this.TransitionToChasing();
						this.navMeshAgent.SetDestination(this.lastPlayerSighting);

						if(this.navMeshAgent.remainingDistance <= EnemyConstants.CHASE_STOPPING_DISTANCE) {
							this.navMeshAgent.Stop();
						}
						else {
							this.navMeshAgent.Resume();
						}
					}
				}
			}
		}
	}

	private void HandleTriggerExit(Collider other) {
		PlayerControl playerControl = other.gameObject.GetComponent<PlayerControl> ();
		
		if (playerControl != null) {
			this.playerInSight = false;
			this.TransitionToIdle();
		}
	}
	
	private IEnumerator DelaySwitchAction(float seconds, EnemyActionType actionType, System.Action transitionFunction) {
		yield return new WaitForSeconds (seconds);
		transitionFunction ();
		this.currentActionType = actionType;
	}
	
	public void Pause() {
		this.currentEnemyState = EnemyState.RESTRICTED;
	}

	public void Resume() {
		this.currentEnemyState = EnemyState.ACTIVE;
	}

	public EnemyActionType GetEnemyActionType() {
		return this.currentActionType;
	}
}

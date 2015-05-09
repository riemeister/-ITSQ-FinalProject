using UnityEngine;
using System.Collections;

/// <summary>
/// The brain of the enemy
/// </summary>
public class EnemyAI : MonoBehaviour, IPauseCommand, IResumeCommand {

	[SerializeField] private NavMeshAgent navMeshAgent;
	[SerializeField] private Transform target;

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
	private EnemyActionType currentActionType =EnemyActionType.IDLE;

	// Use this for initialization
	void Start () {
		this.playerLocation = GameObject.FindObjectOfType<PlayerControl> ().transform;
		this.StartCoroutine (this.DelaySwitchAction (1.0f, EnemyActionType.PATROLLING, this.TransitionToPatrolling));
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
			if(this.navMeshAgent.remainingDistance <= 5.0f) {
				this.TransitionToIdle();
			}
			break;
		case EnemyActionType.CHASING:
			break;
		case EnemyActionType.SHOOTING: 
			break;
		}

		Debug.Log ("Enemy action type: " + this.currentActionType);
	}

	/// <summary>
	/// Transitions to patrolling state.
	/// </summary>
	private void TransitionToPatrolling() {
		this.target = EnemyPatrolPointDirectory.Instance.GetRandomPatrolPoint ();
		this.navMeshAgent.SetDestination (this.target.position);
	}

	/// <summary>
	/// Transitions to idle state. Automatically transitions to patrol state if no further action is triggered.
	/// </summary>
	private void TransitionToIdle() {
		this.currentActionType = EnemyActionType.IDLE;
		this.StartCoroutine (this.DelaySwitchAction (2.0f, EnemyActionType.PATROLLING, this.TransitionToPatrolling));
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

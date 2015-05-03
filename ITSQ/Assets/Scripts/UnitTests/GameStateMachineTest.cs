using UnityEngine;
using System.Collections;

/// <summary>
/// Game state machine test.
/// </summary>
public class GameStateMachineTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameStateMachine.Instance.ChangeState (GameStateMachine.StateType.MAIN_GAME);

		this.StartCoroutine (this.StartMachineTest ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	private IEnumerator StartMachineTest() {
		yield return new WaitForSeconds (1.0f);
		GameStateMachine.Instance.ChangeState (GameStateMachine.StateType.POST_GAME);

		yield return new WaitForSeconds (1.0f);
		GameStateMachine.Instance.ChangeState (GameStateMachine.StateType.END);
	}
}

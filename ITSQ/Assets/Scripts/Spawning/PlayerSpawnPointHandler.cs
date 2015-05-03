using UnityEngine;
using System.Collections;

/// <summary>
/// Handles where the player should spawn in the plane.
/// </summary>
public class PlayerSpawnPointHandler : MonoBehaviour {

	[SerializeField] private Transform player;
	[SerializeField] private Transform[] spawnPoints;

	private const float Y_OFFSET = 40.0f;

	// Use this for initialization
	void Start () {
		EventBroadcaster.Instance.AddObserver (EventNames.ON_TRIGGER_PLAYER_SPAWN, this.TriggerPlayerSpawn);
	}

	void OnDestroy() {
		EventBroadcaster.Instance.RemoveActionAtObserver (EventNames.ON_TRIGGER_PLAYER_SPAWN, this.TriggerPlayerSpawn);
	}

	private void TriggerPlayerSpawn() {
		int index = Random.Range (0, this.spawnPoints.Length);

		Vector3 newPosition = this.spawnPoints [index].position;
		newPosition.y += Y_OFFSET;

		this.player.position = newPosition;
		this.player.rotation = this.spawnPoints [index].rotation;
	}
}

using UnityEngine;
using System.Collections;

/// <summary>
/// Handles spawning of items with a specified interval
/// </summary>
public class ItemSpawnHandler : MonoBehaviour {
	[SerializeField] private float refreshInterval = 15.0f;

	[SerializeField] private PickableItem[] spawnableItems;
	[SerializeField] private Transform[] spawnPoints;
	[SerializeField] private Transform itemsContainer;

	[SerializeField] private GenericCountdownTimer refreshTimer;

	BasePotions.PotionTypes potionType;
	BaseBoosters.BoosterTypes boosterType;
	BaseWeapon.WeaponTypes weaponType;

	private const float Y_OFFSET = 15.0f;

	private ArrayList occupiedSpawnPoints = new ArrayList();

	// Use this for initialization
	void Start () {
		EventBroadcaster.Instance.AddObserver (EventNames.ON_INITIALIZE_ITEM_SPAWN, this.Initialize);
	}

	void OnDestroy() {
		EventBroadcaster.Instance.RemoveActionAtObserver (EventNames.ON_TRIGGER_PLAYER_SPAWN, this.Initialize);
	}

	public void Initialize() {
		this.refreshTimer.SetDuration (this.refreshInterval);
		this.refreshTimer.AddFinishAction (this.SpawnNewItem);
		this.SpawnNewItem ();
	}

	public void SpawnNewItem() {

		if (this.HasEmptySpawnPoint () == false) {
			return;
		}

		int itemIndex = Random.Range (0, this.spawnableItems.Length);
		int spawnPointIndex = this.FindEmptySpawnPoint ();

		//spawn item
		GameObject spawnedItem = GameObject.Instantiate (this.spawnableItems [itemIndex].gameObject);
		spawnedItem.transform.parent = this.itemsContainer;
		
		BasePotions.PotionTypes potionType = (BasePotions.PotionTypes)Random.Range (0,2);
		BaseBoosters.BoosterTypes boosterType = (BaseBoosters.BoosterTypes)Random.Range (0, 3);
		BaseWeapon.WeaponTypes weaponType = (BaseWeapon.WeaponTypes)Random.Range (0, 6);
		Vector3 spawnPosition = this.spawnPoints [spawnPointIndex].position;
		spawnPosition.y += Y_OFFSET;

		spawnedItem.transform.position = spawnPosition;

		this.occupiedSpawnPoints.Add (spawnPointIndex);

		//restart the timer.
		this.refreshTimer.StartTimer ();
	}

	public bool HasEmptySpawnPoint() {
		return (this.occupiedSpawnPoints.Count < this.spawnPoints.Length);
	}

	public int FindEmptySpawnPoint() {
		int whileLimit = this.spawnPoints.Length; int limit = 0;
		int spawnPointIndex = Random.Range (0, this.spawnPoints.Length);

		while (this.occupiedSpawnPoints.Contains (spawnPointIndex) && limit != whileLimit) {
			spawnPointIndex = Random.Range (0, this.spawnPoints.Length);
			limit++;
		}

		return spawnPointIndex;
	}
}

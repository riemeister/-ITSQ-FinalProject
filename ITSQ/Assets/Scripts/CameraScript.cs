using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {
//	GameObject player;
//	private float rotationSpeed = 10.0f;
//	private bool rotating = false;

	public GameObject target;
	public float rotateSpeed = 5;
	Vector3 offset;
	bool rotating = false;

	// Use this for initialization
	void Start () {
//		player = GameObject.Find("Player");
		offset = target.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
//		transform.LookAt (target.transform);
//		transform.position = new Vector3 (target.transform.position.x, target.transform.position.y+80, target.transform.position.z-200);
	}

	void LateUpdate(){
		if (Input.GetMouseButtonDown (1)) {
			this.rotating = true;
		} else if (Input.GetMouseButtonUp (1)) {
			this.rotating = false;
		}
		if (this.rotating) {
			float horizontal = Input.GetAxis ("Mouse X") * rotateSpeed;
			target.transform.Rotate (0, horizontal, 0);
		}
		float desiredAngle = target.transform.eulerAngles.y;
		Quaternion rotation = Quaternion.Euler (0, desiredAngle, 0);
		transform.position = target.transform.position - (rotation * offset);
		
		transform.LookAt (target.transform);
	}
}

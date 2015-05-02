using UnityEngine;
using System.Collections;

public class CharacterMovements : MonoBehaviour {

	public float moveSpeed = 100.0f;

	private CharacterController controller;

	// Use this for initialization
	void Start () {
		this.controller = this.GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey ("w")) {
			transform.Translate((Vector3.forward) * moveSpeed * Time.deltaTime);
			//this.controller.Move(Vector3.forward * moveSpeed * Time.deltaTime);
		}
		if (Input.GetKey ("s")) {
			transform.Translate((Vector3.back) * moveSpeed * Time.deltaTime);
			//this.controller.Move(Vector3.back * moveSpeed * Time.deltaTime);
		}
		if (Input.GetKey ("a")) {
			transform.Rotate(Vector3.down * moveSpeed * Time.deltaTime);
			//this.controller.Move(Vector3.left * moveSpeed * Time.deltaTime);
		}
		if (Input.GetKey ("d")) {
			transform.Rotate(Vector3.up * moveSpeed * Time.deltaTime);
			//this.controller.Move(Vector3.right * moveSpeed * Time.deltaTime);
		}

		if (Input.GetKeyDown (KeyCode.LeftShift)) {
			moveSpeed = 200.0f;
		} else if (Input.GetKeyUp (KeyCode.LeftShift)) {
			moveSpeed = 100.0f;
		}
	}
}

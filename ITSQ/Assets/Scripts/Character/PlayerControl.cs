using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

	/// This script moves the character controller forward 
	/// and sideways based on the arrow keys.
	/// It also jumps when pressing space.
	/// Make sure to attach a character controller to the same game object.
	/// It is recommended that you make only one call to Move or SimpleMove per frame.	
	
	[SerializeField] private float speed = 200.0f;
	[SerializeField] private float jumpSpeed = 200.0f;
	[SerializeField] private float gravity = 150.0f;
	[SerializeField] private float rotationSpeed = 10.0f;
	
	private Vector3 moveDirection = Vector3.zero;
	private CharacterController controller;

	private bool rotateable = false;

	void Start() {
		this.controller = this.GetComponent<CharacterController> ();
	}
	void Update() {
		if (controller.isGrounded) {
			moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			moveDirection = transform.TransformDirection (moveDirection);
			moveDirection *= speed;
			if (Input.GetButton ("Jump"))
				moveDirection.y = jumpSpeed;
			
		}

		if (Input.GetMouseButtonDown (1)) {
			this.rotateable = true;
		} else if (Input.GetMouseButtonUp (1)) {
			this.rotateable = false;
		}

		if (this.rotateable) {
			float rotation = Input.GetAxis("Mouse X") * this.rotationSpeed;;
			transform.Rotate(0,rotation, 0);
		}

		moveDirection.y -= gravity * Time.deltaTime;
		controller.Move(moveDirection * Time.deltaTime);

	}
}

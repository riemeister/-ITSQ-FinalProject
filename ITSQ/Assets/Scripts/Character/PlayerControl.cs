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
	[SerializeField] private GameObject weapon;
	
	private Vector3 moveDirection = Vector3.zero;
	private CharacterController controller;

	private bool rotating = false;

	public enum CharacterState {
		CONTROLLABLE,
		RESTRICTED
	}

	public enum CharacterStance {
		NORMAL,
		SPRINT,
		CROUCH
	}

	private CharacterState currentCharacterState = CharacterState.CONTROLLABLE;
	private CharacterStance currentStance = CharacterStance.NORMAL;

	void Start() {
		this.controller = this.GetComponent<CharacterController> ();
	}
	void Update() {

		switch (this.currentCharacterState) {
		case CharacterState.CONTROLLABLE:
			this.HandleMovement();
			this.HandleFire();
			break;

		case CharacterState.RESTRICTED:
			//do nothing
			return;
		}

		this.UpdateCameraView ();

	}

	private void UpdateCameraView() {
		if (Input.GetMouseButtonDown (1)) {
			this.rotating = true;
		} else if (Input.GetMouseButtonUp (1)) {
			this.rotating = false;
		}
		
		if (this.rotating) {
			float rotation = Input.GetAxis("Mouse X") * this.rotationSpeed;;
			transform.Rotate(0,rotation, 0);
		}
	}

	private void HandleMovement() {
		if (this.controller.isGrounded) {
			this.moveDirection = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"));
			this.moveDirection = transform.TransformDirection (moveDirection);
			this.moveDirection *= speed;
			if (Input.GetButton ("Jump"))
				this.moveDirection.y = jumpSpeed;
			
		}
		this.moveDirection.y -= gravity * Time.deltaTime;
		this.controller.Move(moveDirection * Time.deltaTime);
	}

	private void HandleFire() {
		if (Input.GetButtonDown ("Fire1")) {
			Instantiate(this.weapon,transform.position,transform.rotation);
		}
	}
}

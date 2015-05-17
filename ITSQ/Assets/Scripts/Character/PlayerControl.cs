using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour, IPauseCommand, IResumeCommand {

	/// This script moves the character controller forward 
	/// and sideways based on the arrow keys.
	/// It also jumps when pressing space.
	/// Make sure to attach a character controller to the same game object.
	/// It is recommended that you make only one call to Move or SimpleMove per frame.	
	
	[SerializeField] private float speed = 100.0f;
	[SerializeField] private float jumpSpeed = 150.0f;
	[SerializeField] private float gravity = 500.0f;
	[SerializeField] private float rotationSpeed = 10.0f;

	public int attackDamage = 20;

	Animator anim;
	Rigidbody playerRigidBody;
	GameObject player;
	PlayerStamina playerStamina;

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

	void Awake(){
		anim = GetComponent<Animator> ();
		player = GameObject.FindGameObjectWithTag ("Player");
		playerStamina = player.GetComponent<PlayerStamina> ();
		playerRigidBody = GetComponent<Rigidbody> ();

	}

	void Start() {
		this.controller = this.GetComponent<CharacterController> ();
		GamePauseHandler.Instance.AttachClassToVisit (this, this);
	}

	void FixedUpdate(){
		float h = Input.GetAxis ("Horizontal");
		float v = Input.GetAxis ("Vertical");
		Animating(h,v);
	}

	void Update() {

		switch (this.currentCharacterState) {
		case CharacterState.CONTROLLABLE:
			this.HandleMovement();
			this.HandleFire();
			this.UpdateCameraView ();
			break;

		case CharacterState.RESTRICTED:
			//do nothing
			break;
		}
	}

	private void UpdateCameraView() {
		if (Input.GetMouseButtonDown (1)) {
			this.rotating = true;
		} else if (Input.GetMouseButtonUp (1)) {
			this.rotating = false;
		}
		
		if (this.rotating) {
			float rotation = Input.GetAxis("Mouse X") * this.rotationSpeed;
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

	public void HandleFire() {
		if (Input.GetButton ("Fire1")) {
			bool attack = true;
			anim.SetBool ("IsAttacking", attack);
			//Instantiate (this.weapon, transform.position, transform.rotation);
			playerStamina.currentStamina -= 0.5f;
		} else {
			bool attack = false;
			anim.SetBool("IsAttacking", attack);
		}
	}

	public void Pause() {
		this.currentCharacterState = CharacterState.RESTRICTED;
	}

	public void Resume() {
		this.currentCharacterState = CharacterState.CONTROLLABLE;
	}

	void Animating(float h, float v){
		bool running = h != 0f || v != 0f;
		anim.SetBool ("IsRunning", running);
	}
}

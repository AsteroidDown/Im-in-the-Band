using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	// Movement
	[Header("Movement")]
	public float moveSpeed;
	public float externalMove;
	public float jumpHeight;
	private float moveVelocity;

	[Header("Jump Stuff")]
	// Hangtime
	public float hangTime = 0.5f;
	private float hangCounter;
	// Jump buffer
	public float jumpBufferLength;
	private float jumpBufferCount;
	// External jump control
	public bool jumpButton;
	private float jumpReleaseCount;

	[Header("Ground Check")]
	// Finding the ground
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	// Stats
	private static float speedStat;
	private static float jumphStat;

	// Player body
	private Rigidbody2D playerBody;

	// Animation
	private Animator anim;

	// Sounds
	public AudioSource jumpSound; 

	// Use this for initialization
	void Start () {
		playerBody = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator>();
	}
	
	// Updates less frequently
	void FixedUpdate() {

		// Check if player is on the ground
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
	}

	// Update is called once per frame
	void Update () {

		// Check if game is paused
		if (!StateManager.GetPaused()) {

			// Controls for jump button UI
			if (jumpButton) 
				jumpReleaseCount = 0.1f;
			else
				jumpReleaseCount -= Time.deltaTime;

			//  Hangtime Manage
			if (grounded)
				hangCounter = hangTime;
			else {
				if (Input.GetButtonDown("Jump") || jumpButton)
					hangCounter = 0;
				hangCounter -= Time.deltaTime;
			}

			// Jump buffer manage
			if (Input.GetButtonDown("Jump") || jumpButton) {
				jumpBufferCount = jumpBufferLength;
			} else {
				jumpBufferCount -= Time.deltaTime;
			}

			// Better Jump
			if (jumpBufferCount > 0 && hangCounter >= 0) {
				Jump();
				jumpBufferCount = 0;
			}

			// Short jump
			if ((Input.GetButtonUp("Jump") || (!jumpButton && jumpReleaseCount >= 0)) && playerBody.velocity.y > 0) {
				playerBody.velocity = new Vector2(playerBody.velocity.x, playerBody.velocity.y * 0.5f);
			}

			// Better control move
			if (externalMove == -1 || externalMove == 1) 
				moveVelocity = (moveSpeed + speedStat) * externalMove;
			else 
				moveVelocity = (moveSpeed + speedStat) * Input.GetAxisRaw("Horizontal");
			Mathf.Clamp(moveVelocity, -1f, 1f);
			
			// Update movement
			playerBody.velocity = new Vector2(moveVelocity, playerBody.velocity.y);
			
			// Set animoation protocols
			//anim.SetFloat("Speed", Mathf.Abs(playerBody.velocity.x));
			//anim.SetBool("Grounded", grounded);

			// Player direction
			if (playerBody.velocity.x > 0)
				transform.localScale = new Vector3(1f, 1f, 1f);
			if (playerBody.velocity.x < 0)
				transform.localScale = new Vector3(-1f, 1f, 1f);
		}
	}

	// Jump controlls
	public void Jump() {

		playerBody.velocity = new Vector2(playerBody.velocity.x, jumpHeight + jumphStat);
		//jumpSound.Play();
	}

	// Update movement stats
	public static void StatChange() {
		speedStat = StatsManager.speed / 2f;
		jumphStat = StatsManager.jumph / 2f;
	}
}
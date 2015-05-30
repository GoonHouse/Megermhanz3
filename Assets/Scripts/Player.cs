using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public Weapon weapon;
	public BoxCollider2D jumpBox;

	public float speed;
	public float jumpForce;
	
	public int jumps = 0;
	public int maxJumps = 3;
	
	private bool grounded = false;
	
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateControls ();
	}

	void UpdateControls() {
		// left / right movement
		rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);

		// jump related activities
		grounded = jumpBox.IsTouchingLayers (LayerMask.GetMask ("Ground"));

		if (Input.GetAxis ("Vertical") > 0.5f) {
			Jump();
		}

		// shooting
		if (Input.GetButton ("Fire1")) {
			weapon.Shoot();
		}
	}

	void Jump() {
		if (grounded) {
			// @WARNING: This works, but sometimes grounded is true while still trying to move
			// the player, resulting in a giant bounce depending on how long they're in contact
			// with the ground for. Personally, I found it hilarious, so I am leaving it for now.
			Vector2 jumpVector = new Vector2(0, jumpForce);
			rb.AddForce(jumpVector);
		}
	}
}
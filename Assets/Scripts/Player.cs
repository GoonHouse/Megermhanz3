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
	private Animator anim;

	private float shotTimer = 0f;
	public float shotVal = 3f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		UpdateControls ();
		AnimationUpdate ();
	}

	void UpdateControls() {
		shotTimer -= Time.deltaTime;

		// left / right movement
		rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);

		// jump related activities
		grounded = jumpBox.IsTouchingLayers (LayerMask.GetMask ("Ground"));

		if (Input.GetAxis ("Vertical") > 0.5f) {
			Jump();
		}

		// shooting
		if (Input.GetButtonDown ("Fire1")) {
			SetShooting(weapon.TriggerDown());
		}

		if (Input.GetButton ("Fire1")) {
			SetShooting(weapon.TriggerHold());
		}

		if (Input.GetButtonUp ("Fire1")) {
			SetShooting(weapon.TriggerUp ());
		}
	}

	void SetShooting(bool didIShoot) {
		if (didIShoot) {
			shotTimer = shotVal;
		}
	}

	void AnimationUpdate() {
		anim.SetFloat ("speed", Mathf.Abs(Input.GetAxis ("Horizontal")));
		if (shotTimer > 0) {
			anim.SetBool ("shoot", true);
		} else {
			anim.SetBool ("shoot", false);
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

	public bool ChangeWeapon(GameObject newWeapon) {
		// destroy the current weapon
		// @TODO: Have some sort of "inventory" for active / in-active weapons
		GameObject anchor = transform.Find ("WeaponAnchor").gameObject;
		Destroy (anchor.transform.GetChild(0));
		// set the object to belong to the player
		newWeapon.transform.parent = anchor.transform;
		newWeapon.transform.localPosition = new Vector3 (0.0f, 0.0f, 0.0f);
		// tell the player to work with the object
		weapon = newWeapon.GetComponent<Weapon> ();
		return true;
	}
}
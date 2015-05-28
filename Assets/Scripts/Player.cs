using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	[HideInInspector]
	Controller controller;

	public GameObject bullet;

	public BoxCollider2D jumpBox;

	// Use this for initialization
	void Start () {
		controller = new Controller ();
	}
	
	// Update is called once per frame
	void Update () {
		Controls ();
		Movement ();
		Shoot ();
	}

	void Controls() {
		//Left
		if (Input.GetKeyDown(KeyCode.LeftArrow)) {
			controller.Left=true;
		} else {
			controller.Left=false;
		}
		//Right
		if (Input.GetKeyDown(KeyCode.RightArrow)) {
			controller.Right=true;
		} else {
			controller.Right=false;
		}
		//Up
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			controller.Up = true;
		} else {
			controller.Up = false;
		}
		//SHOOT THE BULLETS
		if (Input.GetKeyDown (KeyCode.Z)) {
			controller.Shoot = true;
		}
	}

	void Movement() {
		float newPosX = transform.position.x;

		if (controller.Left) {
			newPosX -= 5;
		}

		if (controller.Right) {
			newPosX += 5;
		}

		if (controller.Up) {
			Jump();
		}

		transform.position = new Vector2 (newPosX, transform.position.y);
	}

	void Shoot() {
		if (controller.Shoot == false) {
			return;
		}

		Instantiate(bullet, 
		            new Vector3(
						transform.position.x + 3f, 
						transform.position.y, 
						transform.position.z), 
		            Quaternion.identity);

		controller.Shoot = false;
	}

	void Jump() {
		bool grounded = jumpBox.IsTouchingLayers (LayerMask.GetMask ("Ground"));

		if (grounded) {
			transform.Translate (new Vector3 (
				transform.position.x,
				20f,
				transform.position.z
			));
		}
	}
}


class Controller {
	public bool Up = false;
	public bool Left = false;
	public bool Right = false;
	public bool Shoot = false;
}
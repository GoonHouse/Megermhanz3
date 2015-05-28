using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {
		float speed = 5f;
		transform.position = new Vector2 (transform.position.x + speed, transform.position.y);
	}
}

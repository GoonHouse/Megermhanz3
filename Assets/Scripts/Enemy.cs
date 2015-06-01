using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	private int hp;
	private Vector2 start;
	public float distanceVar;
	private Rigidbody2D rb;
	private Vector2 lastC;

	// Use this for initialization
	void Start () {
		//Set starting position
		start = new Vector2 (transform.position.x, transform.position.y);
		lastC = Vector2.zero;
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector2 c = ((Vector2) start - (Vector2) transform.position);
		//Try to return to start
		rb.AddForce(c);
	}

	void Return (Vector2 c) {

	}

	void Hurt () {

	}

	void Die () {

	}
}

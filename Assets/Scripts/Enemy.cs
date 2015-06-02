using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public float distanceVar;


	private Vector2 start;
	private Rigidbody2D rb;
	private HurtHandler hurtHandler;

	// Use this for initialization
	void Start () {
		//Set starting position
		start = new Vector2 (transform.position.x, transform.position.y);
		rb = gameObject.GetComponent<Rigidbody2D> ();
		hurtHandler = gameObject.GetComponent<HurtHandler> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Try to return to start
		rb.AddForce(start - (Vector2) transform.position);
	}
}

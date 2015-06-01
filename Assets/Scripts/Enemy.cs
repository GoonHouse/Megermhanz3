using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public int maxHP;
	public int hp;
	
	public float distanceVar;

	private Vector2 start;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		//Set starting position
		start = new Vector2 (transform.position.x, transform.position.y);
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		//Try to return to start
		rb.AddForce(start - (Vector2) transform.position);
	}

	void Hurt (int amount) {
		if (amount > 0){
			hp -= amount;
		}

		if (hp <= 0){
			Die ("I got shot too much.");
		}
	}

	void Die (string reason) {
		Debug.Log ("I WAS TOO FABULOUS FOR THIS WORLD: " + reason);
	}
}

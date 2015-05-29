using UnityEngine;
using System.Collections;

public enum DamageType {
	Normal,
	Fire,
	Electric
}

public class Projectile : MonoBehaviour {

	public float speed;
	public int damage;
	public DamageType damageType;
	private Rigidbody2D rb;

	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector2(speed, rb.velocity.y);
	}
}

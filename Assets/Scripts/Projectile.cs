using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float speed;
	public int damage;
	public DamageType damageType;
	private Rigidbody2D rb;
	public GameObject owner;

	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		rb.velocity = new Vector2(speed, rb.velocity.y);
	}

	// There are no conditions that can make this wrong.
	public void SetOwner (GameObject newOwner){
		owner = newOwner;
	}

	void OnCollisionEnter2D (Collision2D col) {
		HurtHandler hurtHandler = col.gameObject.GetComponent<HurtHandler> ();
		if(hurtHandler != null && col.gameObject != owner){
			hurtHandler.Hurt(damage, owner, damageType);
			// we could put a callback for successful bullet landing here if we wanted
			Destroy (transform.gameObject);
		}
	}
}
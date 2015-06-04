using UnityEngine;
using System.Collections;

public class TempShield : MonoBehaviour {

	public float speed;
	GameObject owner;
	public DamageType damageType;
	int damage = 5;


	// Use this for initialization
	void Start () {
		owner = GameObject.Find ("Player");
		transform.parent = owner.transform;
		transform.localPosition = new Vector2(transform.localPosition.x + 1.7f, transform.localPosition.y);
	}
	
	// Update is called once per frame
	void Update () {
		transform.RotateAround ( owner.transform.position, Vector3.forward, speed * Time.deltaTime);
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

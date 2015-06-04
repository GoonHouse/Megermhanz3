using UnityEngine;
using System.Collections;

public class StickyBomb : Projectile {

	private bool isAttached = false;
	private Rigidbody2D rb;
	public GameObject explosion;
	public float countDown;
	private bool boomed = false;

	new void Start() {
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}

	new void Update (){
		if (isAttached && !boomed) {
			countDown -= Time.deltaTime;

			if (countDown < 0f) {
				Boom ();
			}
		}

		if (boomed) {
			DestroyImmediate (gameObject);
		}
	}

	new void OnCollisionEnter2D (Collision2D col) {
		if( !isAttached && col.gameObject != owner ){
		//if(col.gameObject != owner && col.gameObject != transform.parent){
			// we could do impact damage, if we were assholes
			Attach (col.gameObject);
		}
	}

	public void Attach (GameObject newParent){
		Debug.Log ("Attached to " + newParent.name);
		transform.parent = newParent.transform;
		rb.isKinematic = true;
		//transform.localScale = new Vector3(1.0f,1.0f,1.0f);
		//transform.localPosition = new Vector3 (0.0f, 0.0f, 0.0f);
		isAttached = true;
	}

	void Boom() {
		GameObject bullet = Instantiate (explosion, transform.position, Quaternion.identity) as GameObject;
		bullet.GetComponent<Projectile>().SetOwner(owner);
		boomed = true;
	}

	void OnDestroy() {
		Boom ();
	}
}

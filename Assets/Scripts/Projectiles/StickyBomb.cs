using UnityEngine;
using System.Collections;

public class StickyBomb : Projectile {

	private float timer = 1;
	private bool isAttached = false;
	private Rigidbody2D rb;

	new void Start() {
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}

	new void Update (){
		Debug.Log ("doin it well?");
		//TODO: Timer until the bomb explodes
		
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
}

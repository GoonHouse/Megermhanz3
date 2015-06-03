using UnityEngine;
using System.Collections;

public class StickyBomb : Projectile {

	private float timer = 1;
	private bool isAttached = false;

	void Update (){

	}

	void OnCollisionEnter2D (Collision2D col) {
		if(col.gameObject != owner && col.gameObject != transform.parent){
			// we could do impact damage, if we were assholes
			Attach (col.gameObject);
		}
	}

	public void Attach (GameObject newParent){
		Debug.Log ("Attached to " + newParent.name);
		transform.parent = newParent.transform;
		transform.localPosition = new Vector3 (0.0f, 0.0f, 0.0f);
		isAttached = true;
	}
}

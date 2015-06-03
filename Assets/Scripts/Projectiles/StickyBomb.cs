using UnityEngine;
using System.Collections;

public class StickyBomb : Projectile {

	private float timer = 1;
	private bool isAttached = false;

	new void Update (){
		Debug.Log ("doin it well?");
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
		transform.localScale = new Vector3(1.0f,1.0f,1.0f);
		//transform.localPosition = new Vector3 (0.0f, 0.0f, 0.0f);
		isAttached = true;
	}
}

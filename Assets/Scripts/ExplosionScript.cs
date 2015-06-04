using UnityEngine;
using System.Collections;

public class ExplosionScript : MonoBehaviour {

	public int damage;
	public DamageType damageType;
	public GameObject owner;
	public float explosionTime;
		
	// Update is called once per frame
	void Update () {
		explosionTime -= Time.deltaTime;

		if (explosionTime < 0f) {
			Destroy (gameObject);
		}
	}
	
	// There are no conditions that can make this wrong.
	public void SetOwner (GameObject newOwner){
		owner = newOwner;
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		HurtHandler hurtHandler = col.gameObject.GetComponent<HurtHandler> ();
		if(hurtHandler != null && col.gameObject != owner){
			hurtHandler.Hurt(damage, owner, damageType);
		}
	}
}
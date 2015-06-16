using UnityEngine;
using System.Collections;

public class HordeBee : Projectile {

	public float distanceTolerance;
	
	private GameObject myHorde;
	private Rigidbody2D rb;
	private Vector2 targetPosition;
	private bool isInHorde;

	void Start (){
		rb = gameObject.GetComponent<Rigidbody2D> ();
		targetPosition = (Vector2) transform.position;
		isInHorde = false;
	}

	// Update is called once per frame
	void Update () {
		if (!isInHorde) {
			if (targetPosition != (Vector2)transform.position) {
				rb.AddForce (targetPosition - (Vector2)transform.position);
			} else {
				isInHorde = myHorde.GetComponent<BeeHorde> ().AddBee (gameObject);
			}
		} else {
			// Debug.Log( "Bees have a horde!" );
		}
	}

	public void SetHorde(GameObject newHorde){
		myHorde = newHorde;
		BeeHorde bh = myHorde.GetComponent<BeeHorde> ();
		targetPosition = bh.GetPositionForBee ();
		this.SetOwner (bh.owner );
	}
}
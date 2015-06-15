using UnityEngine;
using System.Collections;

public class CollectableHandler : MonoBehaviour {

	public int healAmount;

	void OnCollisionEnter2D (Collision2D col) {
		Debug.Log (col.gameObject.name);
		HurtHandler hh = col.gameObject.GetComponent<HurtHandler> ();
		if ( hh != null ) {
			hh.Heal (healAmount);
			Destroy (gameObject);
		}
	}
}

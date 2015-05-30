using UnityEngine;
using System.Collections;

public class WeaponCapsule : MonoBehaviour {

	public GameObject capsuleContent;
	public GameObject capsuleWeapon;

	// Use this for initialization
	void Start () {
		GameObject capsuleObject = (GameObject) Instantiate (capsuleContent, transform.position, Quaternion.identity);
		capsuleObject.transform.parent = this.transform;
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Player") {
			col.gameObject.GetComponentInChildren<Weapon>().ChangeWeapon(capsuleWeapon);
		}
	}
}

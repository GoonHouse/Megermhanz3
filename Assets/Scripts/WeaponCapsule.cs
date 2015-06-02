using UnityEngine;
using System.Collections;

public class WeaponCapsule : MonoBehaviour {

	//public GameObject capsuleContent;
	public GameObject capsuleWeapon;
	private GameObject capsuleContent;

	// Use this for initialization
	void Start () {
		capsuleContent = (GameObject) Instantiate (capsuleWeapon, transform.position, Quaternion.identity);
		capsuleContent.transform.parent = this.transform;
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Player" && capsuleContent != null) {
			// @TODO: Make this a WeaponHandler, kind of like HurtHandler
			col.gameObject.GetComponent<Player>().ChangeWeapon(capsuleContent);
			capsuleContent = null;
		}
	}
}

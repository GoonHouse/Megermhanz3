using UnityEngine;
using System.Collections;

public class NapalmWeapon : Weapon {
	private bool fire;
	public GameObject napalmBullet;
	private int ammoCount;
	new private int ammoPerShot;

	private float shotCount = 0;
	private float shotAllowed = .05f;

	//Interface Stuff
	new public void TriggerUp () {
		fire = false;
	}

	new public void TriggerDown () {
		fire = true;
	}

	// Use this for initialization
	void Start () {
		fire = false;
		ammoCount = 500;
		ammoPerShot = 1;
	}

	new bool HasEnoughAmmo() {
		if (ammoCount - ammoPerShot >= 0) {
			return true;
		}

		fire = false;
		return false;
	}

	bool TimerExpired() {
		if (shotCount < 0f) {
			return true;
		}

		return false;
	}

	// Update is called once per frame
	void Update () {
		shotCount -= Time.deltaTime;
		if (fire) {
			Shoot ();
		}
	}

	new void Shoot() {
		if (HasEnoughAmmo () && TimerExpired ()) {
			Debug.Log ("SHOOTING");
			GameObject bul = Instantiate(napalmBullet, transform.position, Quaternion.identity) as GameObject;
			bul.gameObject.GetComponent<Projectile>().SetOwner(gameObject);
			ammoCount -= ammoPerShot;
			shotCount = shotAllowed;
			gameObject.GetComponent<Player>().SetShooting();
		}
	}
}

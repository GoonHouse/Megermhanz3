using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public GameObject bullet;

	public int ammo;
	public int ammoPerShot;
	public int maxAmmo;
	public float fireRate;

	// we technically need this to be a tiny number to bypass first-fire restrictions on guns with large cooldown time
	// @TODO: Find a way to make weapons not need -infinity to fire with a large fire rate.
	public float lastFired = -Mathf.Infinity;

	// Update is called once per frame
	void Update () {
		// @TODO: Put weapon cooldown code here.
		// If a weapon has to be out in order to cool down (no magic pockets) then the lastFired thing should
		// be handled here or something.
	}

	public bool Shoot (){
		if (HasEnoughAmmo() && CanFireAgain()) {
			ammo -= ammoPerShot;
			lastFired = Time.time;

			GameObject bul = (GameObject) Instantiate (
				bullet, 
				transform.position, 
				Quaternion.identity
			);

			// set the bullet's owner
			Projectile bulProjectile = bul.GetComponent<Projectile>();
			if(bulProjectile != null){
				// @WARNING: fuck the police
				bulProjectile.SetOwner(transform.parent.gameObject.transform.parent.gameObject);
			} else {
				Debug.Log ("Shot an object that wasn't a projectile: " + bul.name);
			}
			return true;
		} else {
			return false;
		}
	}

	// == Helpers

	// by defining this, we allow this to be overwritten  in the event
	// we need a gun that can still fire without the minimum ammount
	// (think: burst fire modes)
	public bool HasEnoughAmmo(){
		if (ammo - ammoPerShot > 0) {
			return true;
		} else {
			OutOfAmmo();
			return false;
		}
	}

	// we do this as a function because energy weapons (plasma rifle)
	// might use a cooldown instead of ammo
	public bool CanFireAgain(){
		Debug.Log ("I LOVE AMERICA");
		return (lastFired + fireRate) < Time.time;
	}

	// == Function hooks and overloads.
	// want to do something when out of ammo? reload? call mom? here you go.
	void OutOfAmmo(){
		Debug.Log ("OH GOD THERE ARE NO MORE BULLETS BUT I MUST INFLICT PAIN");
	}

	//These two are interfaces that get overridden by the specific weapons!
	public bool TriggerUp() {
		return false;
	}
	public bool TriggerDown() {
		return false;
	}
	public bool TriggerHold() {
		bool didShot = Shoot ();
		return didShot;
	}
}

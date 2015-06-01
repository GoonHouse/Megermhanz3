using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public GameObject bullet;

	public int ammo;
	public int ammoPerShot;
	public int maxAmmo;
	public float fireRate;

	private float lastFired;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
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
			bul.GetComponent<Projectile>().SetOwner(transform.parent.gameObject);
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
		return lastFired < Time.time + fireRate;
	}

	// == Function hooks and overloads.
	// want to do something when out of ammo? reload? call mom? here you go.
	void OutOfAmmo(){
		Debug.Log ("OH GOD THERE ARE NO MORE BULLETS BUT I MUST INFLICT PAIN");
	}	

	public void ChangeWeapon(GameObject newWeapon) {
		bullet = newWeapon;
		ammo = 300;
	}
}

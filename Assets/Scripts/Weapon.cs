using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public GameObject bullet;

	public int ammo;
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
		if (ammo > 0 && lastFired < Time.time + fireRate) {
			ammo--;
			lastFired = Time.time;
			Instantiate (
				bullet, 
			    new Vector3 (
					transform.position.x + 3f, 
					transform.position.y, 
					transform.position.z
				), 
				Quaternion.identity
			);
			return true;
		} else {
			return false;
		}
	}
}

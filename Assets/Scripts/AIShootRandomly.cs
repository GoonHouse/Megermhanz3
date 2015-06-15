using UnityEngine;
using System.Collections;

public class AIShootRandomly : MonoBehaviour {

	public float minShootTime;
	public float maxShootTime;

	private float lastShootTime = -Mathf.Infinity;
	private float randomDelay;

	// Use this for initialization
	void Start () {
		GetNewShootTime ();
	}

	void GetNewShootTime(){
		randomDelay = Random.Range (minShootTime, maxShootTime);
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > (lastShootTime + randomDelay)) {
			Weapon weapon = transform.Find ("WeaponAnchor").gameObject.GetComponentInChildren<Weapon> ();
			weapon.Shoot ();
			lastShootTime = Time.time;
			GetNewShootTime();
		}
	}
	//.transform.Find("Gun").gameObject
}

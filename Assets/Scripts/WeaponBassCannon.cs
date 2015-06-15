using UnityEngine;
using System.Collections;

public class WeaponBassCannon : Weapon {

	public float chargeTime;
	
	private bool isCharging;
	private float chargedTime;

	private AudioSource buildUp;
	private AudioSource bassFire;

	void Start (){
		AudioSource[] audios = GetComponents<AudioSource>();
		buildUp = audios[0];
		bassFire = audios[1];

		chargedTime = 0.0f;
		isCharging = false;
	}

	// Update is called once per frame
	void Update () {
		// @TODO: Put weapon cooldown code here.
		// If a weapon has to be out in order to cool down (no magic pockets) then the lastFired thing should
		// be handled here or something.
		ChargeUpdate ();
	}

	void ChargeUpdate(){
		if (isCharging) {
			if(ChargePart (Time.deltaTime)){
				Charged ();
			}
		}
	}
	
	bool ChargePart (float timeCharged){
		chargedTime += timeCharged;
		if (chargedTime >= chargeTime) {
			chargedTime = chargeTime;
			return true;
		} else {
			return false;
		}
	}

	void Charged (){
		bassFire.Play ();
		isCharging = false;
	}

	void ChargeStart (){
		isCharging = true;
		buildUp.Play ();
	}

	// we can change the logic in shoot 
	bool ChargeRelease (){
		isCharging = false;
		buildUp.Stop ();
		return Shoot ();
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

	// override this to only allow firing when we're fully charged
	new public bool CanFireAgain(){
		return chargedTime >= chargeTime;
	}

	//These two are interfaces that get overridden by the specific weapons!
	new public bool TriggerUp() {
		return ChargeRelease ();
	}
	new public bool TriggerDown() {
		ChargeStart ();
		return false;
	}
	new public bool TriggerHold() {
		return false;
	}
}

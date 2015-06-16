using UnityEngine;
using System.Collections;

public class WeaponBassCannon : Weapon {

	public float chargeTime;
	
	private bool isCharging;
	public float chargedTime;

	public GameObject camera;

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
		if (Shoot ()) {
			camera.GetComponent<CameraShaker>().Shake();
			return true;
		} else {
			return false;
		}
		return Shoot ();
	}

	// override this to only allow firing when we're fully charged
	public override bool CanFireAgain(){
		return chargedTime >= chargeTime;
	}

	//These two are interfaces that get overridden by the specific weapons!
	public override bool TriggerUp() {
		return ChargeRelease ();
	}
	public override bool TriggerDown() {
		ChargeStart ();
		return false;
	}
	public override bool TriggerHold() {
		return false;
	}
}

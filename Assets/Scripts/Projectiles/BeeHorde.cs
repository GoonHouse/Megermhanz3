using UnityEngine;
using System.Collections;

public class BeeHorde : Projectile {

	public int anticipatedBees;
	private GameObject[] managedBees;
	private bool armed;
	
	void Start() {
		armed = false;
		managedBees = new GameObject[anticipatedBees];
	}

	void Update (){
		if (armed) {
			// rotate toward the target
			GameObject target = owner.gameObject.GetComponent<TargetHandler>().GetTarget();
			if( target != null ){
				Quaternion rotation = Quaternion.LookRotation(
					target.transform.position - transform.position,
					transform.TransformDirection(Vector3.up)
					);
				transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);
				
				// swap this with the line below it for less wacky physics (why would we want this?)
				GetComponent<Rigidbody2D>().AddForce(speed * (target.transform.position - transform.position));
				//transform.position += transform.right * speed * Time.deltaTime;
			} else {
				Debug.Log ("I don't know what you wanted me to do. [SELF DESTRUCT]");
				Destroy(gameObject);
			}
		}
	}

	public void Init (int beesToExpect){
		anticipatedBees = beesToExpect;
		managedBees = new GameObject[beesToExpect];
	}

	public bool AddBee (GameObject bee){
		bee.transform.parent = transform;
		//managedBees [managedBees.Length] = bee;
		return true;
	}

	public Vector2 GetPositionForBee(){
		return (Vector2) (transform.position + Random.insideUnitSphere * 3);
	}

	public void Arm(){
		armed = true;
	}
}
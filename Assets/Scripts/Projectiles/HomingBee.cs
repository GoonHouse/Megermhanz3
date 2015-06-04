using UnityEngine;
using System.Collections;

public class HomingBee : Projectile {

	private bool armed;

	void Start (){
		armed = false;
	}

	// Update is called once per frame
	void Update () {
		// @TODO: We shouldn't keep running this number if we can help it.
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

	public void Arm(){
		armed = true;
	}
}
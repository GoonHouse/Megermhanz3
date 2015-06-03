using UnityEngine;
using System.Collections;

public class HomingBomb : Projectile {

	private float timer = 1;

	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer < 0) {
			// rotate toward the target
			GameObject target = owner.gameObject.GetComponent<TargetHandler>().target;
			Quaternion rotation = Quaternion.LookRotation(
				target.transform.position - transform.position,
				transform.TransformDirection(Vector3.up)
			);
			transform.rotation = new Quaternion(0, 0, rotation.z, rotation.w);

			// swap this with the line below it for less wacky physics (why would we want this?)
			GetComponent<Rigidbody2D>().AddForce(speed * (target.transform.position - transform.position));
			//transform.position += transform.right * speed * Time.deltaTime;
		}
	}
}

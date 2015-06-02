using UnityEngine;
using System.Collections;

public class HomingBomb : Projectile {

	private float timer = 1;

	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer < 0) {
			transform.position += transform.right * speed * Time.deltaTime;
		}
	}
}

using UnityEngine;
using System.Collections;

public class GrappleHookScript : Weapon {
	new bool TriggerDown() {
		Instantiate(bullet, transform.position, Quaternion.identity);
		return true;
	}

}

using UnityEngine;
using System.Collections;

public enum DamageType {
	Normal,
	Fire,
	Electric
}

public class Projectile : MonoBehaviour {

	public float speed;
	public int damage;
	public DamageType damageType;
	
	// Update is called once per frame
	void Update () {
		transform.position = new Vector2 (transform.position.x + speed, transform.position.y);
	}
}

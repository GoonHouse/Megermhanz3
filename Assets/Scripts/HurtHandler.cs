using UnityEngine;
using System.Collections;

public enum DamageType {
	Normal,
	Fire,
	Electric
}

public class HurtHandler : MonoBehaviour {

	public int maxHP;
	public int hp;

	public void Hurt (int amount, GameObject source, DamageType damageType) {
		if (amount > 0){
			hp -= amount;
			Debug.Log ("OW!" + amount);
		}
		
		if (hp <= 0){
			Die (transform.gameObject.name + " was killed by " + source.name);
		}
	}
	
	void Die (string reason) {
		Debug.Log ("I WAS TOO FABULOUS FOR THIS WORLD: " + reason);
		Destroy (transform.gameObject);
	}

	public void OnHurt(int amount, GameObject source, DamageType damageType){
		// this is how we would do something neat
	}
}

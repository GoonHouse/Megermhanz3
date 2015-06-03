using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public enum DamageType {
	Normal,
	Fire,
	Electric
}

public class HurtHandler : MonoBehaviour {

	public int maxHP;
	public int hp;

	
	public int jibAmount;
	public GameObject JibFire;
	public GameObject hitEffect;
	public GameObject screenCanvas;
	public GameObject screenCamera;

	public void Hurt (int amount, GameObject source, DamageType damageType) {
		if (amount > 0){
			hp -= amount;
			GetComponent<AudioSource>().Play ();

			//hit text
			SpawnText (amount, transform.position);

			// do target handling stuff if we can
			TargetHandler th = source.GetComponent<TargetHandler> ();
			if (th != null && th.targetOnHurt) {
				th.SetTarget(this.gameObject);
			}

			Debug.Log ("OW!" + amount);
		}
		
		if (hp <= 0){
			Die (transform.gameObject.name + " was killed by " + source.name);
		}
	}
	
	void Die (string reason) {
		Debug.Log ("I WAS TOO FABULOUS FOR THIS WORLD: " + reason);
		GameObject JibObject = Instantiate (JibFire, transform.position, Quaternion.identity) as GameObject;
		JibObject.GetComponent<JibFire> ().jibs = jibAmount;
		Destroy (transform.gameObject);
	}

	public void OnHurt(int amount, GameObject source, DamageType damageType){
		// this is how we would do something neat
	}

	public void SpawnText(float points, Vector3 spawnPos){
		Vector3 scrPos = RectTransformUtility.WorldToScreenPoint (screenCamera.GetComponent<Camera>(), spawnPos);
		GameObject ngui = (GameObject) Instantiate (
			hitEffect,
			scrPos,
			Quaternion.identity
			);
		ngui.GetComponent<Text>().text = points.ToString ();
		ngui.transform.parent = screenCanvas.transform;
	}
}

using UnityEngine;
using System.Collections;

public class TargetHandler : MonoBehaviour {

	public bool targetOnHurt;
	public bool alwaysSearchForTarget;
	public GameObject targetPrototype;
	public bool targetEnemies;

	private GameObject targetObject;
	private GameObject target;

	// Use this for initialization
	void Start () {
		SpawnTarget ();
	}
	
	// Update is called once per frame
	void Update () {
		if (alwaysSearchForTarget) {
			TargetClosest();
		}
	}

	void SpawnTarget(){
		targetObject = (GameObject) Instantiate (targetPrototype, transform.position, Quaternion.identity);
	}

	public bool SetTarget(GameObject newTarget){
		target = newTarget;

		if (targetObject == null) {
			SpawnTarget();
		}
		targetObject.transform.parent = target.transform;
		targetObject.transform.localPosition = new Vector3 (0.0f, 0.0f, 0.0f);

		return true;
	}

	public GameObject GetTarget (){
		return target;
	}

	public void TargetClosest (){
		string tagToTarget = "Player";
		if (targetEnemies) {
			tagToTarget = "Enemy";
		}

		Transform[] enemies = UnityEngine.Object.FindObjectsOfType<Transform>();
		Transform bestTarget = null;
		float closestDistanceSqr = Mathf.Infinity;
		Vector3 currentPosition = transform.position;
		foreach(Transform potentialTarget in enemies){
			Vector3 directionToTarget = potentialTarget.position - currentPosition;
			float dSqrToTarget = directionToTarget.sqrMagnitude;
			if(dSqrToTarget < closestDistanceSqr && potentialTarget.gameObject.tag == tagToTarget){
				closestDistanceSqr = dSqrToTarget;
				bestTarget = potentialTarget;
			}
		}
		SetTarget (bestTarget.gameObject);
	}
}

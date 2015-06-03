using UnityEngine;
using System.Collections;

public class TargetHandler : MonoBehaviour {

	public bool targetOnHurt;
	public GameObject target;
	public GameObject targetPrototype;

	private GameObject targetObject;

	// Use this for initialization
	void Start () {
		SpawnTarget ();
	}
	
	// Update is called once per frame
	void Update () {
	
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

	public void TargetClosestEnemy (){
		Transform[] enemies = UnityEngine.Object.FindObjectsOfType<Transform>();
		Transform bestTarget = null;
		float closestDistanceSqr = Mathf.Infinity;
		Vector3 currentPosition = transform.position;
		foreach(Transform potentialTarget in enemies){
			Vector3 directionToTarget = potentialTarget.position - currentPosition;
			float dSqrToTarget = directionToTarget.sqrMagnitude;
			if(dSqrToTarget < closestDistanceSqr && potentialTarget.gameObject.tag == "Enemy"){
				closestDistanceSqr = dSqrToTarget;
				bestTarget = potentialTarget;
			}
		}
		SetTarget (bestTarget.gameObject);
	}
}

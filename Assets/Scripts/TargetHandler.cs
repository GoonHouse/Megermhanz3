using UnityEngine;
using System.Collections;

public class TargetHandler : MonoBehaviour {

	public bool targetOnHurt;
	public GameObject target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool SetTarget(GameObject newTarget){
		target = newTarget;
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
		target = bestTarget.gameObject;
	}
}

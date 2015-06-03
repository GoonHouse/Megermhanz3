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
}

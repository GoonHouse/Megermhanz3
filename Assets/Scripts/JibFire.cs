using UnityEngine;
using System.Collections;

public class JibFire : MonoBehaviour {
	public int jibs = 20;
	public GameObject BigJib;
	public GameObject LittleJib;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		while (jibs > 0) {
			jibs -= SpawnJib (jibs);

		}
	}

	int SpawnJib(int input) {
		GameObject jibToFire;
		float selection = Random.Range(0f, 1f);
		int output;

		//if we can fire more than 5 jibs at a time
		if (input > 5) {
			//Randomly select between bigjib and little jib
			if (selection < .5f) {
				jibToFire = BigJib;
				output = 5;
			} else {
				jibToFire = LittleJib;
				output = 1;
			}
			//otherwise just fire little jibs to make up the difference
		} else {
			jibToFire = LittleJib;
			output = 1;
		}
		
		Instantiate (jibToFire,
		             transform.position,
		             Quaternion.identity);

		return output;
	}
}

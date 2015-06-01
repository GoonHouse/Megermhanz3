using UnityEngine;
using System.Collections.Generic;

public class Jib : MonoBehaviour {

	private SpriteRenderer sr;
	public bool big;
	static Sprite[] jibSprites;

	// Use this for initialization
	void Start () {
		sr = gameObject.GetComponent<SpriteRenderer> ();
		jibSprites = Resources.LoadAll<Sprite> ("Sprites/jib");
		
		//Randomly select correct sprite to use
		int rnd;
		
		if (big) {
			rnd = Random.Range (0, 4);
		} else {
			rnd = Random.Range (4, 7);
		}

		sr.sprite = jibSprites [rnd];


	}
	
	// Update is called once per frame
	void Update () {

	}
}

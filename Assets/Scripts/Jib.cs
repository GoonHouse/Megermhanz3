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

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.tag == "Player") {
			int count = 1;
			if (big) {
				count = 5;
			}
			col.gameObject.GetComponent<Player>().AddJib(count);
			Destroy (gameObject);
		}
	}
}

using UnityEngine;
using System.Collections.Generic;

public class Scrap : MonoBehaviour {

	private SpriteRenderer sr;
	public bool big;

	private int value = 1;
	private int bigMultiplier = 5;

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
		ScrapHandler sh = col.gameObject.GetComponent<ScrapHandler> ();
		if (sh != null) {
			int amount = value;
			if (big) {
				amount *= bigMultiplier;
			}
			sh.AddScrap(amount);
			Destroy (gameObject);
		}
	}
}
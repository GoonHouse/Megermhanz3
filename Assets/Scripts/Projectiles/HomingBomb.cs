using UnityEngine;
using System.Collections;

public class HomingBomb : MonoBehaviour {

	public float speed;

	private float timer = 1;
	
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;
		if (timer < 0) {
			rb.AddForce(transform.right * 5f);
		}
	}
}

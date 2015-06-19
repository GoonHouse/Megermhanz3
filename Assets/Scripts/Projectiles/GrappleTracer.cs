using UnityEngine;
using System.Collections;

public class GrappleTracer : MonoBehaviour {

	GameObject player;
	Rigidbody2D rb;
	float speed = 20;
	public GameObject hook;
	public GameObject chain;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}

	void Update() {
		rb.velocity = new Vector2(0, speed);
	}

	void OnCollisionEnter2D (Collision2D col) {
		if (col.gameObject.layer == LayerMask.NameToLayer("Ground")) {
			Attach (null);
		}

		if (col.gameObject.tag == "Enemy") {
			Attach (col.gameObject);
		}
	}
	
	void Attach(GameObject enemyAttach) {
		//Make the hook
		GameObject attachTo = MakeHook (enemyAttach);

		for (int i = 0; i < 5; i++) {
			attachTo = MakeChain (attachTo);
		}
		LastChain (attachTo);

		Destroy (gameObject);
	}
	
	GameObject MakeHook(GameObject enemyAttach) {
		GameObject theHook = Instantiate (hook, transform.position, Quaternion.identity) as GameObject;
		HingeJoint2D hj = theHook.GetComponent<HingeJoint2D> ();
		if (enemyAttach) {
			hj.connectedAnchor = Vector2.zero;
			hj.connectedBody = enemyAttach.GetComponent<Rigidbody2D> ();
			theHook.transform.parent = enemyAttach.transform;
		} else {
			hj.connectedAnchor = transform.position;
		}
		return theHook;
	}

	GameObject MakeChain (GameObject attachIn) {
		GameObject theChain = Instantiate (chain, transform.position, Quaternion.identity) as GameObject;
		HingeJoint2D hj = theChain.GetComponent<HingeJoint2D> ();
		hj.connectedBody = attachIn.GetComponent<Rigidbody2D>();
		hj.anchor = new Vector2 (.47f, 0);
		hj.connectedAnchor = new Vector2 (-.26f, 0);
		return theChain;
	}

	void LastChain(GameObject attachIn) {
		HingeJoint2D hj2 = attachIn.AddComponent<HingeJoint2D>();
		hj2.connectedBody = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody2D>();
		hj2.anchor = new Vector2 (-.34f, 0);
		hj2.connectedAnchor = new Vector2 (.21f, .88f);
	}
}
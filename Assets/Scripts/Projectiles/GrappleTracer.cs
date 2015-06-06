using UnityEngine;
using System.Collections;

public class GrappleTracer : MonoBehaviour {

	GameObject player;
	Rigidbody2D rb;
	float speed = 20;
	public GameObject hook;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		rb = gameObject.GetComponent<Rigidbody2D> ();
	}

	void Update() {
		rb.velocity = new Vector2(speed, speed);
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.IsTouchingLayers(LayerMask.GetMask("Ground"))) {
			Attach();
		}
	}
	
	void Attach() {
		//Make the hook
		MakeHook ();
		//Make the chains
		int temp = chainNeeded (player, gameObject);
		for (int i = 0; i < temp; i++) {
			MakeChain(i);
		}
		//Attach last chain to player
		AttachChain (temp);
		Destroy (gameObject);
	}
	
	void MakeHook() {
		GameObject theHook = Instantiate (hook, transform.position, Quaternion.identity) as GameObject;
		theHook.GetComponent<HingeJoint2D> ().anchor = transform.position;
	}
	
	void MakeChain( int chainNumber) {
		
	}
	
	void AttachChain(int chainToAttach) {
		
	}
	
	int chainNeeded(GameObject playerIn, GameObject hookIn) {
		int chainAmount = 0;
		Vector2 temp = playerIn.transform.position - hookIn.transform.position;
		float temp2 = temp.magnitude;
		while (temp2 >= 1) {
			temp2--;
			chainAmount++;
		}
		return chainAmount;
	}
}

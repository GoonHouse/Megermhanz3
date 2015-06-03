using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EffectText : MonoBehaviour {

	public Color color = new Color(0.8f, 0.8f, 0.0f, 1.0f);
	public float scroll = 0.05f;
	public float duration = 1.5f;
	public float alpha;
	
	// Use this for initialization
	void Start () {
		GetComponent<Text>().material.color = color;
		alpha = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (alpha > 0) {
			Vector3 pos = transform.position;
			pos.y += pos.y + (scroll * Time.deltaTime);
			//transform.position = pos;
			alpha -= Time.deltaTime / duration;
			Color tcolor = GetComponent<Text>().material.color;
			tcolor.a = alpha;
		} else {
			Destroy (gameObject);
		}
	}
}

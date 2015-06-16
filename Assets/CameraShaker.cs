using UnityEngine;
using System.Collections;

// I won't pretend to have written this, but I did spruce it up.
// http://www.mikedoesweb.com/2012/camera-shake-in-unity
// http://answers.unity3d.com/questions/33477/question-about-overriding-functions.html
public class CameraShaker : MonoBehaviour {
	public float shakeDecay;
	public float shakeIntensity;

	private Vector3 originPosition;
	private Quaternion originRotation;

	void Update (){
		if (shakeIntensity > 0){
			transform.position = originPosition + Random.insideUnitSphere * shakeIntensity;
			transform.rotation = new Quaternion(
				originRotation.x + Random.Range (-shakeIntensity,shakeIntensity) * .2f,
				originRotation.y + Random.Range (-shakeIntensity,shakeIntensity) * .2f,
				originRotation.z + Random.Range (-shakeIntensity,shakeIntensity) * .2f,
				originRotation.w + Random.Range (-shakeIntensity,shakeIntensity) * .2f);
			shakeIntensity -= shakeDecay;
		}
	}
	
	public void Shake(){
		originPosition = transform.position;
		originRotation = transform.rotation;
		shakeIntensity = .3f;
		shakeDecay = 0.002f;
	}
}
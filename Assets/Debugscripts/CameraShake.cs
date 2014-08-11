using UnityEngine;
using System.Collections;

public class CameraShake : MonoBehaviour {

	Vector3 originPosition;
	Quaternion originRotation;

	
	float shake_decay;
	float shake_intensity;

	// Update is called once per frame
	void Update () {
		if (Input.anyKeyDown || Input.touchCount > 0) {
			//Shake();
		}

		if(shake_intensity > 0){
			transform.position = originPosition + Random.insideUnitSphere * shake_intensity;
			transform.rotation =  new Quaternion(
				originRotation.x + Random.Range(-shake_intensity,shake_intensity)*.2f,
				originRotation.y + Random.Range(-shake_intensity,shake_intensity)*.2f,
				originRotation.z + Random.Range(-shake_intensity,shake_intensity)*.2f,
				originRotation.w + Random.Range(-shake_intensity,shake_intensity)*.2f);
			shake_intensity -= shake_decay;


			if (shake_intensity >= 0.03){
				Handheld.Vibrate ();
			}
			if (shake_intensity <= 0)
			{
				transform.position = originPosition;
				transform.rotation = originRotation;

				shake_intensity = 0;
			}
		}
	}
	
	public void Shake(){
		if (shake_intensity <= 0) {
			originPosition = transform.position;
			originRotation = transform.rotation;
			shake_intensity = 0.1f;
			shake_decay = 0.002f;
		}
	}
}

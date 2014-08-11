using UnityEngine;
using System.Collections;

public class MakeBallJump : MonoBehaviour {
	
	public GetInput input;
	public float ChargeSpeed;
	public float MaxCharge;
	public float PowerMultiplier;
	float squish;
	float timeFloat;
	public Transform mesh;

	void Update () {
		if (input.Touching) {
			timeFloat = input.Duration.Milliseconds + (input.Duration.Seconds * 1000);
			timeFloat *= ChargeSpeed;
			if (timeFloat > MaxCharge) {
					timeFloat = MaxCharge;
			}
			squish = 1 - ((timeFloat / MaxCharge) / 2);
		} else if (squish < 1) {
			rigidbody.AddForce(new Vector3(0,(timeFloat / MaxCharge)*PowerMultiplier,0));
			squish = 1;
			timeFloat = 0;
		}
		mesh.localScale = new Vector3 (mesh.localScale.x, squish, mesh.localScale.z);
		mesh.localPosition=new Vector3(mesh.localPosition.x, (squish/2.01f), mesh.localPosition.z);
		var collider = GetComponent<CapsuleCollider> ();
		collider.height = squish;
	}
}

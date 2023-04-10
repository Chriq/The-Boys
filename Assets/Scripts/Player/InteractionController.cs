
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour {
	private void Update() {
		if(Input.GetKeyDown(KeyCode.E)) {
			Vector3 dir = transform.TransformDirection(-transform.right);
			LightRay light = new LightRay(transform.position, dir, Color.red);
			LightCaster.CastLight(light);
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public static class LightCaster {

	private static readonly float MAX_CAST_DISTANCE = 10f;

	public static void CastLight(LightRay lightRay) {
		RaycastHit2D hit = Physics2D.Raycast(lightRay.origin, lightRay.direction, MAX_CAST_DISTANCE);
		if (hit) {
			//Light2D light = new GameObject().AddComponent<Light2D>();
			/*SpriteRenderer light = new GameObject().AddComponent<SpriteRenderer>();
			light.transform.position = lightRay.position;
			light.transform.localScale.x = Vector3.Distance(lightRay.position, hit.point);*/
			Debug.DrawLine(lightRay.origin, hit.point, lightRay.color, Mathf.Infinity);
			if(!hit.collider.CompareTag("StopRaycast")) {
				Reflectable reflectable = hit.collider.gameObject.GetComponentInParent<Reflectable>();
				if (reflectable != null) {
					LightRay reflection = reflectable.Reflect(lightRay);
					CastLight(reflection);
					return;
				}
			}
		} else {
			Debug.DrawLine(lightRay.origin, lightRay.origin + lightRay.direction * 10, Color.blue, Mathf.Infinity);
			//Debug.DrawRay(lightRay.origin, lightRay.direction * MAX_CAST_DISTANCE, lightRay.color, 10f);
			return;
		}
	}
}

public struct LightRay {
	public Vector3 origin;
	public Vector3 direction;
	public Color color;

	public LightRay(Vector3 origin, Vector3 dir, Color color) {
		this.origin = origin;
		this.direction = dir;
		this.color = color;
	}
}
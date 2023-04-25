using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public static class LightCaster {

	private static readonly float MAX_CAST_DISTANCE = 10f;

	public static List<GameObject> CastLight(LightRay lightRay, int bounceLimit) {
		List<GameObject> lights = new List<GameObject>();
		if(bounceLimit > 0) {
			RaycastHit2D hit = Physics2D.Raycast(lightRay.origin, lightRay.direction, MAX_CAST_DISTANCE, LayerMask.GetMask("Light"));
			if(hit) {
				Debug.DrawLine(lightRay.origin, hit.point, Color.red, Mathf.Infinity);

				lights.Add(InstantiateLightEffect(lightRay, hit.point));

				if(!hit.collider.CompareTag("StopRaycast")) {
					Reflectable reflectable = hit.collider.gameObject.GetComponentInParent<Reflectable>();
					if(reflectable != null) {
						LightRay reflection = reflectable.Reflect(lightRay);
						lights.AddRange(CastLight(reflection, bounceLimit - 1));
					}
				} else {
					Crystal crystal;
					AIController ai;

					if(hit.collider.gameObject.TryGetComponent(out crystal)) {
						if(lightRay.color == crystal.color) {
							crystal.Activate();
						}
					} else if(hit.collider.transform.parent.TryGetComponent(out ai)) {
						if(!ai.burned) {
							ai.AIBurned();
						}
					}
				}

				return lights;
			} else {
				Debug.DrawLine(lightRay.origin, lightRay.origin + lightRay.direction * 10, Color.blue, Mathf.Infinity);
				lights.Add(InstantiateLightEffect(lightRay, lightRay.origin + lightRay.direction * 10));
				//Debug.DrawRay(lightRay.origin, lightRay.direction * MAX_CAST_DISTANCE, lightRay.color, 10f);
				return lights;
			}
		} else {
			return lights;
		}
	}

	private static GameObject InstantiateLightEffect(LightRay ray, Vector3 endPoint) {
		float dist = Vector3.Distance(ray.origin, endPoint);
		GameObject lightBeam = Resources.Load("LightBeam") as GameObject;
		lightBeam.transform.localScale = new Vector3(dist, 0.25f);
		lightBeam.transform.position = Vector3.Lerp(ray.origin, endPoint, 0.5f);
		lightBeam.transform.eulerAngles = new Vector3(0f, 0f, VectorToAngle(ray.direction));
		//Vector3.RotateTowards(lightBeam.transform.rotation., ray.direction, Mathf.PI, 0f);
		lightBeam.GetComponent<Light2D>().color = ray.color;
		return GameObject.Instantiate(lightBeam);
	}

	private static float VectorToAngle(Vector3 direction) {
		float r = Mathf.Acos(Vector3.Dot(direction.normalized, Vector3.right)) * Mathf.Rad2Deg;
		if(direction.y >= 0f) {
			return r;
		} else {
			return -r;
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
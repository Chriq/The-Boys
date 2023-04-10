using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reflectable : MonoBehaviour {
	public float surfaceAngle;
	public Color color;
	public Transform reflectionSpawn;

	public LightRay Reflect(LightRay incomingLight) {
		Vector3 surfaceNormal = GetNormal(GetAngleAsVector(surfaceAngle));
		Vector3 dir = Vector3.Reflect(incomingLight.direction, surfaceNormal);
		LightRay reflection = new LightRay(reflectionSpawn.position, dir, color == Color.white ? incomingLight.color : color);
		return reflection;
	}

	private Vector3 GetAngleAsVector(float angleToXAxis) {
		float y = Mathf.Sin(Mathf.Deg2Rad * angleToXAxis) / Mathf.Sin(Mathf.Deg2Rad * (90f - angleToXAxis));
		Vector3 v = new Vector3(-1f, y, 0f);
		return transform.rotation * v;
	}

	private Vector3	GetNormal(Vector3 incoming) {
		return new Vector3(incoming.y, -incoming.x, 0f).normalized;
	}
}

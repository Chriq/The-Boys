
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour {
	private List<GameObject> lights;
	public void Interact(Vector3 checkCell) {
		Collider2D[] colliders = Physics2D.OverlapCircleAll(checkCell, 0.3f);
		if(colliders != null && colliders.Length > 0) {
			Interactable interactable;
			foreach(Collider2D collider in colliders) {
				if(collider.gameObject.TryGetComponent(out interactable)) {
					interactable.Interact();
					break;
				}
			}
			
		}
	}

	public void RotateObject(Vector3 checkCell) {
		Collider2D[] colliders = Physics2D.OverlapCircleAll(checkCell, 0.3f);
		if(colliders != null && colliders.Length > 0) {
			Rotatable rotatable;
			foreach(Collider2D collider in colliders) {
				if(collider.gameObject.TryGetComponent(out rotatable)) {
					rotatable.Rotate();
					break;
				}
			}

		}
	}

	public void ShineFlashlight(Vector3 dir) {
		LightRay light = new LightRay(transform.position + new Vector3(0.5f, -0.5f), dir, Color.white);
		lights = LightCaster.CastLight(light, 8);
	}

	public void TurnOffFlashlight() {
		foreach(GameObject l in lights) {
			Destroy(l);
		}
	}
}

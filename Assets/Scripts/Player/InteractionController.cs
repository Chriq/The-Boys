
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour {
	public GameObject playerLight;
	public bool isPlayerHidden = false;

	private Vector3 spriteOffset = new Vector3(0.5f, -0.5f);
	private List<GameObject> lights;

	public void Interact(Vector3 checkCell) {
		Collider2D[] colliders = Physics2D.OverlapCircleAll(checkCell + spriteOffset, 0.3f);
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
		playerLight.SetActive(true);
		LightRay light = new LightRay(transform.position + spriteOffset, dir, Color.white);
		lights = LightCaster.CastLight(light, 8);
	}

	public void TurnOffFlashlight() {
		playerLight.SetActive(false);
		foreach(GameObject l in lights) {
			Destroy(l);
		}
	}

	public void ToggleHidePlayer() {
		SpriteRenderer spriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
		InputController input = gameObject.GetComponent<InputController>();

		spriteRenderer.enabled = !spriteRenderer.enabled;
		input.movementEnabled = !input.movementEnabled;
		isPlayerHidden = !isPlayerHidden;
	}
}

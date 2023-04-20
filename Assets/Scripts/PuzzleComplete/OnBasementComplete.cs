using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class OnBasementComplete : MonoBehaviour, OnRoomComplete {
	public GameObject wallCollider;
	public SpriteRenderer portalEffect;
	public Light2D pentagramLight;

	public void Execute() {
		Destroy(wallCollider);
		StartCoroutine(FadeCoroutine(0f, 1f, 1f));
		StartCoroutine(LightCoroutine(0f, 0.4f, 1f));
	}

	private IEnumerator FadeCoroutine(float start, float end, float duration) {
		float counter = 0;

		while(counter < duration) {
			counter += Time.deltaTime;
			portalEffect.color = new Color(1f, 1f, 1f, Mathf.Lerp(start, end, counter / duration));
			yield return null;
		}
	}

	private IEnumerator LightCoroutine(float start, float end, float duration) {
		float counter = 0;

		while(counter < duration) {
			counter += Time.deltaTime;
			pentagramLight.intensity = Mathf.Lerp(start, end, counter / duration);
			yield return null;
		}
	}
}

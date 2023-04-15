using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotatable : MonoBehaviour {
	private bool isMoving = false;
	public RandomizeAudio audioPlayer;

	public void Rotate() {
		if(!isMoving) {
			audioPlayer.PlayAudio();
			float z = (transform.parent.eulerAngles.z + 90f) % 360;
			Vector3 target = new Vector3(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, z);
			//StartCoroutine(RotateTo(target, 1f));
			transform.parent.eulerAngles = target;
		}
	}

	IEnumerator RotateTo(Vector3 targetRotation, float speed) {
		isMoving = true;
		while((targetRotation - transform.parent.eulerAngles).sqrMagnitude > Mathf.Epsilon) {
			//transform.parent.rotation = Quaternion.FromToRotation(transform.parent.eulerAngles, targetRotation);//
			transform.parent.eulerAngles = Vector3.RotateTowards(transform.parent.eulerAngles, targetRotation, speed * Time.deltaTime, 0.25f);
			yield return null;
		}

		transform.eulerAngles = targetRotation;
		isMoving = false;
	}
}

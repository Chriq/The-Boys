using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pushable : MonoBehaviour {

	private bool isMoving = false;
	public RandomizeAudio audioPlayer;

    public void Push(Vector3 direction, float speed) {
		if(!isMoving) {
			Vector3 targetPos = transform.position + direction.normalized;
			if(!IsTileOccupied(targetPos)) {
				audioPlayer.PlayAudio();
				StartCoroutine(MoveToCell(targetPos, speed));
			}
		}
    }

	IEnumerator MoveToCell(Vector3 targetPos, float speed) {
		isMoving = true;
		while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon) {
			transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
			yield return null;
		}

		transform.position = targetPos;
		isMoving = false;
	}

	private bool IsTileOccupied(Vector3 targetPos) {
		Vector3 posWithOffset = targetPos;
		if(Physics2D.OverlapCircle(posWithOffset, 0.3f)) {
			return true;
		}

		return false;
	}
}

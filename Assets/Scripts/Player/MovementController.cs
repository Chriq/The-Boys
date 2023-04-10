using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {
	public float speed;
	public Animator animator;
	public Vector3 spriteOffset;

	private bool isMoving;

	public void Move(Vector2 input) {
		if (!isMoving) {
			/*if(Input.GetKeyDown(KeyCode.E)) {
				Vector3 targetPos = transform.position;
				targetPos.x += animator.GetFloat("horizontal");
				targetPos.y += animator.GetFloat("vertical");
				Interact(targetPos);
			}*/

			if(input != Vector2.zero) {
				Vector3 targetPos = transform.position;
				targetPos.x += input.x;
				targetPos.y += input.y;

				animator.SetFloat("horizontal", input.x);
				animator.SetFloat("vertical", input.y);

				if(!IsTileOccupied(targetPos)) {
					StartCoroutine(MoveToCell(targetPos));
				}
			}
		}

		animator.SetBool("isMoving", isMoving);
	}

	IEnumerator MoveToCell(Vector3 targetPos) {
		isMoving = true;
		while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon) {
			transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
			yield return null;
		}

		transform.position = targetPos;
		isMoving = false;
	}

	private void Interact(Vector3 checkPos) {
		Vector3 posWithOffset = checkPos + spriteOffset;
		Collider2D collider = Physics2D.OverlapCircle(posWithOffset, 0.3f);
		if(collider) {
			/*Interactable interactable;
			if(collider.gameObject.TryGetComponent(out interactable)) {
				interactable.Interact();
			}*/
		}
	}

	private bool IsTileOccupied(Vector3 targetPos) {
		Vector3 posWithOffset = targetPos + spriteOffset;
		Collider2D col;
		if(col = Physics2D.OverlapCircle(posWithOffset, 0.3f)) {
			return true;
		}

		return false;
	}
}

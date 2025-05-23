using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour {
	public float speed;
	public Animator animator;
	public float animTime = 0f;

	public Vector3 spriteOffset;
	public SpriteRenderer sprite;

	public bool isMoving;
	public Vector3 currentPosition;
	public Vector3 currentDirection;

	private RandomizeAudio audioPlayer;

	private void Awake() {
		currentPosition = transform.position;
		currentDirection = transform.up;
		audioPlayer = GetComponent<RandomizeAudio>();
	}

	public void Move(Vector2 input) {
		if (!isMoving) {
			if(input != Vector2.zero) {
				currentDirection = input;

				if(input.x > 0) {
					sprite.flipX = false;
				} else if(input.x < 0) {
					sprite.flipX = true;
				}

				Vector3 targetPos = transform.position;
				targetPos.x += input.x;
				targetPos.y += input.y;

				GameObject collision = IsTileOccupied(targetPos);
				if(!collision) {
					audioPlayer.PlayAudio();
					currentPosition = targetPos;
					StartCoroutine(MoveToCell(targetPos));
				} else {
					Pushable pushable;
					if(pushable = collision.GetComponentInParent<Pushable>()) {
						pushable.Push(input, speed);
					}
				}
			}
		}

		animator.SetBool("isMoving", isMoving);
	}

	IEnumerator MoveToCell(Vector3 targetPos) {
		isMoving = true;
		//animator.ForceStateNormalizedTime(animTime);
		animator.SetFloat("motionTime", animTime);
		while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon) {
			animTime += Time.deltaTime;
			animator.SetFloat("motionTime", animTime);
			transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
			yield return null;
		}

		transform.position = targetPos;
		isMoving = false;
		animator.SetBool("isMoving", isMoving);
		//animTime = animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
		animTime = animTime % 1f;
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

	private GameObject IsTileOccupied(Vector3 targetPos) {
		Vector3 posWithOffset = targetPos + spriteOffset;
		Collider2D col;
		if(col = Physics2D.OverlapCircle(posWithOffset, 0.3f, LayerMask.GetMask("Physical"))) {
			return col.gameObject;
		}

		return null;
	}
}

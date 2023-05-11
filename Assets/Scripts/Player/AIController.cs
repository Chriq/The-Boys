using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AIController : MonoBehaviour {
	public MovementController movementController;

	private bool seesPlayer = true;
	public bool burned = false;
	private GameObject player;
	private float timer;
	public AudioSource burn;

	private void Start() {
		player = GameObject.FindGameObjectWithTag("Player");
		if(player) {
			seesPlayer = !player.GetComponent<InteractionController>().isPlayerHidden;
		} else {
			seesPlayer = false;
		}
	}

	private void Update() {
		if(seesPlayer && !burned) {
			Vector3 playerPosition = player.GetComponent<MovementController>().currentPosition;
			Vector3 dir = playerPosition - transform.position;

			if(dir.magnitude < 0.25f) {
				SceneManager.LoadScene("GameOver");
			}

			if(dir.x != 0f && !IsTileOccupied(transform.position + new Vector3(dir.x, 0f).normalized)) {
				movementController.Move(new Vector3(dir.x, 0f).normalized);
			} else if(dir.y != 0f && !IsTileOccupied((transform.position + new Vector3(0f, dir.y).normalized))) {
				movementController.Move(new Vector3(0f, dir.y).normalized);
			} else if(dir.x != 0f && !IsTileOccupied(transform.position + new Vector3(-dir.x, 0f).normalized)) {
				movementController.Move(new Vector3(-dir.x, 0f).normalized);
			} else if(dir.y != 0f && !IsTileOccupied(transform.position + new Vector3(0f, -dir.y).normalized)) {
				movementController.Move(new Vector3(0f, -dir.y).normalized);
			}

			// if cant move directly to player, move in smallest direction until other is clear
		} else {
			seesPlayer = !player.GetComponent<InteractionController>().isPlayerHidden;
			CantSeePlayer();
		}
	}

	private bool IsTileOccupied(Vector3 targetPos) {
		Vector3 posWithOffset = targetPos + new Vector3(0.5f, -0.5f);
		if(Physics2D.OverlapCircle(posWithOffset, 0.3f, LayerMask.GetMask("Physical"))) {
			return true;
		}

		return false;
	}

	void CantSeePlayer() {
		if(!seesPlayer) {
			timer += Time.deltaTime;
			if(timer > 3f) {
				GameData.Instance.isPlayerChased = false;
				GameData.Instance.lastRoomCompleted = "";
				Destroy(gameObject);
			}
		} else {
			timer = 0f;
		}
	}

	public void AIBurned() {
		burned = true;
		burn.Play();
		StartCoroutine(StopPursuit());
	}

	IEnumerator StopPursuit() {
		yield return new WaitForSeconds(6f);
		burned = false;
	}
}

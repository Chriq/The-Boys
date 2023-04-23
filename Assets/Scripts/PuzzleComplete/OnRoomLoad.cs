using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnRoomLoad : MonoBehaviour {
	public List<GameObject> destroyIfRoomComplete;
	public List<Transform> playerSpawns;

	private GameObject player;

	private void Start() {
		UIManager.Instance.fadeCanvas.GetComponent<UIFade>().FadeOut();
		if(GameData.Instance.completedRooms[SceneManager.GetActiveScene().name]) {
			foreach(GameObject g in destroyIfRoomComplete) {
				Destroy(g);
			}
		}

		player = GameObject.FindGameObjectWithTag("Player");
		SetPlayerPosition();
	}

	private void SetPlayerPosition() {
		if(SceneManager.GetActiveScene().name == "MainRoom") {
			switch(GameData.Instance.lastRoomIn) {
				case "Kitchen":
					player.transform.position = playerSpawns[0].position + new Vector3(-0.5f, 0.5f);
					player.GetComponent<MovementController>().currentPosition = playerSpawns[0].position + new Vector3(-0.5f, 0.5f);
					break;
				case "Bedroom":
					player.transform.position = playerSpawns[1].position + new Vector3(-0.5f, 0.5f);
					player.GetComponent<MovementController>().currentPosition = playerSpawns[1].position + new Vector3(-0.5f, 0.5f);
					break;
				case "Bathroom":
					player.transform.position = playerSpawns[2].position + new Vector3(-0.5f, 0.5f);
					player.GetComponent<MovementController>().currentPosition = playerSpawns[2].position + new Vector3(-0.5f, 0.5f);
					break;
				case "Basement":
					player.transform.position = playerSpawns[3].position + new Vector3(-0.5f, 0.5f);
					player.GetComponent<MovementController>().currentPosition = playerSpawns[3].position + new Vector3(-0.5f, 0.5f);
					break;
				default:
					break;
			}
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnRoomLoad : MonoBehaviour {
	public List<GameObject> destroyIfRoomComplete;

	private void Start() {
		if(GameData.Instance.completedRooms[SceneManager.GetActiveScene().name]) {
			foreach(GameObject g in destroyIfRoomComplete) {
				Destroy(g);
			}
		}
	}

	public void ResetPuzzle() {

	}

	public void AutoSolvePuzzle() {

	}
}

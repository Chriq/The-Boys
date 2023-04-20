using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	public List<Transform> spawnPoints;

	private void Start() {
		SpawnEnemy();
	}

	public void SpawnEnemy() {
		
		if(SceneManager.GetActiveScene().name == "MainRoom") {
			switch(GameData.Instance.lastRoomCompleted) {
				case "Kitchen":
					Instantiate(enemyPrefab).transform.position = spawnPoints[0].position + new Vector3(-0.5f, 0.5f);
					GameData.Instance.isPlayerChased = true;
					break;
				case "Bedroom":
					Instantiate(enemyPrefab).transform.position = spawnPoints[1].position + new Vector3(-0.5f, 0.5f);
					GameData.Instance.isPlayerChased = true;
					break;
				case "Bathroom":
					Instantiate(enemyPrefab).transform.position = spawnPoints[2].position + new Vector3(-0.5f, 0.5f);
					GameData.Instance.isPlayerChased = true;
					break;
			}
		} else {
			if(GameData.Instance.isPlayerChased) {
				StartCoroutine(SpawnCoroutine());
			}
		}
	}

	IEnumerator SpawnCoroutine() {
		yield return new WaitForSeconds(5f);
		Instantiate(enemyPrefab).transform.position = spawnPoints[0].position + new Vector3(-0.5f, 0.5f);
	}
}

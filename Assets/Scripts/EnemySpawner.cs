using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	public List<Transform> spawnPoints;
	public AudioSource audioSource;

	private void Start() {
		SpawnEnemy();
	}

	public void SpawnEnemy() {
		
		if(SceneManager.GetActiveScene().name == "MainRoom") {
			switch(GameData.Instance.lastRoomCompleted) {
				case "Kitchen":
					Instantiate(enemyPrefab).transform.position = spawnPoints[0].position + new Vector3(-0.5f, 0.5f);
					GameData.Instance.isPlayerChased = true;
					audioSource.Play();
					break;
				case "Bedroom":
					Instantiate(enemyPrefab).transform.position = spawnPoints[1].position + new Vector3(-0.5f, 0.5f);
					GameData.Instance.isPlayerChased = true;
					audioSource.Play();
					break;
				case "Bathroom":
					Instantiate(enemyPrefab).transform.position = spawnPoints[2].position + new Vector3(-0.5f, 0.5f);
					GameData.Instance.isPlayerChased = true;
					audioSource.Play();
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
		GameObject enemy = Instantiate(enemyPrefab);
		enemy.transform.position = spawnPoints[0].position + new Vector3(-0.5f, 0.5f);
		yield return new WaitForSeconds(1f);
		enemy.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;
		yield return new WaitForSeconds(1f);
		enemy.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = false;
	}
}

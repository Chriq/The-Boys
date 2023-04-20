using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class CutSceneController : MonoBehaviour {
	public Transform enemySpawn;
	public GameObject enemyPrefab;
	public Light2D globalLight;
	public List<Sprite> enemyAlternateSprites;

	private InputController playerInput;
	private Color ogLightColor;

	private void Start() {
		playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<InputController>();
		ogLightColor = globalLight.color;
	}

	public void Execute() {
		playerInput.enabled = false;
		StartCoroutine(SpwanEnemies());
    }

	IEnumerator SpwanEnemies() {
		GameObject enemy1 = Instantiate(enemyPrefab);
		enemy1.transform.position = enemySpawn.position + new Vector3(-0.5f, 0.5f);
		enemy1.GetComponent<AIController>().enabled = false;
		enemy1.GetComponent<MovementController>().Move(new Vector2(0f, 1f));
		yield return new WaitForSeconds(0.9f);

		GameObject enemy2 = Instantiate(enemyPrefab);
		enemy2.transform.position = enemySpawn.position + new Vector3(-0.5f, 0.5f);
		enemy2.GetComponent<AIController>().enabled = false;
		enemy1.GetComponent<MovementController>().Move(new Vector2(0f, 1f));
		enemy2.GetComponent<MovementController>().Move(new Vector2(0f, 1f));
		yield return new WaitForSeconds(0.9f);

		GameObject enemy3 = Instantiate(enemyPrefab);
		enemy3.transform.position = enemySpawn.position + new Vector3(-0.5f, 0.5f);
		enemy3.GetComponent<AIController>().enabled = false;
		enemy1.GetComponent<MovementController>().Move(new Vector2(1f, 0f));
		enemy2.GetComponent<MovementController>().Move(new Vector2(0f, 1f));
		enemy3.GetComponent<MovementController>().Move(new Vector2(0f, 1f));
		yield return new WaitForSeconds(3f);

		enemy1.transform.GetChild(0).GetComponent<Animator>().enabled = false;
		enemy2.transform.GetChild(0).GetComponent<Animator>().enabled = false;
		enemy3.transform.GetChild(0).GetComponent<Animator>().enabled = false;

		enemy1.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = enemyAlternateSprites[0];
		enemy2.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = enemyAlternateSprites[1];
		enemy3.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = enemyAlternateSprites[2];

		globalLight.intensity = 1f;
		globalLight.color = Color.white;
	}
}

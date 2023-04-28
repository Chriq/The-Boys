using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class CutSceneController : MonoBehaviour {
	public Transform enemySpawn;
	public GameObject enemyPrefab;
	public Light2D globalLight;
	public List<Sprite> enemyAlternateSprites;

	private InputController playerInput;
	private Color ogLightColor;
	private DialogManager dialog;

	private GameObject enemy1;
	private GameObject enemy2;
	private GameObject enemy3;

	private void Start() {
		playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<InputController>();
		dialog = UIManager.Instance.dialogManager;
		ogLightColor = globalLight.color;
	}

	public void Execute() {
		UIManager.Instance.interactionCanvas.SetActive(false);
		StartCoroutine(SpwanEnemies());
    }

	IEnumerator SpwanEnemies() {
		playerInput.transform.GetChild(0).GetComponent<SpriteRenderer>().flipX = true;

		enemy1 = Instantiate(enemyPrefab);
		enemy1.transform.position = enemySpawn.position + new Vector3(-0.5f, 0.5f);
		enemy1.GetComponent<AIController>().enabled = false;
		enemy1.GetComponent<MovementController>().Move(new Vector2(0f, 1f));
		yield return new WaitForSeconds(0.9f);

		enemy2 = Instantiate(enemyPrefab);
		enemy2.transform.position = enemySpawn.position + new Vector3(-0.5f, 0.5f);
		enemy2.GetComponent<AIController>().enabled = false;
		enemy1.GetComponent<MovementController>().Move(new Vector2(0f, 1f));
		enemy2.GetComponent<MovementController>().Move(new Vector2(0f, 1f));
		yield return new WaitForSeconds(0.9f);

		enemy3 = Instantiate(enemyPrefab);
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

		List<TextLine> dialogList = new List<TextLine>();
		TextLine line = new TextLine();

		line.text = "Oh man, it's so bright in here. It's burning my eyes.";
		line.color = new Color32(131, 39, 39, 255);
		dialogList.Add(line);

		line.text = "Hey, you got the beans! You here for dinner?";
		line.color = new Color32(131, 39, 39, 255);
		dialogList.Add(line);

		line.text = "Wait, who are you? You guys aren't horrible demons trying to devour my soul?";
		line.color = Color.white;
		dialogList.Add(line);

		line.text = "Uhhh.....no? We've just been inside for...a while. We're a bit pale, but definitely not demons, haha.";
		line.color = new Color32(131, 39, 39, 255);
		dialogList.Add(line);

		line.text = "Then why were you chasing me all over the house?";
		line.color = Color.white;
		dialogList.Add(line);

		line.text = "I mean, you are a strange guy in our house. We wanted to know what you're doing here.";
		line.color = new Color32(131, 39, 39, 255);
		dialogList.Add(line);

		line.text = "Oh, that's fair. My friends said this place was abandoned.";
		line.color = Color.white;
		dialogList.Add(line);

		line.text = "They challenged me to stay here till 2AM so I can join their club.";
		line.color = Color.white;
		dialogList.Add(line);

		line.text = "That's kind of weird, but I get it.";
		line.color = new Color32(131, 39, 39, 255);
		dialogList.Add(line);

		line.text = "Yeah. So what's up with the creepy piano music that's been playing since I got here?";
		line.color = Color.white;
		dialogList.Add(line);

		line.text = "Oh, that's just my old player piano up in the attic.";
		line.color = new Color32(131, 39, 39, 255);
		dialogList.Add(line);

		line.text = "It's a bit out of tune, and sometimes it just starts on it's own.";
		line.color = new Color32(131, 39, 39, 255);
		dialogList.Add(line);

		line.text = "...Well I just feel silly, haha. I think I should head out, my friends will be here soon, anyway.";
		line.color = Color.white;
		dialogList.Add(line);

		line.text = "Sorry to bother you!";
		line.color = Color.white;
		dialogList.Add(line);

		UIManager.Instance.dialogManager.DisplayTextSequenceUIWithCallback(dialogList, delegate {
			StartCoroutine(PlayerEscape());
		});		
	}

	IEnumerator PlayerEscape() {
		MovementController playerMovement = playerInput.GetComponent<MovementController>();
		playerMovement.Move(new Vector2(-1f, 0f));
		yield return new WaitForSeconds(0.9f);
		playerMovement.Move(new Vector2(0f, -1f));
		yield return new WaitForSeconds(0.9f);
		playerMovement.Move(new Vector2(-1f, 0f));
		yield return new WaitForSeconds(0.9f);
		playerMovement.Move(new Vector2(-1f, 0f));
		yield return new WaitForSeconds(0.9f);
		playerMovement.Move(new Vector2(0f, -1f));
		yield return new WaitForSeconds(1f);

		List<TextLine> dialogList = new List<TextLine>();
		TextLine line = new TextLine();

		line.text = "Oh, one more thing. What's up with the pentagram and the weird portal thing in the basement?";
		line.color = Color.white;
		dialogList.Add(line);

		line.text = "Oh, that's just our portal to the Dark Lord so we can get our eternal supply of beans!";
		line.color = new Color32(131, 39, 39, 255);
		dialogList.Add(line);

		line.text = "................................................................what?";
		line.color = Color.white;
		dialogList.Add(line);

		line.text = "...";
		line.color = new Color32(131, 39, 39, 255);
		dialogList.Add(line);

		line.text = "We've said too much";
		line.color = new Color32(131, 39, 39, 255);
		dialogList.Add(line);

		UIManager.Instance.dialogManager.DisplayTextSequenceUIWithCallback(dialogList, delegate {
			StartCoroutine(GoToEnd());
		});
	}

	IEnumerator GoToEnd() {
		yield return new WaitForSeconds(0.25f);

		globalLight.intensity = 0.2f;
		globalLight.color = ogLightColor;

		Sprite ogEnemySprite = enemyPrefab.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite;
		enemy1.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = ogEnemySprite;
		enemy2.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = ogEnemySprite;
		enemy3.transform.GetChild(0).gameObject.GetComponent<SpriteRenderer>().sprite = ogEnemySprite;

		yield return new WaitForSeconds(0.25f);
		SceneManager.LoadScene("End");
	}
}

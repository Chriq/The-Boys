using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, Interactable {
	public string sceneName;

	private bool isLocked = true;
	public Sprite openSprite;
	public Sprite closedSprite;
	private RandomizeAudio audioPlayer;
	private void Start() {
		if(GameData.Instance.doorKeys[sceneName]) {
			isLocked = false;
			GetComponent<SpriteRenderer>().sprite = openSprite;
		} else {
			isLocked = true;
			GetComponent<SpriteRenderer>().sprite = closedSprite;
		}

		audioPlayer = GetComponent<RandomizeAudio>();
	}

	public void Interact() {
		if(!isLocked) {
			SceneManager.LoadScene(sceneName);
		} else if(GameData.Instance.doorKeys[sceneName]) {
			GetComponent<SpriteRenderer>().sprite = openSprite;
			SceneManager.LoadScene(sceneName);
		} else {
			audioPlayer.PlayAudio();
		}
	}
}

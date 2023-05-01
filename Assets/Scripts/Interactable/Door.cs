using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour, Interactable {
	public string sceneName;

	private bool isLocked = true;
	public Sprite openSprite;
	public Sprite closedSprite;
	private RandomizeAudio audioPlayer;
	private DialogPrompter dialog;

	private void Start() {
		if(GameData.Instance.doorKeys.ContainsKey(sceneName) && GameData.Instance.doorKeys[sceneName]) {
			isLocked = false;
			GetComponent<SpriteRenderer>().sprite = openSprite;
		} else {
			isLocked = true;
			GetComponent<SpriteRenderer>().sprite = closedSprite;
			dialog = gameObject.GetComponent<DialogPrompter>();
		}

		audioPlayer = GetComponent<RandomizeAudio>();
	}

	public void Interact() {
		if(!isLocked) {
			//GameData.Instance.lastRoomIn = SceneManager.GetActiveScene().name;
			UIManager.Instance.fadeCanvas.GetComponent<UIFade>().FadeOutWithCallback(delegate {
				SceneManager.LoadScene(sceneName);
			});
		} else if(GameData.Instance.doorKeys.ContainsKey(sceneName) && GameData.Instance.doorKeys[sceneName]) {
			GetComponent<SpriteRenderer>().sprite = openSprite;
			//GameData.Instance.lastRoomIn = SceneManager.GetActiveScene().name;
			UIManager.Instance.fadeCanvas.GetComponent<UIFade>().FadeOutWithCallback(delegate {
				SceneManager.LoadScene(sceneName);
			}, 0.5f);
		} else {
			dialog.Interact();
			audioPlayer.PlayAudio();
		}
	}
}

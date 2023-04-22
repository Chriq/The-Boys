using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour, Interactable {
	public string sceneName;

	public void Interact() {
        GameData.Instance.lastRoomIn = SceneManager.GetActiveScene().name;
		UIManager.Instance.fadeCanvas.GetComponent<UIFade>().FadeOutWithCallback(delegate {
			SceneManager.LoadScene(sceneName);
		});
	}
}

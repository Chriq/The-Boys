using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour, Interactable {
	public string sceneName;

	public void Interact() {
		SceneManager.LoadScene(sceneName);
	}
}

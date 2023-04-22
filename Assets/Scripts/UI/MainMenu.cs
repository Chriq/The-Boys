using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public UIFade fade;
	public CanvasGroup currentCanvas;

	public void StartGame() {
		SceneManager.LoadScene("Hall");
	}

	public void Quit() {
		Application.Quit();
	}

	public void SwitchCanvas(CanvasGroup next) {
		fade.canvas = currentCanvas;
		fade.FadeInWithCallback(delegate {
			currentCanvas.blocksRaycasts = false;
			fade.canvas = next;
			fade.FadeOutWithCallback(delegate {
				next.blocksRaycasts = true;
				currentCanvas = next;
			}, 0.5f);
		}, 0.5f);
	}
}

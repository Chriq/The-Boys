using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndMenu : MonoBehaviour {
	public UIFade fade;
	public CanvasGroup currentCanvas;

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

	public void Retry() {
		GameData.Instance.isPlayerChased = false;
		SceneManager.LoadScene(GameData.Instance.lastRoomIn);
	}
}

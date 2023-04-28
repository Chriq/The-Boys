using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
	public UIFade fade;
	public CanvasGroup currentCanvas;
	public CanvasGroup dialogCanvas;

	public AudioSource music;
	public AudioSource crickets;

	public void StartGame() {
		SwitchCanvas(dialogCanvas);

		List<TextLine> lines = new List<TextLine>();
		TextLine line = new TextLine();

		line.text = "I don't know about this guys, this place looks creepy.";
		line.color = Color.white;
		lines.Add(line);

		line.text = "Don't worry, this place has been abandoned for decades.";
		line.color = new Color32(131, 39, 39, 255);
		lines.Add(line);

		line.text = "Just hang out for a while, and we'll be back around 2AM.";
		line.color = new Color32(131, 39, 39, 255);
		lines.Add(line);

		line.text = "I don't know...";
		line.color = Color.white;
		lines.Add(line);

		line.text = "Hey this is your last test, once you do this, you're in.";
		line.color = new Color32(131, 39, 39, 255);
		lines.Add(line);

		line.text = "But what if someone or...something finds me?";
		line.color = Color.white;
		lines.Add(line);

		line.text = "Come on, those are just stories. Look, if you're in trouble, just hide in a closet or something.";
		line.color = new Color32(131, 39, 39, 255);
		lines.Add(line);

		line.text = "Ok fine.";
		line.color = Color.white;
		lines.Add(line);

		line.text = "See what kind of cool stuff you can find while you're there.";
		line.color = new Color32(131, 39, 39, 255);
		lines.Add(line);

		StartCoroutine(StartCrickets());
		DialogManager dialog = dialogCanvas.GetComponent<DialogManager>();
		dialog.DisplayTextSequenceUIWithCallback(lines, delegate {
			StartCoroutine(RestartMusic(delegate {
				SceneManager.LoadScene("Hall");
			}));
		});
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

	IEnumerator StartCrickets() {
		while(crickets.volume < 1f) {
			music.volume -= 0.05f;
			crickets.volume += 0.05f;
			yield return new WaitForSeconds(0.02f);
		}

		music.volume = 0f;
		crickets.volume = 1f;
	}

	IEnumerator RestartMusic(Action action) {
		while(music.volume < 1f) {
			crickets.volume -= 0.05f;
			music.volume += 0.05f;
			yield return new WaitForSeconds(0.02f);
		}

		music.volume = 1f;
		crickets.volume = 0f;

		action.Invoke();
	}
}

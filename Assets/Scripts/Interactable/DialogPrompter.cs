using System.Collections;
using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;

public class DialogPrompter : MonoBehaviour, Interactable {
	public string text;
	public float fadeSpeed = 0.5f;
	public float textSpeed = 0.03f;
	public float displaySeconds = 4f;

	public TextMeshProUGUI dialog;
	private UIFade fade;

	private void Start() {
		dialog = UIManager.Instance.dialogCanvas.GetComponentInChildren<TextMeshProUGUI>();
		fade = UIManager.Instance.dialogCanvas.GetComponent<UIFade>();
	}

	public void Interact() {
		DisplayTextUI();
	}

	public void DisplayTextUI() {
		dialog.text = "";
		if(text != "") {
			fade.FadeOutWithCallback(delegate {
				StartCoroutine("DisplayText");
			}, fadeSpeed);
		}
	}

	public void DisplayTextUIWithCallback(Action action) {
		dialog.text = "";
		if(text != "") {
			fade.FadeOutWithCallback(delegate {
				StartCoroutine(DisplayTextWithCallback(action));
			}, fadeSpeed);
		}
	}

	public void DisplayTextSequenceUI(List<TextLine> list) {
		dialog.text = "";
		fade.FadeOutWithCallback(delegate {
			StartCoroutine(DisplayTextSequence(list));
		});
	}

	public void DisplayTextSequenceUIWithCallback(List<TextLine> list, Action action) {
		dialog.text = "";
		fade.FadeOutWithCallback(delegate {
			StartCoroutine(DisplayTextSequenceWithCallback(list, action));
		});
	}

	IEnumerator DisplayText() {
		for(int i = 0; i < text.Length; i++) {
			dialog.text = dialog.text + text[i];
			yield return new WaitForSeconds(textSpeed);
		}

		yield return new WaitForSeconds(displaySeconds);

		UIManager.Instance.dialogCanvas.GetComponent<UIFade>().FadeOut(fadeSpeed);
	}

	IEnumerator DisplayTextWithCallback(Action action) {
		for(int i = 0; i < text.Length; i++) {
			dialog.text = dialog.text + text[i];
			yield return new WaitForSeconds(textSpeed);
		}

		yield return new WaitForSeconds(displaySeconds);

		UIManager.Instance.dialogCanvas.GetComponent<UIFade>().FadeOutWithCallback(action, fadeSpeed);
	}

	IEnumerator DisplayTextSequence(List<TextLine> list) {
		foreach(TextLine line in list) {
			dialog.text = "";
			dialog.color = line.color;

			for(int i = 0; i < line.text.Length; i++) {
				dialog.text = dialog.text + line.text[i];
				yield return new WaitForSeconds(textSpeed);
			}

			yield return new WaitForSeconds(displaySeconds);
		}

		UIManager.Instance.dialogCanvas.GetComponent<UIFade>().FadeIn(fadeSpeed);
	}

	IEnumerator DisplayTextSequenceWithCallback(List<TextLine> list, Action action) {
		foreach(TextLine line in list) {
			dialog.text = "";
			dialog.color = line.color;

			for(int i = 0; i < line.text.Length; i++) {
				dialog.text = dialog.text + line.text[i];
				yield return new WaitForSeconds(textSpeed);
			}

			yield return new WaitForSeconds(displaySeconds);
		}

		UIManager.Instance.dialogCanvas.GetComponent<UIFade>().FadeInWithCallback(action, fadeSpeed);
	}
}

public struct TextLine {
	public string text;
	public Color color;
}
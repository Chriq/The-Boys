using System.Collections;
using UnityEngine;
using TMPro;
using System;

public class DialogPrompter : MonoBehaviour, Interactable {
	public string text;
	public float fadeSpeed = 0.5f;
	public float textSpeed = 0.03f;
	public float displaySeconds = 4f;

	private TextMeshProUGUI dialog;
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
}

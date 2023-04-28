using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Lab : MonoBehaviour, Interactable {
	public GameObject letterCanvas;
	public InputController player;
	public AudioSource audioSource;

	private void Awake() {
		Destroy(GameObject.Find("MusicController"));
	}

	public void Interact() {
		if(letterCanvas.GetComponent<CanvasGroup>().alpha == 0) {
			letterCanvas.GetComponent<UIFade>().FadeIn();
			letterCanvas.GetComponent<CanvasGroup>().blocksRaycasts = true;
			player.movementEnabled = false;
		} else {
			letterCanvas.GetComponent<CanvasGroup>().blocksRaycasts = false;
			letterCanvas.GetComponent<UIFade>().FadeInWithCallback(delegate {
				List<TextLine> dialogList = new List<TextLine>();
				TextLine line = new TextLine();

				line.text = "...";
				line.color = new Color32(131, 39, 39, 255);
				dialogList.Add(line);

				line.text = "You're not supposed to be here.";
				line.color = new Color32(131, 39, 39, 255);
				dialogList.Add(line);

				UIManager.Instance.dialogManager.DisplayTextSequenceUIWithCallback(dialogList, delegate {
					StartCoroutine(End());
				});
			});
		}
	}

	IEnumerator End() {
		audioSource.Play();
		UIFade fade = UIManager.Instance.fadeCanvas.GetComponent<UIFade>();
		fade.FadeOut();
		yield return new WaitForSeconds(0.1f);
		fade.FadeOut();
		yield return new WaitForSeconds(0.1f);
		fade.FadeOut();
		yield return new WaitForSeconds(0.1f);
		fade.FadeOut();
		yield return new WaitForSeconds(0.1f);
		fade.FadeOut();
		yield return new WaitForSeconds(0.1f);
		fade.FadeOut();
		yield return new WaitForSeconds(0.1f);
		fade.FadeOut();
		yield return new WaitForSeconds(0.1f);
		fade.FadeOut();
		yield return new WaitForSeconds(0.1f);
		fade.FadeOut();
		yield return new WaitForSeconds(0.1f);
		fade.FadeOut();
		yield return new WaitForSeconds(0.1f);
		fade.FadeOut();
		yield return new WaitForSeconds(0.1f);

		Application.Quit();
	}
}

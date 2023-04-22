using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class Fridge : MonoBehaviour, Interactable {
	public Sprite openSprite;
	public Sprite closedSprite;
	private RandomizeAudio audioPlayer;
	private DialogPrompter dialog;

	private void Start() {
		GetComponent<SpriteRenderer>().sprite = closedSprite;
		audioPlayer = GetComponent<RandomizeAudio>();
		dialog = gameObject.GetComponent<DialogPrompter>();
	}

	public void Interact() {
		if(!GameData.Instance.doorKeys["Kitchen Fridge"]) {
			GetComponent<SpriteRenderer>().sprite = openSprite;
			GetComponentInChildren<Light2D>().enabled = true;
			dialog.text = "Huh? A can of beans? How is this supposed to help me escape!";
			StartCoroutine(CloseFridge());
		} else {
			dialog.text = "Why is the fridge locked?";
			audioPlayer.PlayAudio();
		}

		dialog.DisplayTextUI();
	}

	IEnumerator CloseFridge() {
		yield return new WaitForSeconds(3f);
		GetComponentInChildren<Light2D>().enabled = false;
		GetComponent<SpriteRenderer>().sprite = closedSprite;
		GameObject.Find("Cutscene Controller").GetComponent<CutSceneController>().Execute();
	}
}

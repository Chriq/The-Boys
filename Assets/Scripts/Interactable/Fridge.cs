using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class Fridge : MonoBehaviour, Interactable {
	public Sprite openSprite;
	public Sprite closedSprite;
	private RandomizeAudio audioPlayer;

	private void Start() {
		GetComponent<SpriteRenderer>().sprite = closedSprite;
		audioPlayer = GetComponent<RandomizeAudio>();
	}

	public void Interact() {
		if(GameData.Instance.doorKeys["Fridge"]) {
			GetComponent<SpriteRenderer>().sprite = openSprite;
			GetComponentInChildren<Light2D>().enabled = true;
		} else {
			audioPlayer.PlayAudio();
		}
	}
}

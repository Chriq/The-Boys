using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Closet : MonoBehaviour, Interactable {
	public DialogPrompter dialog;
	public RandomizeAudio audioPlayer;

	private InteractionController player;

	private void Awake() {
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<InteractionController>();
	}

	public void Interact() {
		if(GameData.Instance.isPlayerChased || player.isPlayerHidden) {
			player.ToggleHidePlayer();
		} else {
			dialog.Interact();
		}
	}
}

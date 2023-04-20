using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, Interactable {
	public Door door;
	public string sceneName;

	private DialogPrompter dialog;

	private void Start() {
		dialog = gameObject.GetComponent<DialogPrompter>();
	}

	public void Interact() {
		if(door) {
			GameData.Instance.doorKeys[door.sceneName] = true;
		} else {
			GameData.Instance.doorKeys[sceneName] = true;
		}

		gameObject.GetComponent<SpriteRenderer>().enabled = false;
		gameObject.GetComponent<BoxCollider2D>().enabled = false;

		dialog.text = $"You got the {sceneName} key.";
		dialog.DisplayTextUI();
	}
}

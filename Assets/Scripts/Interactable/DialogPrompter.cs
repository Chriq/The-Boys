using System.Collections;
using UnityEngine;
using TMPro;
using System;
using System.Collections.Generic;

public class DialogPrompter : MonoBehaviour, Interactable {
	public string text;

	public void Interact() {
		UIManager.Instance.dialogManager.text = text;
		UIManager.Instance.dialogManager.DisplayTextUI();
	}
}
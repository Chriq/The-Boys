using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour, Interactable {
	public Door door;
	public string sceneName;

	public void Interact() {
		if(door) {
			GameData.Instance.doorKeys[door.sceneName] = true;
		} else {
			GameData.Instance.doorKeys[sceneName] = true;
		}
		
		Destroy(gameObject);
	}
}

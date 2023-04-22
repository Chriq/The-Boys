using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBedroomComplete : MonoBehaviour, OnRoomComplete {
	public SpriteRenderer safe;
	public Sprite openSprite;

	public void Execute() {
		safe.sprite = openSprite;
	}
}

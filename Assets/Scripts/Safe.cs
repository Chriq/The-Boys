using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : MonoBehaviour {
	public Sprite openSprite;
	public GameObject key;

	public void Open() {
		GetComponent<SpriteRenderer>().sprite = openSprite;
	}

}

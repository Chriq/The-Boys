using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour {
	private static UIManager instance;

	public GameObject dialogCanvas;
	public GameObject puzzleCanvas;

	public static UIManager Instance {
		get { return instance; }
	}

	private void Awake() {
		instance = this;
	}
}

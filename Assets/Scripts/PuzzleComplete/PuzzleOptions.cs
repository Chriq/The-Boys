using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleOptions : MonoBehaviour {
	public Crystal crystal;

    public void ResetPuzzle() {
		UIManager.Instance.fadeCanvas.GetComponent<UIFade>().FadeOutWithCallback(delegate {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		});
    }

	public void SolvePuzzle() {
		crystal.Activate();
	}
}

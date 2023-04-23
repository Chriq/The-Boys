using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class Crystal : MonoBehaviour {
	public GameObject key;
	public Color color = Color.white;
	public GameObject onRoomCompleteObj;
	private OnRoomComplete onRoomComplete;

	private void Awake() {
		GetComponent<SpriteRenderer>().color = color;
		transform.GetChild(0).GetComponent<Light2D>().color = color;
		if(onRoomCompleteObj != null ) {
			onRoomComplete = onRoomCompleteObj.GetComponent<OnRoomComplete>();
		}
	}

	public void Activate() {
		key.SetActive(true);
		GameData.Instance.completedRooms[SceneManager.GetActiveScene().name] = true;
		GameData.Instance.lastRoomCompleted = SceneManager.GetActiveScene().name;
		if(onRoomComplete != null) {
			onRoomComplete.Execute();
		}
		UIManager.Instance.puzzleCanvas.GetComponent<UIFade>().FadeOut();
		UIManager.Instance.puzzleCanvas.GetComponent<CanvasGroup>().blocksRaycasts = false;
		Destroy(gameObject);
	}
}

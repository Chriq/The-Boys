using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class Crystal : MonoBehaviour {
	public GameObject key;
	public Color color = Color.white;

	private void Awake() {
		GetComponent<Light2D>().color = color;
		transform.GetChild(0).GetComponent<Light2D>().color = color;
	}

	public void Activate() {
		key.SetActive(true);
		GameData.Instance.completedRooms[SceneManager.GetActiveScene().name] = true;
		Destroy(gameObject);
	}
}

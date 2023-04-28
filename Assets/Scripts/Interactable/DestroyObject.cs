using UnityEngine;

public class DestroyObject : MonoBehaviour, Interactable {

	public void Interact() {
		Destroy(gameObject);
	}
}

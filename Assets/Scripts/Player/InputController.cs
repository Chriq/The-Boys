using UnityEngine;

public class InputController : MonoBehaviour {

	public MovementController movementController;

	private void Update() {
		Vector2 input = Vector2.zero;

		if(Input.GetKey(KeyCode.W)) {
			input = Vector2.up;
		} else if(Input.GetKey(KeyCode.A)) {
			input = Vector2.left;
		} else if(Input.GetKey(KeyCode.S)) {
			input = Vector2.down;
		} else if(Input.GetKey(KeyCode.D)) {
			input = Vector2.right;
		}

		if(input != Vector2.zero) {
			movementController.Move(input);
		}
	}
}

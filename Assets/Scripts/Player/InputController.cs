using UnityEngine;

public class InputController : MonoBehaviour {

	public MovementController movementController;
	public InteractionController interactionController;
	public bool movementEnabled = true;

	private void Update() {
		if (movementEnabled) {
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
		
		if(Input.GetKeyDown(KeyCode.E)) {
			interactionController.Interact(movementController.transform.position + movementController.currentDirection);
		} else if(Input.GetKeyDown(KeyCode.F)) {
			interactionController.ShineFlashlight(movementController.currentDirection);
		}

		if(Input.GetKeyUp(KeyCode.F)) {
			interactionController.TurnOffFlashlight();
		}
	}
}

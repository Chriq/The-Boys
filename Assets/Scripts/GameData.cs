using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour {
	public Dictionary<string, bool> doorKeys;
	public Dictionary<string, bool> completedRooms;
	public bool isPlayerChased = false;
	public string lastRoomCompleted = "";
	public string lastRoomIn = "";

	private static GameData _instance;
	public static GameData Instance {
		get {
			return _instance;
		}
	}

	private void Awake() {
		GameData[] objs = FindObjectsOfType<GameData>();

		if(objs.Length > 1) {
			Destroy(this.gameObject);
		} else {
			_instance = this;

			doorKeys = new Dictionary<string, bool> {
				{"Hall", false },
				{"MainRoom", false },
				{"Kitchen", false },
				{"Bedroom", false },
				{"Bathroom", false },
				{"Basement", false },
				{"Kitchen Fridge", false },
				{"QlJOLUNZLUE1MDI6IENhcnNvbiwgTWlsbGVyICYgU3RldmVucw==", false }
			};

			completedRooms = new Dictionary<string, bool> {
				{"Hall", false },
				{"MainRoom", false },
				{"Kitchen", false },
				{"Bedroom", false },
				{"Bathroom", false },
				{"Basement", false },
				{"QlJOLUNZLUE1MDI6IENhcnNvbiwgTWlsbGVyICYgU3RldmVucw==", false }
			};

			DontDestroyOnLoad(this);
		}
	}
}

using UnityEngine;

public class StateManager {
	public static bool paused = false;


	// ------------------------------ GET / SET ------------------------------ //
	public static void SetPaused(bool pause) {
		paused = pause;
	}

	public static bool GetPaused() {
		return paused;
	}

}

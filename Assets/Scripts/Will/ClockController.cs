using UnityEngine;
using System;
using System.Collections;

public class ClockController : MonoBehaviour {
	// Factor used to create in-game time; 60secs IRL is 1h in-game
	public float timeFactor = 60f;
	// Game starts at 06am
	public float worldTime = 21600f;
	// Used to pause time on item interactions
	public bool paused = false;

	void Update () {
		if (!paused)
			worldTime = (worldTime + timeFactor * Time.deltaTime) % 86400f;
	}

	void OnGUI() {
		TimeSpan timeSpan = TimeSpan.FromSeconds(worldTime);
		GUI.Label(new Rect(10, 10, 100, 20), 
			string.Format("{0:D2}:{1:D2}", timeSpan.Hours, timeSpan.Minutes));
	}
}
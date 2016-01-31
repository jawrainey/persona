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
	// ??
	public int health = 100;

	void Update () {
		// Should we have a pause function here instead of 
		// an update function... that way, no need for public variables
		// we can simply ask to pause the clock for a specific reason?
		if (!paused)
			worldTime = (worldTime + timeFactor * Time.deltaTime) % 86400f;
	}

	void OnGUI() {
		TimeSpan timeSpan = TimeSpan.FromSeconds(worldTime);
		// Time of date in-game; the ritual of being at a place at a specific time!
		GUI.Label(new Rect(10, 10, 100, 20), 
			string.Format("{0:D2}:{1:D2}", timeSpan.Hours, timeSpan.Minutes));
		// Credibility health
		GUI.Label(new Rect(80, 10, 100, 20), health.ToString() + "%");
	}
}
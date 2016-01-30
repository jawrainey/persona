using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CredibilityController : MonoBehaviour {

	public float credibility = 100f;

	public GameObject foreground;
	public GameObject background;
	float nextpunish = 0;

	float worldTime = 0;


	// A horrible hack... 
	// The int is seconds that represent time of day (19:00 and 20:00) and
	// String represents the name of the object overlayed at the scheledued location,
	// e.g. where the character should be at a given point in time.
	public Dictionary<int, string> schedule = new Dictionary<int, string> () {
		{0, "CubeOne"},
		{3600, "CubeOne"},
		{7200, "CubeOne"},
		{10800, "CubeOne"},
		{14400, "CubeOne"},
		{18000, "CubeOne"},
		{21600, "CubeOne"},
		{25200, "CubeOne"},
		{28800, "CubeOne"},
		{32400, "CubeOne"},
		{36000, "CubeOne"},
		{39600, "CubeOne"},
		{43200, "CubeOne"},
		{46800, "CubeOne"},
		{50400, "CubeOne"},
		{54000, "CubeOne"},
		{57600, "CubeOne"},
		{61200, "CubeOne"},
		{64800, "CubeOne"},
		{68400, "CubeOne"},
		{72000, "CubeOne"},
		{75600, "CubeOne"},
		{79200, "CubeOne"},
		{82800, "CubeOne"}
	};

	// Update is called once per frame
	void Update () {
		updateBar ();

		worldTime = GameObject.Find ("ClockController").GetComponent<ClockController> ().worldTime;

		if (worldTime > nextpunish) {
			detectSchedule ();
		}
	}

	void updateBar() {
		Vector2 backgroundScale = new Vector2 (background.GetComponent<Transform> ().localScale.x, 0);
		Vector2 scale = (backgroundScale * (credibility / 100) + new Vector2(0, 0.4f));
		foreground.GetComponent<Transform> ().localScale = scale;
		// relative to position of background
		Vector2 position = new Vector2 (0 - backgroundScale.x * (100 - credibility) / 200,0) + new Vector2(background.GetComponent<Transform>().position.x, background.GetComponent<Transform>().position.y);
		foreground.GetComponent<Transform> ().position = new Vector3(position.x, position.y, -1);
	}

	// 
	void detectSchedule() {

		foreach (KeyValuePair<int, string> entry in schedule) {
			// 3600 per min
			// {68400, "CubeOne"}
			if (entry.Key == (Mathf.Floor (worldTime / 3600) * 3600)) {
				var box = GameObject.Find (entry.Value);
				// work out bounding box :: t means scheledLocation
				var t = box.GetComponent<Transform>();

				// four edges
				var leftEdge = t.position.x - t.localScale.x / 2;
				var rightEdge = t.position.x + t.localScale.x / 2;
		
				var bottomEdge = t.position.y - t.localScale.y / 2;
				var topEdge = t.position.y + t.localScale.y / 2;

				// check if player is within X area.
				var player = GameObject.Find("Player").GetComponent<Transform>();

				// Hi Will, this was fixed.. over to you!
				if (!(player.position.x < rightEdge && player.position.x > leftEdge) &&
					!(player.position.y < bottomEdge && player.position.y > topEdge)) 
				{
					credibility -= 20;
					// We will eventually show this on-screen, but for now, I'm printing it to the console
					print ("-20 -- Missed Event: " + entry.Value); 
					// Cooldown: cannot lose points during this time.
					nextpunish = (entry.Key + 3600) % 86400;
				}
			}
		}

	}

	void GameOver() {
		// if credability <= 0; send to a new sceen where we display a new game over and return menu
	}
}

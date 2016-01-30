using UnityEngine;
using System.Collections;

public class AClockController : MonoBehaviour {
	// ??
	public float timeFactor = 60f;
	public float worldTime = 21600f;
	// ??
	public GameObject clockFace;
	public GameObject clockHand; 
	// Used inside ImageSplashTagOut
	public bool paused = false;
	// ??
	Transform faceTransform;
	Transform handTransform;
	
	// Update is called once per frame
	void Update () {
		
		// clock stuff
		if (paused == false) {
			worldTime = (worldTime + timeFactor * Time.deltaTime) % 86400f;
		}

		faceTransform = clockFace.GetComponent<Transform>();
		handTransform = clockHand.GetComponent<Transform>();

		var angle = 360f * (worldTime / 43200f);
		// Find relative position of clock hand
		float adjacent = Mathf.Cos (angle * Mathf.Deg2Rad) * handTransform.localScale.y;
		float opposite = Mathf.Sin (angle * Mathf.Deg2Rad) * handTransform.localScale.y;
		// calcualtes real position of clock hand
		Vector3 pos = new Vector3 (opposite/2, adjacent/2, 0) + faceTransform.position;
		handTransform.position = pos;
		// Managing the rotation hand of the clock.
		Quaternion rot = Quaternion.AngleAxis (angle, new Vector3 (0, 0, -30));
		handTransform.localRotation = rot;
	}
}

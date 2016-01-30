using UnityEngine;
using System.Collections;

public class ImageSplashTagOut : MonoBehaviour {

	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			GameObject.Find ("ImageSplash").GetComponent<Transform> ().position = new Vector3 (-10000000000, 0, 0);
			GameObject.Find ("ClockController").GetComponent<ClockController> ().paused = false;
		}
	}
}
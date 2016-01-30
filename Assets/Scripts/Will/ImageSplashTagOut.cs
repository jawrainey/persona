using UnityEngine;
using System.Collections;

public class ImageSplashTagOut : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			var imS = GameObject.Find ("ImageSplash");
			imS.GetComponent<Transform> ().position = new Vector3 (-10000000000, 0, 0);
			GameObject.Find ("ClockController").GetComponent<AClockController> ().paused = false;
			}
		}
	}


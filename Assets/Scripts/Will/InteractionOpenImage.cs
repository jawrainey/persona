using UnityEngine;
using System.Collections;

public class InteractionOpenImage : MonoBehaviour {
	// Use this for initialization
	Transform playerTransform;
	public float interactionRange = 5f;
	public float timesInteracted = 0f;
	float debounceTime = 0f;
	public float debouncing = 2f;
	// ?
	public Sprite shownImage;
	
	// Update is called once per frame
	void Update () {
		debounceTime = debounceTime - Time.deltaTime;
	}

	void Interacted() {
		timesInteracted = timesInteracted + 1;
		debounceTime = debouncing;
		//
		var clock = GameObject.Find ("ClockController");
		clock.GetComponent<ClockController> ().paused = true;
		//
		var splash = GameObject.Find ("ImageSplash");
		splash.GetComponent<SpriteRenderer> ().sprite = shownImage;
		// moves splash in front of camera vision
		var t = splash.GetComponent<Transform> ();
		t.position = GameObject.Find ("Main Camera").GetComponent <Transform>().position + new Vector3 (0, 0, 1);
	}

	void OnMouseOver(){
		if (Input.GetMouseButtonDown (0)) {
			playerTransform = GameObject.Find("Player").GetComponent<Transform>();
			var p = playerTransform.position;
			p = p - transform.position;
			float q = p.magnitude;
			if ((q < interactionRange) && (debounceTime <= 0)) {
				Interacted ();
			}
		}
	}
}

using UnityEngine;
using System.Collections;

public class AABasicInteraction : MonoBehaviour {
	
	// Use this for initialization
	Transform playerTransform;

	public float interactionRange = 5f;
	public float timesInteracted = 0f;
	// restrict time between clicks
	public float debouncing = 2f;
	// 
	float debounceTime = 0f;

	void Update () {
		debounceTime = debounceTime - Time.deltaTime;
	}

	void OnMouseOver(){
		if (Input.GetMouseButtonDown (0)) {
			// ??
			var playerPosition = GameObject.Find("Player").GetComponent<Transform>().position;
			// ??
			var distance = (playerPosition - transform.position).magnitude;
			// ??
			if ((distance < interactionRange) && (debounceTime <= 0)) {
				timesInteracted = timesInteracted + 1;
				debounceTime = debouncing;
				// Interacted ();
			}
		}
	}
}

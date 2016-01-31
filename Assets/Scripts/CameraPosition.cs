using UnityEngine;
using System.Collections;

public class CameraPosition : MonoBehaviour {

	public float xOffset = 0;
	public float yOffset = 2.3f;
	private Vector3 distance;

	void Start() {
		// measuring the camera-player distance at initialisation
		distance = transform.position - GameObject.Find ("Player").transform.position;
	}

	void Update () {
		//Vector3 playerPosition = GameObject.Find ("Player").transform.position + new Vector3(xOffset,yOffset, 0);
		Vector3 playerPosition = GameObject.Find ("Player").transform.position + distance;
		// Players position is relative to camera
		playerPosition.z = transform.position.z;
		// Camera position is players current position
		transform.position = playerPosition;

	}
}
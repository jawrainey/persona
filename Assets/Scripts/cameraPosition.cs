using UnityEngine;
using System.Collections;

public class cameraPosition : MonoBehaviour {

	private Transform player;

	public float xOffset = 0;
	public float yOffset = 2.3f;

	void Start () {
		player = GameObject.Find ("Player").transform;
	}
	
	void Update () {
		Vector3 playerPosition = player.position + new Vector3(xOffset,yOffset, 0);
		// Players position is relative to camera
		playerPosition.z = transform.position.z;
		// Camera position is players current position
		transform.position = playerPosition;
	
	}
}

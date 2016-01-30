using UnityEngine;
using System.Collections;

public class CameraPosition : MonoBehaviour {

	public float xOffset = 0;
	public float yOffset = 2.3f;

	void Update () {
		transform.position = GameObject.Find ("Player").transform.position + new Vector3(xOffset,yOffset, transform.position.z);	
	}
}

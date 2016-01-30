using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 5;

	void Update () {
		Vector2 movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

		GetComponent<Rigidbody2D>().velocity = movement * speed;
	}
}

using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed = 5;

	private float direction;

	void Start() {
		direction = transform.localScale.x;
	}

	void Update () {
		// Direction in the plane
		float velocity = 0;
		// Set the direction from the known velocity.
		if (Input.GetKey("right")) velocity = speed;
		if (Input.GetKey("left")) velocity = -speed;
		// The speed to move in the given direction
		transform.Translate(velocity * Time.deltaTime, 0, 0);
		// right
		if (velocity > 0)
			transform.localScale = new Vector2(direction, transform.localScale.y);
		// left
		else if (velocity < 0)
			transform.localScale = new Vector2(-direction, transform.localScale.y);

	}
}
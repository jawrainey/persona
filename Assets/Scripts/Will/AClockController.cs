using UnityEngine;
using System.Collections;

public class AClockController : MonoBehaviour {
	public float timeFactor = 60f;
	public float worldTime = 21600f;
	public GameObject clockFace;
	public GameObject clockHand; 
	public bool paused = false;
	Transform faceTransform;
	Transform handTransform;
	public float credibility = 100f;
	public GameObject credibilityMeterBack;
	public GameObject credibilityMeter;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		// clock stuff
		if (paused == false) {
			worldTime = worldTime + timeFactor * Time.deltaTime;
		}
		if (worldTime > 86400f) {
			worldTime = worldTime - 86400f;
		}

		faceTransform = clockFace.GetComponent<Transform>();
		handTransform = clockHand.GetComponent<Transform>();
		var angle = 360f * (worldTime / 43200f);
		float adjacent = Mathf.Cos (angle * Mathf.Deg2Rad) * handTransform.localScale.y;
		float opposite = Mathf.Sin (angle * Mathf.Deg2Rad) * handTransform.localScale.y;
		Vector3 pos = new Vector3 (opposite/2, adjacent/2, 0) + faceTransform.position;
		handTransform.position = pos;
		Quaternion rot = Quaternion.AngleAxis (angle, new Vector3 (0, 0, -30));
		handTransform.localRotation = rot;

		// Credability
		// var cmt = credibilityMeter.GetComponent<Transform> ();
		// var cmbt = credibilityMeterBack.GetComponent<Transform> ();
		// cmt.position = new Vector3 (cmbt.position.x, (credibility / 100f * 2.88f - 2.88f) / 2f + cmbt.position.y, cmt.position.z);
		// cmt.localScale = new Vector3 (0.22f, credibility / 100f * 2.88f, 1f);

	}
}

using UnityEngine;
using System.Collections;

public class LoadOnClick : MonoBehaviour {

	public string scene;

	void OnMouseOver() {
		if (Input.GetMouseButtonDown (0)) {
			UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
		}
	}
}
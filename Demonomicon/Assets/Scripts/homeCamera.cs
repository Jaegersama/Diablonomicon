using UnityEngine;
using System.Collections;

public class homeCamera : MonoBehaviour {

	private float currentLerpTime = 0;

	public bool clicked;

	float currentSize = 4;
	float targetSize = 3.5f;

	private bool onlyOnce;

	private Vector3 currentPosition = new Vector3(0,-1,-10);
	public Vector3 target = new Vector3(0,0,-10);

	// Use this for initialization
	void Start () {
		transform.position = currentPosition;
		currentLerpTime = 0.0f;
		clicked = false;
		onlyOnce = false;
	}
	
	// Update is called once per frame
	void Update () {
		currentLerpTime += Time.deltaTime;
		if (clicked) {
			if (!onlyOnce) {
				onlyOnce = true;
				currentLerpTime = 0;
			}
			GetComponent<Camera>().orthographicSize = Mathf.SmoothStep( targetSize, currentSize, currentLerpTime);
		} else {
			GetComponent<Camera>().orthographicSize = Mathf.SmoothStep( currentSize, targetSize, currentLerpTime * 0.4f);
			transform.position = new Vector3(
									Mathf.SmoothStep( currentPosition.x, target.x, currentLerpTime * 0.4f),
									Mathf.SmoothStep( currentPosition.y, target.y, currentLerpTime * 0.4f),
									-10);
		}
	}
}	

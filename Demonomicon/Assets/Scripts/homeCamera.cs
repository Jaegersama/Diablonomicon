using UnityEngine;
using System.Collections;

public class homeCamera : MonoBehaviour {

	private float currentLerpTime = 0;

	float currentSize = 4;
	float targetSize = 3.5f;

	private Vector3 currentPosition = new Vector3(0,-1,-10);
	public Vector3 target = new Vector3(0,0,-10);

	// Use this for initialization
	void Start () {
		transform.position = currentPosition;
		currentLerpTime = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		currentLerpTime += Time.deltaTime / 2;
		GetComponent<Camera>().orthographicSize = Mathf.SmoothStep( currentSize, targetSize, currentLerpTime);
		transform.position = new Vector3(
								Mathf.SmoothStep( currentPosition.x, target.x, currentLerpTime),
								Mathf.SmoothStep( currentPosition.y, target.y, currentLerpTime),
								-10);
	}
}	

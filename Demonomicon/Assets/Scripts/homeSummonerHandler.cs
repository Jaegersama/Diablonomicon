using UnityEngine;
using System.Collections;

public class homeSummonerHandler : MonoBehaviour {
	public bool clicked;

	private float currentLerpTime = 0;

	private bool onlyOnce;
	private AudioSource footsteps;

	private Vector3 target = new Vector3( 1,0,-0.1f);
	private Vector3 currentPosition = new Vector3(-1.61f,1.69f,-0.1f);

	// Use this for initialization
	void Start () {
		clicked = false;
		onlyOnce = false;
		footsteps = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (clicked) {
			if (!onlyOnce) {
				onlyOnce = true;
				footsteps.Play();
			}
			currentLerpTime += Time.deltaTime;
			transform.position = new Vector2(
								Mathf.SmoothStep( currentPosition.x, target.x, currentLerpTime),
								Mathf.SmoothStep( currentPosition.y, target.y, currentLerpTime));
		}
	}
}

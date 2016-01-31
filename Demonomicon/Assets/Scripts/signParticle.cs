using UnityEngine;
using System.Collections;

public class signParticle : MonoBehaviour {

	public Sprite[] images;

	private float speed;
	private float pitch;
	private float baseSpeed;
	private float basePitch;
	private float accumulator;

	void Start () {
		Vector2 startPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0,Screen.width), Random.Range(0,Screen.height), Camera.main.farClipPlane/2));
		transform.position = startPosition;

		int n = Random.Range(0,4);
		GetComponent<SpriteRenderer>().sprite = images[n];
		GetComponent<SpriteRenderer>().color = new Color(243/255.0f,0/255.0f,5/255.0f);
		
		speed = Random.Range(0.2f,1.0f);
		baseSpeed = speed;
		accumulator = 0;
		basePitch = 0;
		pitch = 0;
	}
	
	void FixedUpdate () {
		accumulator = accumulator + Time.deltaTime;
		speed = baseSpeed + (Mathf.Sin(accumulator) * 10) * Time.deltaTime;
		pitch = basePitch + (Mathf.Cos(accumulator) + Mathf.Sin( accumulator * 0.3f )) * Time.deltaTime;

		Vector2 newPosition = transform.position;
		transform.position = newPosition + new Vector2((speed + pitch) / 2 * Time.deltaTime,(speed) * Time.deltaTime);
	}
}
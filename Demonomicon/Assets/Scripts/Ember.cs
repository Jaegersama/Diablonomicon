using UnityEngine;
using System.Collections;

public class Ember : MonoBehaviour {
	public Sprite[] images;

	public float speed;
	public float pitch;
	public float baseSpeed;
	public float basePitch;
	private float accumulator;

	public bool customColor = false;
	public Color particleColor;
	public bool customScale = false;
	public float scaleOverride;

	void Start () {
		Vector2 startPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0,Screen.width), Random.Range(0,Screen.height), Camera.main.farClipPlane/2));
		transform.position = startPosition;

		int n = Random.Range(0,7);
		GetComponent<SpriteRenderer>().sprite = images[n];

		speed = Random.Range(2.0f,6.0f);
		baseSpeed = speed;
		accumulator = 0;
		basePitch = 0;
		pitch = 0;

		float scale = Random.Range(2.0f,3.5f);
		Vector2 s;
		if (customScale) {
			s = new Vector2(scaleOverride,scaleOverride);
		} else {
			s = new Vector2(scale,scale);
		}
		transform.localScale = s;
		GetComponent<SpriteRenderer>().color = new Color(220/255.0F,95/255.0F,65/255.0F,67/255.0F);
		if (customColor) {
			GetComponent<SpriteRenderer>().color = particleColor;
		}
	}
	
	void FixedUpdate () {
		accumulator = accumulator + Time.deltaTime;
		speed = baseSpeed - (Mathf.Sin(accumulator) * 10) * Time.deltaTime;
		pitch = basePitch - (Mathf.Cos(accumulator) + Mathf.Sin( accumulator * 0.8f )) * Time.deltaTime;

		Vector2 newPosition = transform.position;
		transform.position = newPosition + new Vector2((speed + pitch) * Time.deltaTime, speed/3 * Time.deltaTime);

		int inset = 3;
		Vector3 screenPoint = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x,transform.position.y,Camera.main.farClipPlane/2));
		if  (screenPoint.x > Screen.width + inset + 1) {
			Vector2 position = Camera.main.ScreenToWorldPoint(new Vector3(-inset, transform.position.y, Camera.main.farClipPlane/2));
			transform.position = new Vector2(position.x,transform.position.y);	
		}
		if (screenPoint.y >  Screen.height + inset + 1) {
			Vector2 position = Camera.main.ScreenToWorldPoint(new Vector3(transform.position.x, -inset, Camera.main.farClipPlane/2));
			transform.position = new Vector2(transform.position.x,position.y);	
		}
	
	}
}

using UnityEngine;
using System.Collections;

public class Particle : MonoBehaviour {
	public Sprite[] images;

	public float speed;
	public float pitch;
	public float baseSpeed;
	public float basePitch;
	private float accumulator;

	void Start () {
		Vector2 startPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0,Screen.width), Random.Range(0,Screen.height), Camera.main.farClipPlane/2));
		transform.position = startPosition;

		int n = Random.Range(0,7);
		GetComponent<SpriteRenderer>().sprite = images[n];
		GetComponent<SpriteRenderer>().color = new Color(48/255.0f,94/255.0f,144/255.0f);

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
		transform.position = newPosition + new Vector2((speed + pitch) * Time.deltaTime,-(speed) * Time.deltaTime);

        Quaternion target = Quaternion.Euler(0, Input.GetAxis("Horizontal") * pitch, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 1.0F);

		int inset = 3;
		Vector3 screenPoint = Camera.main.WorldToScreenPoint(new Vector3(transform.position.x,transform.position.y,Camera.main.farClipPlane/2));
		if  (screenPoint.x > Screen.width + inset + 1) {
			Vector2 position = Camera.main.ScreenToWorldPoint(new Vector3(-inset, transform.position.y, Camera.main.farClipPlane/2));
			transform.position = new Vector2(position.x,transform.position.y);	
		}
		if (screenPoint.y <  -inset + 1) {
			Vector2 position = Camera.main.ScreenToWorldPoint(new Vector3(transform.position.x, Screen.height, Camera.main.farClipPlane/2));
			transform.position = new Vector2(transform.position.x,position.y);	
		}

	}
}
//GetComponent<SpriteRenderer>().color = new Color(92/255.0F,109/255.0F,173/255.0F,255/255.0F);
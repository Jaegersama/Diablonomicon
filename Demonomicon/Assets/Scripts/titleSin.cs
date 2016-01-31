using UnityEngine;
using System.Collections;

public class titleSin : MonoBehaviour {

	private float t = 0;
	private Vector2 initialPosition;

	// Use this for initialization
	void Start () {
		initialPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime;
		transform.position = initialPosition + new Vector2(0,Mathf.Sin(t/2)/3);;
	}
}

using UnityEngine;
using System.Collections;

public class EmberHandler : MonoBehaviour {

	public Object ember;
	private bool customColor;
	private bool customScale;

	// Use this for initialization
	void Start () {
		int emberLimit = 12;
		customColor = true;
		customScale = true;
		for (int i = 0; i < emberLimit; i++) {
			GameObject p = Instantiate(ember, transform.position, transform.rotation) as GameObject;
			p.GetComponent<Ember>().customColor = customColor;
			p.GetComponent<Ember>().particleColor = new Color(243/255.0f,0/255.0f,5/255.0f,1);
			p.GetComponent<Ember>().customScale = customScale;
			p.GetComponent<Ember>().scaleOverride = 1.0f;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

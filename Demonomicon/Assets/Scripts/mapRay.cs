using UnityEngine;
using System.Collections;

public class mapRay : MonoBehaviour {
	public SpriteRenderer rend;
    private float t = 0;
    public Color lerpedColor = new Color(192/255.0F,134/255.0F,87/255.0F,0.25f);
	
	// Use this for initialization
	void Start () {
		rend = GetComponent<SpriteRenderer>();
		rend.color = new Color(192/255.0F,134/255.0F,87/255.0F,0.25f);
	}
	
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime;
		lerpedColor = Color.Lerp( new Color(192/255.0F,134/255.0F,87/255.0F,0.25f), new Color(192/255.0F,134/255.0F,87/255.0F,0.6F), Mathf.PingPong(t/4, 1.0f) );
		rend.color = lerpedColor;
	}
}

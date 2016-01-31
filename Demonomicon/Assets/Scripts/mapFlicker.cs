using UnityEngine;
using System.Collections;

public class mapFlicker : MonoBehaviour {

    public SpriteRenderer rend;
    private float t = 0;
    public Color lerpedColor = new Color(1,1,1,0.1f);

	// Use this for initialization
	void Start () {
		rend = GetComponent<SpriteRenderer>();
		rend.color = new Color(1,1,1,0.1f);
	}
	
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime;
		lerpedColor = Color.Lerp( new Color(1,1,1,0.5f), new Color(1,1,1,0.6f), Mathf.PingPong(t*1.2f, 1.0f) ) 
					- Color.Lerp( new Color(1,1,1,0.3f), new Color(1,1,1,0.1f), Mathf.Cos(t*0.4f) ) 
					+ Color.Lerp( new Color(1,1,1,0.4f), new Color(1,1,1,0.3f), Mathf.Sin(t*1.8f) ) 
					+ Color.Lerp( new Color(1,1,1,0.1f), new Color(1,1,1,0.2f), Mathf.Sin(t*4f) );

		rend.color = lerpedColor;
	}
}
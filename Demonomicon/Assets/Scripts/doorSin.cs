using UnityEngine;
using System.Collections;

public class doorSin : MonoBehaviour {

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
		lerpedColor = Color.Lerp( new Color(1,1,1,0.1f), new Color(1,1,1,1), Mathf.PingPong(t*1.2f, 2.0f) );
		rend.color = lerpedColor;
	}
}

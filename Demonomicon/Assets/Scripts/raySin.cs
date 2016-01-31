using UnityEngine;
using System.Collections;

public class raySin : MonoBehaviour {
    public SpriteRenderer rend;
    private float t = 0;
    public Color lerpedColor = new Color(92/255.0F,109/255.0F,173/255.0F,0.25f);

	// Use this for initialization
	void Start () {
		rend = GetComponent<SpriteRenderer>();
		rend.color = new Color(92/255.0F,109/255.0F,173/255.0F,0.25f);
	}
	
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime;
		lerpedColor = Color.Lerp( new Color(92/255.0F,109/255.0F,173/255.0F,0.25f), new Color(92/255.0F,109/255.0F,173/255.0F,0.4F), Mathf.PingPong(t/2, 1.0f) );
		rend.color = lerpedColor;
	}

	void OnMouseEnter () {
		Debug.Log("HM!");
	}
}

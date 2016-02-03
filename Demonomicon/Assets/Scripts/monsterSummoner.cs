using UnityEngine;
using System.Collections;

public class monsterSummoner : MonoBehaviour {
    public SpriteRenderer rend;
    private float t = 0;
    public Color lerpedColor = new Color(1,1,1,0.0f);
    private Vector2 scaler = new Vector2 (0.4f,0.4f);

	// Use this for initialization
	void Start () {
		rend = GetComponent<SpriteRenderer>();
		rend.color = new Color(1,1,1,0.0f);
		transform.localScale = new Vector2(0.4f,0.4f);
	}
	
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime;
		lerpedColor = Color.Lerp( new Color(1,1,1,0.0f), new Color(1,1,1,1), t );
		rend.color = lerpedColor;
		scaler = new Vector2(Mathf.SmoothStep(0.4f,0.6f,t),Mathf.SmoothStep(0.4f,0.6f,t));
		transform.localScale = scaler;
	}
}

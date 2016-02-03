using UnityEngine;
using System.Collections;

public class cometHandler : MonoBehaviour {
	Vector2 targetEnd;
	Vector3 targetHead;
	Vector3 targetTail;
	float currentLerpTime = 0;
	float delayTime = 0;
	public LineRenderer render;
	float cometAlpha;

	// Use this for initialization
	void Start () {
		cometAlpha = 0.0f;
		currentLerpTime = 0;
		delayTime = 0;
		transform.position = new Vector3(0,0,-0.1f);
		targetHead = transform.position;
		targetTail = transform.position;
		targetEnd = new Vector2(8,4);
		render = GetComponent<LineRenderer>();
		render.material = new Material(Shader.Find("Particles/Additive"));
		Color c1 = new Color(25/255.0F,47/255.0F,78/255.0F,cometAlpha);
		Color c2 = new Color(87/255.0F,99/255.0F,99/255.0F,cometAlpha);
        render.SetColors(c1, c2);
	}
	
	// Update is called once per frame
	void Update () {
		delayTime += Time.deltaTime;
		if (delayTime > 5) {
			currentLerpTime += Time.deltaTime/10;
			cometAlpha = Mathf.SmoothStep( 0.1f, 1.0f, currentLerpTime*10);

			Color c1 = new Color(25/255.0F,47/255.0F,78/255.0F,cometAlpha);
			Color c2 = new Color(87/255.0F,99/255.0F,99/255.0F,cometAlpha);
	        render.SetColors(c1, c2);

			targetHead = new Vector3(	Mathf.SmoothStep( targetHead.x, targetEnd.x, currentLerpTime),
						  				Mathf.SmoothStep( targetHead.y, targetEnd.y, currentLerpTime),
						  				-0.1f);
			targetTail = new Vector3(	Mathf.SmoothStep( targetTail.x, targetEnd.x, (currentLerpTime-0.01f)),
						  				Mathf.SmoothStep( targetTail.y, targetEnd.y, (currentLerpTime-0.01f)),
						  				-0.1f);
			render.SetPosition(0,targetHead);
			render.SetPosition(1,targetTail);
		}
	}
}
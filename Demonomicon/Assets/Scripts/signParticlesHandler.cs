using UnityEngine;
using System.Collections;

public class signParticlesHandler : MonoBehaviour {

	public Object signParticle;
	public Vector2 position;
	public bool hoverOver = false;
	public Vector2 target;
	private bool onlyOnce = false;
	private GameObject[] particles;
	private static int emberLimit = 20;

	// Use this for initialization
	void Start () {
		bool hoverOver = false;
		bool onlyOnce = false;
		particles = new GameObject[emberLimit];
		for (int i = 0; i < emberLimit; i++) {
			GameObject p = Instantiate(signParticle, transform.position, transform.rotation) as GameObject;
			particles[i] = p;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (!hoverOver) {
			onlyOnce = false;
		}
		if (hoverOver && !onlyOnce) {
			onlyOnce = true;
			Debug.Log("HM!");
			for (int i = 0; i < particles.Length; i++) {
				Vector2 position = new Vector2(target.x + Random.Range(-0.4f,0.4f),target.y + Random.Range(-0.4f,0.4f));
				particles[i].transform.position = position;
			}
		}
	}
}

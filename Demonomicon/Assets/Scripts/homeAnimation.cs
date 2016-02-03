using UnityEngine;
using System.Collections;

public class homeAnimation : MonoBehaviour {

	private bool onlyOnce = false;
	public GameObject anim;
	public GameObject monster;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseOver () {
		if (!onlyOnce && Input.GetMouseButtonDown(0)) {
			onlyOnce = true;
			anim.SetActive(true);
			monster.SetActive(true);
		}
	}
}

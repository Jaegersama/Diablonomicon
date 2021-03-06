﻿using UnityEngine;
using System.Collections;

public class stairGlowHandler : MonoBehaviour {
    public SpriteRenderer rend;
    public bool clicked = false;

    public Sprite Summoner;
    private AudioSource windSound;

    private float t = 0;
    private Color lerpedColor = new Color(1,1,1,0.25f);
    private bool hoveredOver = false;

	// Use this for initialization
	void Start () {
		rend = GetComponent<SpriteRenderer>();
		rend.color = new Color(1,1,1,0.25f);
		windSound = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime;
		if (hoveredOver) {
			lerpedColor = Color.Lerp( 
					new Color(1,1,1,0.4f), 
					new Color(1,1,1,1.0f), 
					t * 3 );	
		} else {
			lerpedColor = Color.Lerp( 
					new Color(1,1,1,1.0f), 
					new Color(1,1,1,0.4f), 
					t * 3 );
		}
		lerpedColor += Color.Lerp( new Color(1,1,1,0.1f), new Color(1,1,1,0.3f), Mathf.PingPong(t*2, 1.0f) );	
		rend.color = lerpedColor;	
		if (!hoveredOver && windSound.isPlaying ) {
			windSound.volume = Mathf.Lerp(0.2f,0,t);
		}
	}

	void OnMouseEnter () {
		hoveredOver = true;
		t = 0;
		if (!clicked) {
			windSound.volume = 0.2f;
			windSound.Play();
		}
	}	

	void OnMouseOver () {
		if(Input.GetMouseButtonDown(0)) {
			clicked = true;
			GameObject player = GameObject.FindWithTag("Player");
			player.GetComponent<homeSummonerHandler>().clicked = true;

			GameObject camera = GameObject.FindWithTag("MainCamera");
			camera.GetComponent<homeCamera>().clicked = true;

			GameObject state = GameObject.FindWithTag("State");
			state.GetComponent<homeStateHandler>().buttonClicked = true;
		}
	}

	void OnMouseExit () {
		hoveredOver = false;
		t = 0;
	}
}

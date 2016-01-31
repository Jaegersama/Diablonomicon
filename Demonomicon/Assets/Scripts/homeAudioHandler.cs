using UnityEngine;
using System.Collections;

public class homeAudioHandler : MonoBehaviour {
	private AudioSource music;
	private float t;
	private float lerpedVolume;

	// Use this for initialization
	void Start () {
		music = GetComponent<AudioSource>(); 
		music.volume = 0;
		t = 0;
	}
	
	// Update is called once per frame
	void Update () {
		t += Time.deltaTime;
		lerpedVolume = Mathf.Lerp(0,1, t/3);
		music.volume = lerpedVolume;
	}
}

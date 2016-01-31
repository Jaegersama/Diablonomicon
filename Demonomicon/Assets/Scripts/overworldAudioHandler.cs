using UnityEngine;
using System.Collections;

public class overworldAudioHandler : MonoBehaviour {
	public AudioClip otherClip;
    AudioSource bgAudio;
    float t;
    public float lerpedVolume = 0;

    void Start() {
    	t = 0;
    	bgAudio = GetComponent<AudioSource>();
    	bgAudio.volume = 0;
    }
    
	// Update is called once per frame
	void Update () {
		if (t < 8) {
			t += Time.deltaTime;
			lerpedVolume = Mathf.SmoothStep(0,0.3f,t/4);
			bgAudio.volume = lerpedVolume;
		}
		if (!bgAudio.isPlaying) {
			bgAudio.volume = 1;
            bgAudio.clip = otherClip;
            bgAudio.Play();
        }
	}
}

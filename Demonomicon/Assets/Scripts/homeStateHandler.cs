using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class homeStateHandler : MonoBehaviour {
    static public PlayerData player;
	static public player mapInfo;
    public Color lerpedColor = new Color(0,0,0,0);
    public float lerpedVolume = 1;
	public bool buttonClicked = false;
    public Renderer rend;
    public AudioSource music;

	private float t = 0;
	private bool loadingSomething = false;

	void Awake() {
		//allows to persist through scene changes
		DontDestroyOnLoad(transform.gameObject);
	}

	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
		rend.material.color = new Color(0,0,0,0);
		rend.material.shader = Shader.Find( "Transparent/Diffuse" );
	}
	
	// Update is called once per frame
	void Update () {
		if (buttonClicked) {
			if (t < 2){
				t += Time.deltaTime;
			} else if (loadingSomething == false) {
				loadingSomething = true;
				SceneManager.LoadScene(3);
				t = 0;
			}
			if (loadingSomething) {
				lerpedColor = Color.Lerp(new Color(0,0,0,1), new Color(0,0,0,0), t);
			} else {
				lerpedColor = Color.Lerp(new Color(0,0,0,0), new Color(0,0,0,1), t);
				lerpedVolume = Mathf.Lerp(1,0, t);
				music.volume = lerpedVolume;
			}
			rend.material.color = lerpedColor;
		}
	}
}

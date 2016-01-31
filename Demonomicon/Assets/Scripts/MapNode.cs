using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MapNode : MonoBehaviour {
	//currently used for (bad) pathfinding
	public int NodeValue = 0; 

	private float t = 0;
	private bool hoveredOver = false;
	
	private bool selected = false;

	private Color lerpedColor = new Color(1,1,1,0.25f);
    private SpriteRenderer rend;
	public Vector2 location;

	public Sprite hoverImage;
	public Sprite normalImage;

	private AudioSource flame;

	// what kind of encounter is this thing v
	public int eventType = 0;
	

	void Start () {
		//location passed to player
		location = transform.position;
		selected = false;
		rend = GetComponent<SpriteRenderer>();
		rend.color = new Color(1,1,1,0.25f);

		flame = GetComponent<AudioSource>();
	}

	void Update() {
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
		lerpedColor += Color.Lerp( new Color(1,1,1,0.05f), new Color(1,1,1,0.2f), Mathf.PingPong(t*3, 1.0f) );	
		rend.color = lerpedColor;	
	}
		
	 void OnTriggerEnter(Collider other){
		Debug.Log ("Triggered");
		//load battle or event from here
		if(other.tag == "Battle"){
			GameState.mapInfo.target = location;
			SceneManager.LoadScene(2);
		}
	}

	void OnMouseEnter () {
		if (!selected) {
			hoveredOver = true;
			t = 0;
			rend.sprite = hoverImage;
			flame.Play();

			GameObject phandler = GameObject.FindWithTag("Handler");
			phandler.GetComponent<signParticlesHandler>().hoverOver = true;
			phandler.GetComponent<signParticlesHandler>().target = transform.position;
		}
	}	

	void OnMouseOver () {
		if(Input.GetMouseButtonDown(0)) {
			selected = true;
		}
	}

	void OnMouseExit () {
		if (!selected) {
			hoveredOver = false;
			t = 0;
			rend.sprite = normalImage;
			GameObject phandler = GameObject.FindWithTag("Handler");
			phandler.GetComponent<signParticlesHandler>().hoverOver = false;
		}
	}
}

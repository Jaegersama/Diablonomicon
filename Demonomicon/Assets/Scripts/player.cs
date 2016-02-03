using UnityEngine;
using System.Collections; 

//this player class is used for location and movement data, saved
public class player:MonoBehaviour{
	//set the movement speed
	public float speed = 1.0f;
	private float currentLerpTime = 0;

	public int currentNode = 0;
	public int distance;	

	public Vector2 target;
	public Vector2 currentPosition;

	private AudioSource aSources;
	private AudioSource footsteps;
	private AudioSource doorCreak;

	private bool clickedSomething = false;
	private bool tweeningOut = false;
	
	MapNode checknode;

	// Use this for initialization
	void Start () {
		target = transform.position;
		 var aSources = GetComponents<AudioSource>(); 
		 footsteps = aSources[0]; 
		 doorCreak = aSources[1];
	}

	// Update is called once per frame
	void Update () {
		currentLerpTime += Time.deltaTime;
	    
		if(Input.GetMouseButtonDown(0))
		{
			currentLerpTime = 0.0f;
			Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
			RaycastHit hit;
			if( Physics.Raycast( ray, out hit, 100 ) ){
        		footsteps.Play();
				
				checknode = hit.collider.GetComponent<MapNode>();
				distance = Mathf.Abs(checknode.NodeValue - currentNode);			
				target = checknode.location;
				currentNode = checknode.NodeValue;
				currentPosition = transform.position;
				clickedSomething = true;
			}
			//if node is valid, assigns target to node
		}

		//changes position over time to the target position
		transform.position = new Vector2(Mathf.SmoothStep( currentPosition.x, target.x, currentLerpTime),Mathf.SmoothStep( currentPosition.y, target.y, currentLerpTime));

		if (tweeningOut) {
			transform.localScale = new Vector2(	Mathf.SmoothStep( 1, 0.6f, currentLerpTime),
												Mathf.SmoothStep( 1, 0.6f, currentLerpTime));
			
			GetComponent<SpriteRenderer>().color = Color.Lerp( new Color(1,1,1,1), new Color(1,1,1,0.0F), currentLerpTime );
		} else {
			if (clickedSomething && new Vector2(transform.position.x,transform.position.y) == target) {
				currentLerpTime = 0;
				currentPosition = target;
				target = new Vector2(currentPosition.x, currentPosition.y + 0.3f);
				tweeningOut = true;
	        	doorCreak.Play();
			}
		}
	}
}
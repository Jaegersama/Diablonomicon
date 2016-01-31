using UnityEngine;
using System.Collections; 

//this player class is used for location and movement data, saved
public class player:MonoBehaviour{
	//set the movement speed
	public float speed = 1.0f;
	private float currentLerpTime = 0;
	//node and distance currently use for (bad) pathfinding
	public int currentNode = 0;
	public int distance;
	//Vector2 that click/press will be saved in
	public Vector2 target;
	public Vector2 currentPosition;
	private bool clickedSomething = false;
	//used to save data from clicked node
	MapNode checknode;

	// Use this for initialization
	void Start () {
		target = transform.position;
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

	}
}
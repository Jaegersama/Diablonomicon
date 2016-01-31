using UnityEngine;
using System.Collections; 

//this player class is used for location and movement data, saved
public class player:MonoBehaviour{
	//set the movement speed
	public float speed = 2.0f;

	//node and distance currently use for (bad) pathfinding
	public int currentNode = 0;
	public int distance;
	//Vector2 that click/press will be saved in
	private Vector2 target;
	//used to save data from clicked node
	MapNode checknode;

	// Use this for initialization
	void Start () {
		//intitial assignment
		target = transform.position;
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
			RaycastHit hit;
			if( Physics.Raycast( ray, out hit, 100 ) ){
				checknode = hit.collider.GetComponent<MapNode>();
				distance = Mathf.Abs(checknode.NodeValue - currentNode);			
			}
			//if node is valid, assigns target to node
			if (distance <= 1) {
				target = checknode.location;
				currentNode = checknode.NodeValue;
			}
		}


		//changes position over time to the target position
		transform.position = Vector2.MoveTowards(transform.position, target, speed*Time.deltaTime);
	}
}
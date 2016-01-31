using UnityEngine;
using System.Collections;

public class mapCamera : MonoBehaviour {
	public float speed = 1.0f;
	private float currentLerpTime = 0;
	//node and distance currently use for (bad) pathfinding
	public int currentNode = 0;
	public int distance;
	//Vector2 that click/press will be saved in
	public Vector3 target;
	public Vector3 currentPosition = new Vector3(0,0,-10);
	public float currentSize = 5;
	private float targetSize = 5;

	//used to save data from clicked node
	MapNode checknode;

	// Use this for initialization
	void Start () {
		//intitial assignment
		transform.position = currentPosition;
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
				targetSize = 2.4f;
			}
			//if node is valid, assigns target to node
		}

		//changes position over time to the target position
		GetComponent<Camera>().orthographicSize = Mathf.SmoothStep( currentSize, targetSize, currentLerpTime);
		transform.position = new Vector2(
								Mathf.SmoothStep( currentPosition.x, target.x, currentLerpTime),
								Mathf.SmoothStep( currentPosition.y, target.y, currentLerpTime));
	}
}

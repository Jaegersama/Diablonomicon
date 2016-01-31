using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MapNode : MonoBehaviour {

	public int NodeValue = 0; //currently used for (bad) pathfinding
	public Vector2 location;
	// Use this for initialization
	void Start () {
		//location passed to player
		location = transform.position;
	}
		
	 void OnTriggerEnter(Collider other){
		Debug.Log ("Triggered");
		//load battle or event from here
		if(other.tag == "Battle"){
			GameState.mapInfo.target = location;
			SceneManager.LoadScene(2);
		}
	}
}

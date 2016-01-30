using UnityEngine;
using System.Collections;

public class Battle : MonoBehaviour {

	public Demon[] enemy;
	public Demon ally;


	// Use this for initialization
	void Start () {
		enemy = new Demon[10];
		ally = GameState.player.alliedDemon;
		enemy[0]=GenerateDemon();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	Demon GenerateDemon(){
	
		return null;//new Demon(null);
	}
}

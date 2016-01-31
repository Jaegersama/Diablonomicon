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

	public void Attack(Skill attack){
		//float adv = 1.0f
		//if(((ally.type+1)%3)==enemy.type)
		//then adv = 1.2f    
		//else if(((enemy.type+1)%3 == ally.type)
		//then adv = .8f
		//float offense = ally.offense*skill.multiplier*adv*def(reduce by percent)
		//convert to int
		//subtract from hp
		//if(hp<=0){next fighter, if next fighter = null, EndBattle}
		//adjust temperment, check for betrayel
	}
} 

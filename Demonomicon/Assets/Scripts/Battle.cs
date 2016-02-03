using UnityEngine;
using System.Collections;

public class Battle : MonoBehaviour {

	public Demon[] enemy;
	public Demon ally;
	public Sprite allyDemon;
	public Sprite player;
	public Sprite enemyDemon;
	public GameObject playerPos;
	public GameObject enemyPos;
	public GameObject allyPos;
	public int gestures = 0;
	public GameObject gestureSelect;
	public GameObject gestureMenu;

	// Use this for initialization
	void Start () {
		enemy = new Demon[10];
	//	ally = GameState.player.alliedDemon;
	//	enemy[0]=GenerateDemon();
		playerPos.GetComponent<SpriteRenderer>().sprite = player;
		enemyPos.GetComponent<SpriteRenderer>().sprite = enemyDemon;
		allyPos.GetComponent<SpriteRenderer>().sprite = allyDemon;
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
	public void ChangeGestures(int change){
		gestures += change;
	}
} 

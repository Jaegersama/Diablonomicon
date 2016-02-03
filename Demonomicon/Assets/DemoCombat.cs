using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;


public class DemoCombat : MonoBehaviour {

	public int turnSelect = 1;
	public int offense = 10;
	public int HP;
	public GameObject enemy;
	public Slider health;
	public int player =2;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		health.value = HP;
		if (player == 2 && turnSelect == 1) {
			Attack ();
			turnSelect = 0;
		}
	}

	public void Attack(){
		if (turnSelect == 1) {
			enemy.GetComponent<DemoCombat> ().ChangeHp (-offense);
			enemy.GetComponent<DemoCombat>().TurnChange();
			turnSelect = 0;
		}
		//animate

		}

	public void ChangeHp(int change){
		HP += change;
		if (HP <= 0) {
			Destroy (gameObject);

            GameObject overmapState = GameObject.FindWithTag("State2");
            Destroy(overmapState);

            SceneManager.LoadScene(1);
		}
	}

	public void TurnChange(){
		turnSelect = 1;
	}





	
}

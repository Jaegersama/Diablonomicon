using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {


	void Awake() {
		//allows to persist through scene changes
		DontDestroyOnLoad(transform.gameObject);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void NewGame(){
		//loads map
		SceneManager.LoadScene(1);
	}
}


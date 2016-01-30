using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {
	static public PlayerData player;

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

	public void NewGame(){
		//loads map
		SceneManager.LoadScene(1);
	}
}


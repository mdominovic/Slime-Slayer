using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour {

	public string levelToLoad;

	public string exitPoint;

	public bool finished = false;

	private PlayerController thePlayer;
	private PlayerHealthManager Mana;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();
		Mana = FindObjectOfType<PlayerHealthManager> ();


	}
	
	// Update is called once per frame
	void Update () {
		


	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.name == "Player") 
		{
			SceneManager.LoadScene (levelToLoad);
			thePlayer.startPoint = exitPoint;
			FindObjectOfType<GameController>().NewGame();
		}


		/*
		if (levelToLoad == "endgame") {
			thePlayer.gameObject.SetActive (false);
			finished = true;

		}*/
	}

	public void ChangeScene (string scene) {
		SceneManager.LoadScene (scene);
	}

	/*public void StartGame(string scene){
		SceneManager.LoadScene (scene);
		thePlayer.transform.position = new Vector3 (-7.31f,0,0);
		Mana.playerCurrentHealth = 100;
		thePlayer.gameObject.SetActive(true);


	}*/
}

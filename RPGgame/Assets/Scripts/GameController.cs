using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	public PlayerController thePlayer;

	public PlayerHealthManager health;

	public DeathMenu deathScreen;

	private static bool gameCtrlExists;

	private Vector3 playerStartPoint;

	private ScoreManager theScoreManager;



	// Use this for initialization
	void Start () {
		theScoreManager = FindObjectOfType<ScoreManager> ();

		Scene currentScene = SceneManager.GetActiveScene ();
		string sceneName = currentScene.name;

		/*
		if (sceneName == "level1" && FindObjectOfType<PlayerController> () == null) {
			Reset ();
		}*/

		if (!gameCtrlExists) 
		{
			gameCtrlExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else if (sceneName == "endgame" || sceneName == "mainmenu")
		{
			Destroy (gameObject);
		} else {
			Destroy(gameObject);
		}



	}
	
	// Update is called once per frame
	void Update () {

		Scene currentScene = SceneManager.GetActiveScene ();
		string sceneName = currentScene.name;

		if (sceneName == "endgame") {
			theScoreManager.scoreIncreasing = false;
		}

	}

	public void RestartGame()
	{
		thePlayer.gameObject.SetActive(false);
		deathScreen.gameObject.SetActive(true);
	}




	public void Reset ()
	{
		deathScreen.gameObject.SetActive(false);
		SceneManager.LoadScene ("level1");
		thePlayer.transform.position = new Vector3(-7f,0.25f,0);
		thePlayer.lastMove = new Vector2 (0, -1f);
		health.playerCurrentHealth = 100;
		thePlayer.gameObject.SetActive(true);
		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncreasing = true;


	}

	public void NewGame ()
	{
		deathScreen.gameObject.SetActive(false);
		thePlayer.transform.position = new Vector3(-7.81f,0,0);
		thePlayer.lastMove = new Vector2 (0, -1f);
		health.playerCurrentHealth = 100;
		thePlayer.gameObject.SetActive(true);
	}

}

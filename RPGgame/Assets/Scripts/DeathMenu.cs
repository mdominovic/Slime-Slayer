using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour {

	public string mainMenuLevel;
	private static bool deathMenuExists;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void RestartGame()
	{
		FindObjectOfType<GameController>().Reset();
	}


	public void QuitToMain()
	{
		SceneManager.LoadScene(mainMenuLevel);
		FindObjectOfType<GameController>().NewGame();

	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public string mainMenuLevel;
	public GameObject pauseMenu;


	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			pauseGame ();
		}
	}

	public void pauseGame()
	{
		Time.timeScale = 0f;
		pauseMenu.SetActive(true);

	}

	public void resumeGame()
	{
		Time.timeScale = 1f;
		pauseMenu.SetActive(false);
	}

	public void RestartGame()
	{
		Time.timeScale = 1f;
		FindObjectOfType<GameController>().Reset();
		pauseMenu.SetActive(false);
	}


	public void QuitToMain()
	{
		Time.timeScale = 1f;
		Application.LoadLevel(mainMenuLevel);
		pauseMenu.SetActive (false);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

	public Text timerText;
	private float startTime;
	private bool stopped = false;


	// Use this for initialization
	void Start () {
		startTime = Time.time;

		Scene currentScene = SceneManager.GetActiveScene ();
		string sceneName = currentScene.name;

		DontDestroyOnLoad(transform.gameObject);

		if (sceneName == "mainmenu" || sceneName == "endgame") {
			stopped = true;
		}


	}
	
	// Update is called once per frame
	void Update () {



		if (FindObjectOfType<PlayerController>()) {
			stopped = false;
			float t = Time.time - startTime;

			string minutes = ((int)t / 60).ToString ();
			string seconds = (t % 60).ToString ("f2");

			timerText.text = minutes + ":" + seconds;
		} else {
			Stop ();
		}
		if (stopped)
			return;


	}

	public void Stop(){
		stopped = true;
		timerText.color = Color.yellow;
	}


}

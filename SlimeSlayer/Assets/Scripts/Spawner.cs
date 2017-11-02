using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour {
	public PlayerController thePlayer;

	public PlayerHealthManager health;

	public LoadNewArea finished;

	private Vector3 posStart;

	private bool spawn;

	// Use this for initialization
	void Start () {
		posStart = new Vector3 (-7.8f, 0, 0);
		Scene currentScene = SceneManager.GetActiveScene ();
		string sceneName = currentScene.name;

		if (thePlayer.transform.position != posStart) {
			thePlayer.transform.position = posStart;
			health.playerCurrentHealth = 100;
			health.playerCurrentMana = 100;

		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

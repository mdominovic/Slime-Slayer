using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour {

	public string levelToLoad;

	public string exitPoint;

	private PlayerController thePlayer;
	private PlayerHealthManager Mana;


	private float wait = 2;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();
		Mana = FindObjectOfType<PlayerHealthManager> ();
		Mana.SetMaxMana ();

	}
	
	// Update is called once per frame
	void Update () {
		

		if (Mana.playerCurrentHealth <= 0) {
			wait -= Time.deltaTime;
			if (wait < 0) {
				SceneManager.LoadScene ("mainmenu");
			}
		} 
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.gameObject.name == "Player") 
		{
			SceneManager.LoadScene (levelToLoad);
			thePlayer.startPoint = exitPoint;
		}
	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNewArea : MonoBehaviour {

	public string levelToLoad;

	public string exitPoint;

	private PlayerController thePlayer;

	private int gos;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();

	}
	
	// Update is called once per frame
	void Update () {
		gos = GameObject.FindGameObjectsWithTag ("Enemy").Length;

		if (gos <= 0) {
			Destroy(GameObject.Find("prolaz"));
		
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

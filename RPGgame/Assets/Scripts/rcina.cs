using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rcina : MonoBehaviour {

	private float wait = 2f;

	private PlayerHealthManager kita;

	// Use this for initialization
	void Start () {
		kita = FindObjectOfType<PlayerHealthManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (kita.playerCurrentHealth < 1) 
		{
			wait -= Time.deltaTime;
			if (wait <= 0f) {
				SceneManager.LoadScene ("mainmenu");
			}
		}





	}
}

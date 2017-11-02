using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {

	public static bool mcExists;

	public AudioSource musicTracks;


	// Use this for initialization
	void Start () {
		if (!mcExists) 
		{
			mcExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else 
		{
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void TurnOffMusic(){
		musicTracks.Pause ();		
	}

	public void TurnOnMusic(){
		musicTracks.UnPause ();
	}
}

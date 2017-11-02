using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowScore : MonoBehaviour {

	public Text scoreText;
	public Text highScoreText;

	private ScoreManager theScoreManager;

	// Use this for initialization
	void Start () {
		theScoreManager = FindObjectOfType<ScoreManager> ();

	}
	
	// Update is called once per frame
	void Update () {
		scoreText.text = "Score: " + Mathf.Round(theScoreManager.scoreCount);
		highScoreText.text = "High Score: " + Mathf.Round(theScoreManager.highScoreCount);
	}
}

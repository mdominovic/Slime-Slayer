using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour {

	public int MaxHealth;
	public int CurrentHealth;

	private ScoreManager theScoreManager;

	// Use this for initialization
	void Start () {
		theScoreManager = FindObjectOfType<ScoreManager> ();
		CurrentHealth = MaxHealth;

	}

	// Update is called once per frame
	void Update () {

		if (CurrentHealth <= 0) 
		{
			theScoreManager.scoreCount += 20;
			Destroy (gameObject);
		}

	}

	public void HurtEnemy(int damageToGive)
	{

		CurrentHealth -= damageToGive;
	}

	public void SetMaxHealth()
	{

		CurrentHealth = MaxHealth;
	}
}

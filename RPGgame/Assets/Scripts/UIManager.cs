using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	public Slider healthBar;
	public Text HPText;
	public PlayerHealthManager playerHealth;

	public Slider manaBar;
	public Text MPText;

	private static bool UIExists;

	// Use this for initialization
	void Start () {
	
		if (!UIExists) 
		{
			UIExists = true;
			DontDestroyOnLoad (transform.gameObject);
		} else 
		{
			Destroy (gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		healthBar.maxValue = playerHealth.playerMaxHealth;
		healthBar.value = playerHealth.playerCurrentHealth;
		HPText.text = "HP: " + playerHealth.playerCurrentHealth + "/" + playerHealth.playerMaxHealth;

		manaBar.maxValue = playerHealth.playerMaxMana;
		manaBar.value = playerHealth.playerCurrentMana;
		MPText.text = "MP: " + playerHealth.playerCurrentMana + "/" + playerHealth.playerMaxMana;
	}
}

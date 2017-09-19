using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour {

	public int playerMaxHealth;
	public int playerCurrentHealth;

	public int playerMaxMana;
	public int playerCurrentMana;

	private SpriteRenderer playerSprite;

	private float timer;
	private float wait = 2f;

	private SFXManager sfxMan;

	// Use this for initialization
	void Start () {

		playerCurrentHealth = playerMaxHealth;
		playerCurrentMana = playerMaxMana;
		playerSprite = GetComponent<SpriteRenderer> ();

		sfxMan = FindObjectOfType<SFXManager> ();
	}
	
	// Update is called once per frame
	void Update () {

		Scene currentScene = SceneManager.GetActiveScene ();
		string sceneName = currentScene.name;

		if (sceneName == "endgame") {
			gameObject.SetActive (false);
		}

		if (playerCurrentHealth < 1) 
		{
			sfxMan.playerDead.Play ();
			gameObject.SetActive (false);
		}

			

	}

	public void HurtPlayer(int damageToGive)
	{
		playerCurrentHealth -= damageToGive;
		StartCoroutine ("HurtColor");

		sfxMan.playerHurt.Play ();
	}

	public void TakeAwayMana(int manaToTake)
	{
		playerCurrentMana-= manaToTake;
	}

	IEnumerator HurtColor()
	{
		for(int i = 0; i < 3; i++){
			GetComponent<SpriteRenderer>().color = new Color(1f,1f,1f,0.3f);
			yield return new WaitForSeconds(.1f);
			GetComponent<SpriteRenderer>().color = Color.white;
			yield return new WaitForSeconds(.1f);
		}
	}

	public void SetMaxHealth()
	{
		playerCurrentHealth = playerMaxHealth;
	}

	public void SetMaxMana()
	{
		playerCurrentMana = playerMaxMana;
	}

	public void ManaRegen(){
		playerCurrentMana += (int)(1f * Time.deltaTime);
	}
}

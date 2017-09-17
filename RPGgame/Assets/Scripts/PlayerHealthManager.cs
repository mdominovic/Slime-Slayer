using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour {

	public int playerMaxHealth;
	public int playerCurrentHealth;

	public int playerMaxMana;
	public int playerCurrentMana;

	private SpriteRenderer playerSprite;

	// Use this for initialization
	void Start () {

		playerCurrentHealth = playerMaxHealth;
		playerCurrentMana = playerMaxMana;
		playerSprite = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (playerCurrentHealth <= 0) 
		{
			gameObject.SetActive (false);
		}



	}

	public void HurtPlayer(int damageToGive)
	{
		playerCurrentHealth -= damageToGive;
		StartCoroutine ("HurtColor");
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

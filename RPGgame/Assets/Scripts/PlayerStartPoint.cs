using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour {

	private PlayerController thePlayer;
	private PlayerHealthManager Mana;

	public Vector2 startDirection;

	public string pointName;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController>();
		Mana = FindObjectOfType<PlayerHealthManager>();

		if (thePlayer.startPoint == pointName) 
		{
			thePlayer.transform.position = transform.position;
			thePlayer.lastMove = startDirection;
			Mana.SetMaxMana ();
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

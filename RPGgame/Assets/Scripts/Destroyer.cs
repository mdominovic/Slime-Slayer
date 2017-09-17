using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.name == "Sword") {
			
		} else {
			Destroy (collision.gameObject);
		}
	}
}

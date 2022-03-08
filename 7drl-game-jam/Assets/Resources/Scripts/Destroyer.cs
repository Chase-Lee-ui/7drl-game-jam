using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other){
		if(!(other.gameObject.tag == "Player") && !(other.gameObject.tag == "Enemy"))
		{
			Destroy(other.gameObject);
		}
	}
}

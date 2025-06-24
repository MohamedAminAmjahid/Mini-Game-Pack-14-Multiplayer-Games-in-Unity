using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLaps : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			GameObject.Find ("win1").GetComponent<CoutLaps> ().check  = true;
		}
		if (col.gameObject.tag == "Player2")
		{
			GameObject.Find("win1").GetComponent<CoutLaps>().check2 = true;
		}
	}
}

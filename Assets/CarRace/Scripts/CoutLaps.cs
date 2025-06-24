using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoutLaps : MonoBehaviour {

	public bool check = false;
	public bool check2 = false;

	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player" && check) {
			GameObject.Find ("Canvas2").GetComponent<LapsAndTime> ().UpdateLaps();
			check = false;
		}
		if (col.gameObject.tag == "Player2" && check2)
		{
			GameObject.Find("Canvas2").GetComponent<LapsAndTime>().UpdateLaps2();
			check2 = false;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	private Text txtInfo;
	public AudioClip bip;

	public GameObject canvasGame;

	void Start () {
		canvasGame.SetActive (false);
		txtInfo = GetComponent<Text> ();
		GameObject PlayerCar;
		PlayerCar = GameObject.Find("PLAYER1");
		PlayerCar.GetComponent<CarManager> ().enabled = false;
		PlayerCar = GameObject.Find("PLAYER2");
		PlayerCar.GetComponent<CarScript2> ().enabled = false; 
		StartCoroutine (Decompte());
	}


	IEnumerator Decompte () {
		GetComponent<AudioSource> ().PlayOneShot (bip);
		for (int i = 4; i >= 0; i--){
			yield return new WaitForSeconds (1);
			txtInfo.text = "" + i;
		}

		txtInfo.text = "Go...";

		GameObject PlayerCar;
		PlayerCar = GameObject.Find("PLAYER1");
		PlayerCar.GetComponent<CarManager> ().enabled = true;
		PlayerCar = GameObject.Find("PLAYER2");
		PlayerCar.GetComponent<CarScript2> ().enabled = true; 
		yield return new WaitForSeconds (1);
		txtInfo.text = "";
		canvasGame.SetActive (true);
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game2 : MonoBehaviour {

	public GameObject[] numeros;

	public GameObject plus;
	public GameObject moins;
	private int numeroCourant = 0;
	private static List<int> tmp = new List<int> ();
	private int pointsJoueur1 = 0;
	private int pointsJoueur2 = -15;
	public Text score;
	public Text player;

	public GameObject panelFin;

	private static int tour = 0;
	private void Awake(){
		
		numeroCourant = Random.Range (0, numeros.Length);
		tmp.Add (numeroCourant);
		score.text = "Score : 0";
		player.text = "Player 1";
		numeros [numeroCourant].SetActive (true);
	}



	private IEnumerator pause() {
		yield return new WaitForSeconds (1f);
		moins.SetActive (false);
	}

	private IEnumerator pause2() {
		Button[] t = numeros [numeroCourant].GetComponentsInChildren<Button> ();
		foreach (Button item in t) {
			item.interactable = true;
		}
		yield return new WaitForSeconds (1f);
		plus.SetActive (false);
		numeros [numeroCourant].SetActive (false);
		tour++;
		if (tour % 2 == 0) {
			player.text = "Player 1";

			pointsJoueur1 += 15;
			score.text = "Score : " +  pointsJoueur1;
		} else {
			player.text = "Player 2";
			pointsJoueur2 += 15;
			score.text = "Score : " +  pointsJoueur2;
		}

		if (tour % 2 != 0) {
			pointsJoueur1 += 15;
		}else {
			pointsJoueur2 += 15;
		}
		if (pointsJoueur1 >= 60) {
			Debug.Log ("joueur 1 a gagné avec " +  pointsJoueur1);
			score.text = "";
			panelFin.SetActive (true);
			numeros [numeroCourant].SetActive (false);
			panelFin.GetComponentInChildren<Text>().text = "joueur 1 a gagné avec " +  pointsJoueur1;
			GameList.gameswonP1++;
			Time.timeScale = 0;
		}
		if (pointsJoueur2 >= 60 ) {
			Debug.Log ("joueur 2 a gagné avec " +  pointsJoueur2);
			score.text = "";
			panelFin.SetActive (true);
			numeros [numeroCourant].SetActive (false);
			panelFin.GetComponentInChildren<Text>().text = "joueur 2 a gagné avec " +  pointsJoueur2;
			GameList.gameswonP2++;
			Time.timeScale = 0;
		}
		if (pointsJoueur1 <= -20) {
			Debug.Log ("joueur 1 a perdu");
			score.text = "";
			panelFin.SetActive (true);
			numeros [numeroCourant].SetActive (false);
			panelFin.GetComponentInChildren<Text>().text = "joueur 1 a perdu ";
			GameList.gameswonP2++;
			Time.timeScale = 0;
		}
		if (pointsJoueur2 <= -20) {
			Debug.Log ("joueur 2 a perdu");
			score.text = "";
			panelFin.SetActive (true);
			numeros [numeroCourant].SetActive (false);
			panelFin.GetComponentInChildren<Text>().text = "joueur 2 a perdu ";
			GameList.gameswonP1++;
			Time.timeScale = 0;
		}
		numeroCourant = Random.Range (0, numeros.Length);

		while (tmp.IndexOf(numeroCourant) != -1) {
			numeroCourant = Random.Range (0, numeros.Length);
		}
		tmp.Add (numeroCourant);
		numeros [numeroCourant].SetActive (true);
		if (tour % 2 != 0) {
			pointsJoueur1 -= 15;
		}else {
			pointsJoueur2 -= 15;
		}
	}

	public void reponseCorrect() {
		plus.SetActive (true); 
		StartCoroutine(pause2 ()); 

	}

	public void reponseIncorrect() {
		if (tour % 2 == 0) {
			pointsJoueur1 -= 10;
			score.text = "Score : " +  pointsJoueur1;
		} else {
			pointsJoueur2 -= 10;
			score.text = "Score : " +  pointsJoueur2;
		}
		moins.SetActive (true); 
		StartCoroutine(pause ()); 	
	}

}
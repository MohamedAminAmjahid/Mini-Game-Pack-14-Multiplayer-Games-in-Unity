using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reponse : MonoBehaviour {
	public Text gauche;
	public Text droit;
	private string reponse;

	public Text score;
	private int scr = 0;
	private static int to = 0;

	

	public void VerifierGauch() {
		reponse = GameObject.Find ("GameManager").GetComponent<Game3> ().Reponse;
		if (gauche.text == reponse) {
			scr += 5;
		}else
        {
			scr -= 5;
        }
		score.text = "Score : " + scr;
		GameObject.Find("GameManager").GetComponent<Game3>().poserQuestion();
		if (GameObject.Find("GameManager").GetComponent<Game3>().too == 1 && to == 0)
		{
			GameObject.Find("GameManager").GetComponent<Game3>().points1 = scr;
			scr = 0;
			to++;
			score.text = "Score : 0";
        }
        if(GameObject.Find("GameManager").GetComponent<Game3>().too == 1)
        {
			GameObject.Find("GameManager").GetComponent<Game3>().points2 = scr;
		}

	}

	public void VerifierDroit() {
		reponse = GameObject.Find ("GameManager").GetComponent<Game3> ().Reponse;
		if (droit.text == reponse) {
			scr += 5;
		}
		else
        {
			scr -= 5;
        }
		score.text = "Score : " + scr;
		GameObject.Find("GameManager").GetComponent<Game3>().poserQuestion();
		if (GameObject.Find("GameManager").GetComponent<Game3>().too == 1 && to == 0)
		{
			GameObject.Find("GameManager").GetComponent<Game3>().points1 = scr;
			scr = 0;
			to++;

			score.text = "Score : 0";
			
		}
		if (GameObject.Find("GameManager").GetComponent<Game3>().too == 1)
		{
			GameObject.Find("GameManager").GetComponent<Game3>().points2 = scr;
		}
	}

}

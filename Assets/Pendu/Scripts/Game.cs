using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour {

	private Mots mot = new Mots();
	private string motCourant;
	public Text txt;
	private string reponse;
	private bool gagne = false;
	public Sprite[] sp;
	public AudioClip sfxTrue, sfxFalse;
	private AudioSource audioSource;
	public GameObject pendu;
	private int i = 0;
	public GameObject PanelFin;
	private static int joueur1 = -1;
	private static int joueur2 = -1;
	private static int tour = 0;

	private void Start() {
		motCourant = mot.getMotCourant ();

		audioSource = GetComponent<AudioSource> ();

		foreach (char item in motCourant) {
			if (item == ' ') {
				txt.text += " ";
			} else {
				txt.text += "_";
			}
		}
	}

	public void buttonClicked(string lettre) {
		Validation (lettre);
	}

	private void Validation(string lettre) {
		reponse = "";
		gagne = false;

		for (int i = 0; i < mot.motCourant.Length; i++) {
			if (txt.text.Substring (i, 1) == "_") {
				if (mot.motCourant.Substring (i, 1) == lettre) {
					reponse += lettre;
					gagne = true;
				} else {
					reponse += "_";
				}
			}
			else {
				reponse += txt.text.Substring(i, 1);
			}
		}
		txt.text = reponse;
		verification ();
	}

	private void verification() {
		if (gagne) {
			audioSource.PlayOneShot (sfxTrue);
			if (txt.text == motCourant) {
				PanelFin.SetActive (true);
				PanelFin.GetComponentInChildren<Text> ().text = "Bravo!! le mot était : \n" + motCourant;
				if (tour == 0) {
					joueur1 = 1;
				} else {
					joueur2 = 1;
				}
				tour++;

				StartCoroutine (Restart ());
			}
		} else {
			pendu.GetComponent<Image>().sprite = sp [i];
			i++;
			audioSource.PlayOneShot (sfxFalse);

			if (i == 6) {
				PanelFin.SetActive (true);
				PanelFin.GetComponentInChildren<Text> ().text = "Perdu!! le mot était : \n" + motCourant;
				if (tour == 0) {
					joueur1 = 0;
				} else {
					joueur2 = 0;
				}
				tour++;

				StartCoroutine (Restart ());
			}
		}
	}

	private IEnumerator Restart() {
		if (tour == 2) {
			if (joueur1 == 1 && joueur2 == 1) {
				PanelFin.SetActive (true);
				PanelFin.GetComponentInChildren<Text> ().text = "egalité";
				GameList.gameswonP1++;
				GameList.gameswonP2++;
				Time.timeScale = 0;
			}
			else if (joueur1 == 1) {
				PanelFin.SetActive (true);
				PanelFin.GetComponentInChildren<Text> ().text = "Joueur 1 a gagné";
				GameList.gameswonP1++;
				Time.timeScale = 0;
			}
			else if (joueur2 == 1) {
				PanelFin.SetActive (true);
				PanelFin.GetComponentInChildren<Text> ().text = "Joueur 2 a gagné";
				GameList.gameswonP2++;
				Time.timeScale = 0;
			}
			
			Time.timeScale = 0;
		}
		yield return new WaitForSeconds (5f);
		UnityEngine.SceneManagement.SceneManager.LoadScene ("pendu");
	}
}

 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game3 : MonoBehaviour {
	
	private string[] questions = new string[14];
	public Text txtQuestion;
	public Text txtGauche;
	public Text txtDroite;
	private int nb;

	public string Reponse;
	
	private List<int> numbers = new List<int>();
	private static int tour = 0;
	private static int laps = 0;
	public int too = 0;


	public int points1 = 0;
	public int points2 = 0;
	public Text player;

	public Button button1;
	public Button button2;

	public GameObject txt1;
	public GameObject txt2;
	public GameObject txt3;

	void Start () {
		questions[0] = "4x4,8,16,16";
		questions[1] = "sqrt 81,9,6,9";
		questions[2] = "4x + 2x = 6,x=6,x=1,x=1";
		questions[3] = "15*2+30-77+23,6,16,6";
		questions[4] = "48/12+31-79*2,121,123,123";
		questions[5] = "4/3+6*2*4/2,17.33,25.33,25.33";
		questions [6] = "sqrt 121,12,11,11";
		questions [7] = "2^10,1024,1023,1024";
		questions [8] = "98*2*3/2,294,394,294";
		questions [9] = "77/11,7,6,7";
		questions[10] = "sqrt 100,25,10,10";
		questions[11] = "2^8,256,128,256";
		questions[12] = "89*2,178,179,178";
		questions[13] = "74+64,138,188,138";
		poserQuestion();
		player.text = "Player : 1";


	}

	public void poserQuestion()
	{
		nb = Random.Range(0, questions.Length);
		while(numbers.IndexOf(nb) != -1)
        {
			nb = Random.Range(0, questions.Length);
		}
		numbers.Add(nb);
		txtQuestion.text = questions[nb].Split(',')[0];
		txtGauche.text = questions[nb].Split(',')[1];
		txtDroite.text = questions[nb].Split(',')[2];

		Reponse = questions[nb].Split(',')[3];
		
		laps++;
		if(laps > 6 && tour == 0)
        {
			tour++;
			laps = 0;
			too++;
			player.text = "Player : 2";

			
		}
		if(tour == 1 && laps>6)
        {
			button1.interactable = false;
			button2.interactable = false;
			GameObject.Find("Canvas").SetActive(false);
			if (points1 > points2)
			{
				print(points1);
				print(points2);
				GameList.gameswonP1++;
				txt1.SetActive(true);
			}
			else if (points1 < points2)
			{
				GameList.gameswonP2++;
				txt2.SetActive(true);
			}
			else
            {
				GameList.gameswonP1++;
				GameList.gameswonP2++;
				txt3.SetActive(true);

			}

			Time.timeScale = 0;
		}

		
	}

}
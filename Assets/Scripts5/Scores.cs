using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour {

    public Text scorePlayer1;
    public Text scorePlayer2;

    public Text result;

    int score1 = 0;
    int score2 = 0;
    public void player1Scored(int score)
    {
        score1 += score;
        scorePlayer1.text = score1.ToString();
        if (score1 >= 8000)
        {
            result.text = "Player 1 Wins";
            GameList.gameswonP1++;
            Time.timeScale = 0;
        }
    }

    public void player2Scored(int score)
    {
        score2 += score;
        scorePlayer2.text = score2.ToString();
      
        if (score2 >= 8000)
        {
            result.text = "Player 2 Wins";
            GameList.gameswonP2++;
            Time.timeScale = 0;
        }
    }


    public void ExitListener()
    {
        Application.Quit();
    }
    


}

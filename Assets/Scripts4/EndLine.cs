using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndLine : MonoBehaviour
{

    [Header("Buttons")]
    public Button pause;
    public Button exit;
    [Header("Text")]
    public Text text;

    int pauseCount = 0;

    private bool end = false;
    public void PauseListener()
    {
        if (pauseCount % 2 == 0)
        {
            Time.timeScale = 0;
            ColorBlock color = pause.colors;
            color.highlightedColor = new Color32(200, 200, 200, 255);
            pause.colors = color;
        }
        else
        {
            Time.timeScale = 1;
            ColorBlock color = pause.colors;
            color.highlightedColor = Color.clear;
            pause.colors = color;
        }
        pauseCount++;
    }

    public void ExitListener()
    {
        Application.Quit();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!end)
        {
            if (other.tag == "Player")
            {
                Time.timeScale = 0;
                if (other.name == "Player1")
                {
                    text.text = "Player 1 Wins";
                    GameList.gameswonP1++;
                    end = true;
                }
                else
                {
                    text.text = "Player 2 Wins";
                    GameList.gameswonP2++;
                    end = true;
                }
            }
        }

    }
}
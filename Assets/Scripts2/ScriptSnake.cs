using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptSnake : MonoBehaviour {

    [Header("Player 1")]
    public GameObject player1;
    public GameObject apple1;

    [Header("Player2")]
    public GameObject player2;
    public GameObject apple2;

    [Header("Score UI")]
    public Text player1Text;
    public Text player2Text;
    [Header("Buttons")]
    public Button pause;
    public Button exit;
    [Header("Fences")]
    public GameObject fence1;
    public GameObject fence2;
    [Header("Canvas")]
    public GameObject canvas;


    private int Player1Score = 0;
    private int Player2Score = 0;

    private int pauseCount = 0;

    private Text EndMessage;

    private bool apples1 = false, apples2 = false, final1 = false, final2 = false;

    GameObject finalApple1, finalApple2;

    public bool getApples1()
    {
        return apples1;
    }

    public bool getApples2()
    {
        return apples2;
    } 

    public void Apple1Eaten()
    {
        Player1Score++;
        player1Text.text = Player1Score.ToString();
    }

    public void Apple2Eaten()
    {
        Player2Score++;
        player2Text.text = Player2Score.ToString();

    }
    public void PauseListener()
    {
        if (pauseCount % 2 == 0)
        {
            Time.timeScale = 0.00001f;
            ColorBlock color = pause.colors;
            color.highlightedColor = new Color32(255, 255, 255, 255);
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

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Player1Score == 5 && !apples1)
        {
            apple1.GetComponent<Apple>().fun();
            apples1 = true;
            finalApple1 = Instantiate(apple1, new Vector3(-99, -99, 0), Quaternion.identity);
            finalApple1.transform.localScale = new Vector3(3, 3, 1);
        }
        else if (Player2Score == 5 && !apples2)
        {
            apple2.GetComponent<Apple>().fun();
            apples2 = true;
            finalApple2 = Instantiate(apple2, new Vector3(-99, -99, 0), Quaternion.identity);
            finalApple2.transform.localScale = new Vector3(3, 3, 1);
        }
        if (Player1Score == 10 && !final1)
        {
            finalApple1.transform.position = new Vector3(-17.6f, -3.6f, 0);
            final1 = true;
        }
        if (Player2Score == 10 && !final2)
        {
            finalApple2.transform.position = new Vector3(16.7f, -3.6f, 0);
            final2 = true;
        }

        if (Player1Score == 11 || Player2Score == 11)
        {
            Destroy(player1Text);
            Destroy(player2Text);
            Destroy(fence1);
            Destroy(fence2);

            GameObject End = new GameObject();
            End.transform.parent = canvas.transform;
            End.AddComponent<Text>();
            EndMessage = End.GetComponent<Text>();
            EndMessage.fontSize = 72;
            EndMessage.color = Color.black;

            Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
            EndMessage.font = ArialFont;
            EndMessage.material = ArialFont.material;


            RectTransform rectTransform;
            rectTransform = EndMessage.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(130, 376, 0);
            rectTransform.sizeDelta = new Vector2(700, 100);

            pause.enabled = false;
            ColorBlock color = pause.colors;
            color.highlightedColor = Color.clear;
            pause.colors = color;

            Time.timeScale = 0;
        }
        if (Player1Score == 11)
        {
            Player1Score++;
            EndMessage.text = "Player 1 Wins";
            GameList.gameswonP1++;
        }
        if (Player2Score == 11)
        {
            Player2Score++;
            EndMessage.text = "Player 2 Wins";
            GameList.gameswonP2++;
        }
    }

    public void GameOver(bool player)
    {
        Destroy(player1Text);
        Destroy(player2Text);
        Destroy(fence1);
        Destroy(fence2);

        GameObject End = new GameObject();
        End.transform.parent = canvas.transform;
        End.AddComponent<Text>();
        EndMessage = End.GetComponent<Text>();
        EndMessage.fontSize = 72;
        EndMessage.color = Color.black;

        Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
        EndMessage.font = ArialFont;
        EndMessage.material = ArialFont.material;


        RectTransform rectTransform;
        rectTransform = EndMessage.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(130, 376, 0);
        rectTransform.sizeDelta = new Vector2(700, 100);

        pause.enabled = false;
        ColorBlock color = pause.colors;
        color.highlightedColor = Color.clear;
        pause.colors = color;

        if (!player)
        {
            Player1Score++;
            EndMessage.text = "Player 1 Wins";
            GameList.gameswonP1++;
        }
        else
        {
            Player2Score++;
            EndMessage.text = "Player 2 Wins";
            GameList.gameswonP2++;
        }
        Time.timeScale = 0;
    }
        
}

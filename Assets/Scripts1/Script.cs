using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script : MonoBehaviour {

    [Header("Ball")]
    public GameObject ball;

    [Header("Player 1")]
    public GameObject player1Paddle;
    public GameObject player1Goal;

    [Header("Player2")]
    public GameObject player2Paddle;
    public GameObject player2Goal;

    [Header("Score UI")]
    public Text player1Text;
    public Text player2Text;
    [Header("Buttons")]
    public Button pause;
    public Button exit;
    [Header("Canvas")]
    public GameObject canvas;
    public GameObject line;

    private int Player1Score = 0;
    private int Player2Score = 0;

    private int pauseCount = 0;

    private Text EndMessage;

    private bool notDone = true;


    public void Player1Scored()
    {
        Player1Score++;
        player1Text.text = Player1Score.ToString();
        Invoke("ResetPosition", 1f);
    }

    public void Player2Scored()
    {
        Player2Score++;
        player2Text.text = Player2Score.ToString();
        Invoke("ResetPosition", 1f);

    }

    public void ResetPosition()
    {
        ball.GetComponent<Ball>().Reset();
        player1Paddle.GetComponent<Paddle>().Reset();
        player2Paddle.GetComponent<Paddle>().Reset();
    }
    public void PauseListener()
    {
        if (pauseCount % 2 == 0)
        {
            Time.timeScale = 0.00001f;
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

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        if (Player1Score == 7 && notDone)
        {
            Destroy(player1Text);
            Destroy(player2Text);
            Destroy(line);

            GameObject End = new GameObject();
            End.transform.parent = canvas.transform;
            End.AddComponent<Text>();
            EndMessage = End.GetComponent<Text>();
            EndMessage.text = "Player 1 Wins";
            EndMessage.fontSize = 48;
            
            Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
            EndMessage.font = ArialFont;
            EndMessage.material = ArialFont.material;
            

            RectTransform rectTransform;
            rectTransform = EndMessage.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(220, 100, 0);
            rectTransform.sizeDelta = new Vector2(500, 78.302f);

            pause.enabled = false;
            ColorBlock color = pause.colors;
            color.highlightedColor = Color.clear;
            pause.colors = color;

            notDone = false;
            GameList.gameswonP1++;
            Time.timeScale = 0;
        }
        else if (Player2Score == 7 && notDone)
        {
            Destroy(player1Text);
            Destroy(player2Text);
            Destroy(line);

            GameObject End = new GameObject();
            End.transform.parent = canvas.transform;
            End.AddComponent<Text>();
            EndMessage = End.GetComponent<Text>();
            EndMessage.text = "Player 2 Wins";
            EndMessage.fontSize = 48;

            Font ArialFont = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
            EndMessage.font = ArialFont;
            EndMessage.material = ArialFont.material;


            RectTransform rectTransform;
            rectTransform = EndMessage.GetComponent<RectTransform>();
            rectTransform.localPosition = new Vector3(220, 100, 0);
            rectTransform.sizeDelta = new Vector2(500, 78.302f);

            pause.enabled = false;
            ColorBlock color = pause.colors;
            color.highlightedColor = Color.clear;
            pause.colors = color;

            notDone = false;
            GameList.gameswonP2++;
            Time.timeScale = 0;
        }

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TypeScript : MonoBehaviour
{

    public Text output;
    public Text output2;
    public InputField input;
    public Text player;
    public Text player1Score;
    public Text player2Score;
    public Text tkherbi9;

    public Text final;

    public GameObject rect;

    private char[] outp;

    private int l = 0;

    private int turn = 0;

    private int player1points = 0;
    private int player2points = 0;

    private string check = "";

    private bool end = false;
    void Start()
    {
        ReadLine();
    }

    // Update is called once per frame
    void Update()
    {
        if (!end)
        {
            if (input.text.Length == output.text.Length)
            {
                input.interactable = false;
                output2.text = check;
                string[] sep = { "red" };
                string[] s = output2.text.Split(sep, System.StringSplitOptions.RemoveEmptyEntries);

                if (turn % 2 == 0)
                {
                    player1points += 80 - s.Length - 1 - (int)GetComponent<Timer>().GetVal();
                    player.text = "Player 2";
                    player1Score.text = player1points.ToString();
                }
                else
                {
                    player2points += 80 - s.Length - 1 - (int)GetComponent<Timer>().GetVal();
                    player.text = "Player 1";
                    player2Score.text = player2points.ToString();
                }
                turn++;
                input.text = "";
                Invoke("resetInput", 4f);
                GetComponent<Timer>().stop();
                l = 0;
                check = "";
            }
            if (turn == 4)
            {

                if (player1points > player2points)
                {
                    final.text = "Player 1 wins";
                    GameList.gameswonP1++;
                    end = true;
                }
                else if (player1points < player2points)
                {
                    final.text = "Player 2 wins";
                    GameList.gameswonP2++;
                    end = true;
                }
                else
                {
                    turn = 2;
                }
                if (turn == 4)
                {
                    Destroy(tkherbi9);
                    Destroy(player);
                    Invoke("des", 4f);
                    GetComponent<Timer>().destroyEvery();
                    Time.timeScale = 0;
                }
            }
        }

    }

    void OnGUI()
    {
        if (Event.current.keyCode == KeyCode.Backspace || Event.current.keyCode == KeyCode.Return)
        {
            Event.current.Use();
        }
        if (Event.current.type == EventType.MouseDown)
        {
            if (!input.IsDestroyed()) input.Select();
        }

    }
    public void CheckValue()
    {
        if (input.text != "")
        {
            char[] inp = input.text.ToCharArray();
            if (inp[l] == outp[l])
            {
                check += "<color=\"lime\">" + inp[l] + "</color>";
            }
            else
            {
                check += "<color=\"red\">" + inp[l] + "</color>";
            }
            l++;
        }

    }

    private void ReadLine()
    {
        StreamReader sr = new StreamReader("Assets/Assets6/sent.txt");
        int a = Random.Range(0, 15849);
        for (int i = 0; i < a; i++)
        {
            sr.ReadLine();
        }
        output.text = sr.ReadLine();
        input.interactable = true;
        outp = output.text.ToCharArray();
        input.Select();
        sr.Close();

    }

    private void resetInput()
    {
        ReadLine();
        output2.text = "";
    }

    private void des()
    {
        Destroy(output);
        Destroy(output2);
        Destroy(input);
        Destroy(rect);
    }
}
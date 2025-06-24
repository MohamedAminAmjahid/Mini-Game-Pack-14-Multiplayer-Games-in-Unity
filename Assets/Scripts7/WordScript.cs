using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

public class WordScript : MonoBehaviour
{

    public Text output;
    public Text output2;
    public Text letter;
    public InputField input;
    public Text player;
    public Text final;

    public GameObject rect;

    private string[] words;

    private string[] used = new string[1000];

    private int index = 0;

    private int turn = 0;
    string check;

    bool end = false;
    void Start()
    {
        StreamReader sr = new StreamReader("Assets/Assets7/engmix.txt");
        string read = sr.ReadToEnd();
        words = read.Split('\n');
        int a = UnityEngine.Random.Range(0, words.Length);
        output.text = words[a];
        used[index] = output.text.Substring(0, output.text.Length - 1);
        index++;
        input.interactable = true;
        input.Select();
        letter.text = output.text[output.text.Length - 2].ToString().ToUpper();
        sr.Close();
    }

    // Update is called once per frame
    void Update()
    {
        if (!end)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                GetComponent<CountDown>().setVal(0);
            }
            if (GetComponent<CountDown>().GetVal() == 0)
            {
                input.interactable = false;
                GetComponent<CountDown>().stop();
                GetComponent<CountDown>().setVal(10);
                check = input.text.ToUpper();
                if (check != "")
                {
                    if (check[0] == letter.text[0] && Array.IndexOf(words, check.ToLower() + "\r") != -1 && Array.IndexOf(used, check.ToLower()) == -1)
                    {
                        turn++;
                        Invoke("resetInput", 4f);
                        output2.text = "Correct";
                        if (turn % 2 == 0)
                        {
                            player.text = "Player 2";
                        }
                        else
                        {
                            player.text = "Player 1";
                        }

                    }
                    else
                    {
                        output2.text = "Incorrect";
                        if (player.text == "Player 1")
                        {
                            end = true;
                            final.text = "Player 2 wins";
                            GameList.gameswonP2++;
                        }
                        else
                        {
                            end = true;
                            GameList.gameswonP1++;
                            final.text = "Player 1 wins";

                        }
                        Destroy(player);
                        Invoke("des", 4f);
                        GetComponent<CountDown>().destroyEvery();
                        Time.timeScale = 0;
                    }
                }

                else
                {
                    output2.text = "Incorrect";
                    if (player.text == "Player 1")
                    {
                        end = true;
                        final.text = "Player 2 wins";
                        GameList.gameswonP2++;
                    }
                    else
                    {
                        end = true;
                        final.text = "Player 1 wins";
                        GameList.gameswonP1++;
                    }
                    Destroy(player);
                    Invoke("des", 4f);
                    GetComponent<CountDown>().destroyEvery();
                    Time.timeScale = 0;
                }
            }
        }

    }

    void OnGUI()
    {
        if (Event.current.type == EventType.MouseDown)
        {
            if (!input.IsDestroyed()) input.Select();
        }
    }


    private void resetInput()
    {
        letter.text = check[check.Length - 1].ToString();
        output.text = check.ToLower();
        used[index] = check.ToLower();
        index++;
        input.text = "";
        output2.text = "";
        input.interactable = true;
        input.Select();

    }


    private void des()
    {
        Destroy(output);
        Destroy(output2);
        Destroy(input);
        Destroy(rect);
    }
}
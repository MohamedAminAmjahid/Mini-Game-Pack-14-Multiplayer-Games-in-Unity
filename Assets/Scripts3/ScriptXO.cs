using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScriptXO : MonoBehaviour
{

    public List<Button> boxes;
    public GameObject X;
    public GameObject O;

    [Header("Text")]
    public Text Player1Score;
    public Text Player2Score;
    public Text turnPlayer;
    public Text text1;
    public Text text2;
    public Text text3;
    public Text text4;
    public Text text5;
    [Header("Options")]
    public Button exit;
    [Header("Tie")]
    public GameObject tie1;
    public GameObject tie11;
    public GameObject tie2;
    public GameObject tie22;
    public GameObject tie3;
    public GameObject Frame1;
    public GameObject Frame2;

    private int turn;
    private int[,] points = new int[3, 3];

    private int p1Score = 0;
    private int p2Score = 0;

    private int tieCounter1 = 0;
    private int tieCounter2 = 0;

    private bool TIE = false;
    private bool final = false;

    private int rightToleft1 = 0;
    private int UptoDown1 = 0;
    private int rightToleft2 = 2;
    private int UptoDown2 = 0;
    // Use this for initialization
    void Start()
    {
        init();
    }

    // Update is called once per frame
    void Update()
    {
        if (!final)
        {
            EndGame(true);
            if (TIE)
            {
                TieBreak();

            }
        }

    }
    void init()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                points[i, j] = 0;
            }
        }
    }
    public void reset()
    {
        foreach (Button item in boxes)
        {
            item.enabled = true;
            ColorBlock color = item.colors;
            color.normalColor = new Color32(255, 255, 255, 0);
            color.disabledColor = new Color32(255, 255, 255, 0);
            color.pressedColor = new Color32(255, 255, 255, 0);
            item.colors = color;

        }
        GameObject[] g = GameObject.FindGameObjectsWithTag("clone");
        foreach (var item in g)
        {
            Destroy(item);
        }
        if (turn % 2 == 0)
        {
            turnPlayer.text = "Player 1 Turn";
        }
        else turnPlayer.text = "Player 2 Turn";

        if (Mathf.Abs(p1Score - p2Score) == 4 || p1Score + p2Score == 6)
        {
            Destroy(GameObject.Find("Layout"));
            Destroy(GameObject.Find("buttons"));
            Destroy(text1);
            if (p1Score > p2Score)
            {
                turnPlayer.text = "WINNER : PLAYER 1";
                GameList.gameswonP1++;
                Time.timeScale = 0;
            }
            else if (p1Score < p2Score)
            {
                turnPlayer.text = "WINNER : PLAYER 2";
                GameList.gameswonP2++;
                Time.timeScale = 0;
            }
            else
            {
                turnPlayer.text = "TIEBREAKER";
                tie1.SetActive(true);
                tie11.SetActive(true);
                tie2.SetActive(true);
                tie22.SetActive(true);
                text2.gameObject.SetActive(true);
                text3.gameObject.SetActive(true);
                TIE = true;


            }
        }
    }

    public void EndGame(bool reset)
    {
        for (int i = 0; i < 3; i++)
        {
            if (checkLine(i) == 3 || checkColumn(i) == 3)
            {
                p1Score++;
                Player1Score.text = p1Score.ToString();
                init();
                if (reset)
                {
                    turnPlayer.text = "Player 1 Wins";
                    Invoke("reset", 2f);
                }
                else
                {
                    final = true;
                    turnPlayer.text = "WINNER : Player 1";
                    GameList.gameswonP1++;
                    Time.timeScale = 0;
                }

            }
            else if (checkLine(i) == 15 || checkColumn(i) == 15)
            {
                p2Score++;
                Player2Score.text = p2Score.ToString();
                init();
                if (reset)
                {
                    turnPlayer.text = "Player 2 Wins";
                    Invoke("reset", 2f);
                }
                else
                {
                    final = true;
                    turnPlayer.text = "WINNER : Player 2";
                    GameList.gameswonP2++;
                    Time.timeScale = 0;
                }

            }
        }
        if (checkDiagonal1() == 3 || checkDiagonal2() == 3)
        {
            p1Score++;
            Player1Score.text = p1Score.ToString();
            init();
            if (reset)
            {
                turnPlayer.text = "Player 1 Wins";
                Invoke("reset", 2f);
            }
            else
            {
                final = true;
                turnPlayer.text = "WINNER : Player 1";
                GameList.gameswonP1++;
                Time.timeScale = 0;
            }
        }
        else if (checkDiagonal1() == 15 || checkDiagonal2() == 15)
        {
            p2Score++;
            Player2Score.text = p2Score.ToString();
            init();
            if (reset)
            {
                turnPlayer.text = "Player 2 Wins";
                Invoke("reset", 2f);
            }
            else
            {
                final = true;
                turnPlayer.text = "WINNER : Player 2";
                GameList.gameswonP2++;
                Time.timeScale = 0;
            }

        }
        else if (checkFull())
        {
            p1Score++;
            Player1Score.text = p1Score.ToString();
            p2Score++;
            Player2Score.text = p2Score.ToString();
            init();
            turnPlayer.text = "DRAW";
            if (reset) Invoke("reset", 2f);
        }
    }

    public int checkLine(int i)
    {
        int sum = 0;
        for (int j = 0; j < 3; j++)
        {
            sum += points[i, j];
        }
        return sum;
    }

    public int checkColumn(int j)
    {
        int sum = 0;
        for (int i = 0; i < 3; i++)
        {
            sum += points[i, j];
        }
        return sum;
    }

    public int checkDiagonal1()
    {
        int sum = 0;
        for (int i = 0; i < 3; i++)
        {
            sum += points[i, i];
        }
        return sum;
    }

    public int checkDiagonal2()
    {
        int sum = 0, j = 0;
        for (int i = 2; i >= 0; i--)
        {
            sum += points[i, j];
            j++;

        }
        return sum;
    }

    public bool checkFull()
    {
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                if (points[i, j] == 0) return false;
            }
        }
        return true;
    }

    public void FillBox()
    {

        if (turn % 2 == 0)
        {
            foreach (Button item in boxes)
            {
                if (item.name == EventSystem.current.currentSelectedGameObject.name)
                {
                    GameObject x = Instantiate(X, item.transform.position, Quaternion.identity);
                    x.tag = "clone";
                    x.transform.localScale = new Vector3(0.4f, 0.4f, 0);

                    item.enabled = false;
                    ColorBlock color = item.colors;
                    color.disabledColor = Color.clear;
                    item.colors = color;



                    int pos = int.Parse(item.name.Substring(6));
                    points[pos / 3, pos % 3] = 1;

                    turnPlayer.text = "Player 2 Turn";

                }
            }

        }
        else
        {
            foreach (Button item in boxes)
            {
                if (item.name == EventSystem.current.currentSelectedGameObject.name)
                {
                    GameObject o = Instantiate(O, item.transform.position, Quaternion.identity);
                    o.tag = "clone";
                    o.transform.localScale = new Vector3(1.5f, 1.5f, 0);

                    item.enabled = false;
                    ColorBlock color = item.colors;
                    color.disabledColor = Color.clear;
                    item.colors = color;

                    int pos = int.Parse(item.name.Substring(6));
                    points[pos / 3, pos % 3] = 5;

                    turnPlayer.text = "Player 1 Turn";
                }
            }
        }
        turn++;

    }

    void TieBreak()
    {

        if (Input.GetKeyDown(KeyCode.X))
        {
            if (tieCounter1 < 3)
            {
                GameObject x = Instantiate(X, new Vector3(-24 + tieCounter1 * 5, 7, 0), Quaternion.identity);
                x.transform.localScale = new Vector3(0.25f, 0.25f, 0);

            }
            else if (tieCounter1 < 6)
            {
                GameObject x = Instantiate(X, new Vector3(-24 + (tieCounter1 - 3) * 5, -11, 0), Quaternion.identity);
                x.transform.localScale = new Vector3(0.25f, 0.25f, 0);
            }

            tieCounter1++;
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            if (tieCounter2 < 3)
            {
                GameObject o = Instantiate(O, new Vector3(11 + tieCounter2 * 5, 5.3f, 0), Quaternion.identity);
                o.transform.localScale = new Vector3(1, 1, 0);

            }
            else if (tieCounter2 < 6)
            {
                GameObject o = Instantiate(O, new Vector3(11 + (tieCounter2 - 3) * 5, -11, 0), Quaternion.identity);
                o.transform.localScale = new Vector3(1, 1, 0);
            }

            tieCounter2++;
        }
        if (tieCounter1 == 6 || tieCounter2 == 6)
        {
            tie3.SetActive(true);
            if (tieCounter1 == 6)
            {
                Frame1.transform.position = new Vector3(-11, 3.8f, 0); tieCounter1++;
            }
            else Frame2.transform.position = new Vector3(7, 3.8f, 0); tieCounter2++;
        }
        if (tieCounter1 > 6)
        {
            Vector3 ud = new Vector3(0, 8.4f, 0);
            Vector3 rl = new Vector3(9, 0, 0);
            text4.gameObject.SetActive(true);

            if ((Input.GetKeyUp(KeyCode.Z) || Input.GetKeyUp(KeyCode.W)) && UptoDown1 > 0)
            {
                Frame1.transform.position += ud;
                UptoDown1--;
            }
            if (Input.GetKeyUp(KeyCode.S) && UptoDown1 < 2)
            {
                Frame1.transform.position -= ud;
                UptoDown1++;
            }
            if ((Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.A)) && rightToleft1 > 0)
            {
                Frame1.transform.position -= rl;
                rightToleft1--;
            }
            if (Input.GetKeyUp(KeyCode.D) && rightToleft1 < 2)
            {
                Frame1.transform.position += rl;
                rightToleft1++;
            }
            if (Input.GetKeyUp(KeyCode.X) && points[UptoDown1, rightToleft1] == 0)
            {
                GameObject x = Instantiate(X, Frame1.transform.position, Quaternion.identity);
                x.transform.localScale = new Vector3(0.4f, 0.4f, 0);
                points[UptoDown1, rightToleft1] = 1;
            }
        }
        if (tieCounter2 > 6)
        {
            Vector3 ud = new Vector3(0, 8.4f, 0);
            Vector3 rl = new Vector3(9, 0, 0);
            text5.gameObject.SetActive(true);

            if (Input.GetKeyUp(KeyCode.UpArrow) && UptoDown2 > 0)
            {
                Frame2.transform.position += ud;
                UptoDown2--;
            }
            if (Input.GetKeyUp(KeyCode.DownArrow) && UptoDown2 < 2)
            {
                Frame2.transform.position -= ud;
                UptoDown2++;
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow) && rightToleft2 > 0)
            {
                Frame2.transform.position -= rl;
                rightToleft2--;
            }
            if (Input.GetKeyUp(KeyCode.RightArrow) && rightToleft2 < 2)
            {
                Frame2.transform.position += rl;
                rightToleft2++;
            }
            if (Input.GetKeyUp(KeyCode.O) && points[UptoDown2, rightToleft2] == 0)
            {
                GameObject o = Instantiate(O, Frame2.transform.position, Quaternion.identity);
                o.transform.localScale = new Vector3(1.5f, 1.5f, 0);
                points[UptoDown2, rightToleft2] = 5;
            }
        }
        EndGame(false);

    }
    public void ExitListener()
    {
        Application.Quit();
    }
}
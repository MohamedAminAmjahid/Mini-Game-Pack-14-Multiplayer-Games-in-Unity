using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class NextGame : MonoBehaviour {
	void Start () {
        Time.timeScale = 1f;
        List<int> l = new List<int>();
        for (int i = 1; i < 14; i++)
        {
            if (i != SceneManager.GetActiveScene().buildIndex && Array.IndexOf(GameList.games,i)!= -1)
            {
                l.Add(i);
            }
        }
        GameList.games = l.ToArray();
       
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.timeScale == 0)
        {
            if (GameList.gameswonP2 == 5)
            {
                SceneManager.LoadScene(14, LoadSceneMode.Single);
            }
            else if (GameList.gameswonP1 == 5)
            {
                SceneManager.LoadScene(15, LoadSceneMode.Single);
            }
            else StartCoroutine(CustomCoroutine());
        }
        
	}

    private IEnumerator CustomCoroutine()
    {
        int a;
        a = UnityEngine.Random.Range(1, GameList.games.Length);
        yield return new WaitForSecondsRealtime(3.0f);
        SceneManager.LoadScene(GameList.games[a], LoadSceneMode.Single);
        

    }

}

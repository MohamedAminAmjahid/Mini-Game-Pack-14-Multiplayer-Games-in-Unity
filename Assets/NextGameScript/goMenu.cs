using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class goMenu : MonoBehaviour
{

    void Start()
    {

        StartCoroutine(restart());
    }


    private IEnumerator restart()
    {
        yield return new WaitForSecondsRealtime(6.0f);
        SceneManager.LoadScene(0, LoadSceneMode.Single);
        int[] games2 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 };
        GameList.games = games2;
        GameList.gameswonP1 = 0;
        GameList.gameswonP2 = 0;
    }
}

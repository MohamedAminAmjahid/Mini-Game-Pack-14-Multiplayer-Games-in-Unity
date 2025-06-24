using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class controls : MonoBehaviour
{
    public GameObject canvas1;
    public GameObject canvas2;

    public void control()
    {
        canvas1.SetActive(false);
        canvas2.SetActive(true);
    } 
    
    public void returN()
    {
        canvas2.SetActive(false);
        canvas1.SetActive(true);
    }

    public void exit()
    {
        Application.Quit();
    }

    public void play()
    {
        Time.timeScale = 0;
    }
}

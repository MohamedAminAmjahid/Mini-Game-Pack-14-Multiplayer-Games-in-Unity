using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{

    float val;
    bool srt;
    public Text disvar;
    public Text time;
    public Text seconds;

    void Start()
    {
        val = 0;
        srt = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (srt)
        {
            val += Time.deltaTime;
        }

        double b = System.Math.Ceiling(val);

        disvar.text = b.ToString();
    }
    public void stop()
    {
        srt = false;
        Invoke("reset", 4f);
    }
    public void reset()
    {
        srt = true;
        val = 0;
    }

    public double GetVal()
    {
        return System.Math.Ceiling(val);
    }


    public void destroyEvery()
    {
        Destroy(time);
        Destroy(disvar);
        Destroy(seconds);
    }
}

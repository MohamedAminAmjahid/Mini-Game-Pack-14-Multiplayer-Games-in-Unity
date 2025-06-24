using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDown : MonoBehaviour {

    float val;
    bool srt;
    public Text disvar;

    void Start()
    {
        val = 10;
        srt = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (srt)
        {
            val -= Time.deltaTime;
        }

        double b = System.Math.Floor(val);

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
        val = 10;
    }

    public double GetVal()
    {
        return System.Math.Floor(val);
    }
    public void setVal(float value)
    {
        val = value;
    }

    public void destroyEvery()
    {
        Destroy(disvar);
    }
}

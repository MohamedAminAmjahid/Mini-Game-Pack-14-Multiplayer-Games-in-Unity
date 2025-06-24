using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusPoints : MonoBehaviour {

    public Pistol pistol1;
    public Pistol pistol2;
    
    bool targeted = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "bullet1")
        {
            GameObject.Find("Manager").GetComponent<Scores>().player1Scored(100);
            pistol1.reload();
        }

        if (other.name == "bullet2")
        {
            GameObject.Find("Manager").GetComponent<Scores>().player2Scored(100);
            pistol2.reload();

        } 
        targeted = true;
        
    }
    public bool getTargeted()
    {
        return targeted;
    }

    public void initialise()
    {
        targeted = false;
    }
}

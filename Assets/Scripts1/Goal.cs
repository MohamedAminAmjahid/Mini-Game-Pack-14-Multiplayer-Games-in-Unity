using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour {

    public bool isPlayer1Goal;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ball"))
        {
            if(isPlayer1Goal)
            {
                GameObject.Find("Manager").GetComponent<Script>().Player2Scored();

            }
            else
            {
                GameObject.Find("Manager").GetComponent<Script>().Player1Scored();

            }
            
        }

        
    }

    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}
}

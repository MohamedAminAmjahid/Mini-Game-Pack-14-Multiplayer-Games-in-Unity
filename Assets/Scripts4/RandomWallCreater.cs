using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomWallCreater : MonoBehaviour {

	// Use this for initialization

    public GameObject obstacle1;
    public GameObject obstacle2;
    int rand;
    int start = -20;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(start < 73)
        {
            rand = Random.Range(0, 2);
            if (rand == 0)
            {
                GameObject a = Instantiate(obstacle1, new Vector3(start, -19, 0), Quaternion.identity);
            }
            else
            {
                GameObject a = Instantiate(obstacle2, new Vector3(start, -6, 0), Quaternion.identity);
            }
            start += 15;
        }
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag != "Player")
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
            rand = Random.Range(0, 2);
            if (rand == 0)
            {
                GameObject a = Instantiate(obstacle1, new Vector3(70, -19, 0), Quaternion.identity);
            }
            else
            {
                GameObject a = Instantiate(obstacle2, new Vector3(70, -6, 0), Quaternion.identity);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Apple : MonoBehaviour {


    private int pred = 30;


    public bool isPlayer1;
    public GameObject apple;


    private List<Vector3> positions = new List<Vector3>();

	// Use this for initialization
	void Start () {
        if (isPlayer1)
        {

            positions.Add(new Vector3(-4, 7, 0));
            positions.Add(new Vector3(-4, -15, 0));
            positions.Add(new Vector3(-27, -15, 0));
            positions.Add(new Vector3(-27, 7, 0));
        }
        else
        {
            positions.Add(new Vector3(4, 7, 0));
            positions.Add(new Vector3(4, -15, 0));
            positions.Add(new Vector3(28, -15, 0));
            positions.Add(new Vector3(28, 7, 0));
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void fun()
    {
        if (isPlayer1)
        {
            for (int i = 0; i < 4; i++)
            {
                float x = Random.Range(-27, -4);
                float y = Random.Range(-15, 7);

                switch (i)
                {
                    case 0: GameObject apple1 = Instantiate(apple, new Vector3(x, y, 0), Quaternion.identity); break;
                    case 1: GameObject apple2 = Instantiate(apple, new Vector3(x, y, 0), Quaternion.identity); break;
                    case 2: GameObject apple3 = Instantiate(apple, new Vector3(x, y, 0), Quaternion.identity); break;
                    case 3: GameObject apple4 = Instantiate(apple, new Vector3(x, y, 0), Quaternion.identity); break;
                }           
            }
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                float x = Random.Range(4, 28);
                float y = Random.Range(-15, 7);

                switch (i)
                {
                    case 0: GameObject apple1 = Instantiate(apple, new Vector3(x, y, 0), Quaternion.identity); break;
                    case 1: GameObject apple2 = Instantiate(apple, new Vector3(x, y, 0), Quaternion.identity); break;
                    case 2: GameObject apple3 = Instantiate(apple, new Vector3(x, y, 0), Quaternion.identity); break;
                    case 3: GameObject apple4 = Instantiate(apple, new Vector3(x, y, 0), Quaternion.identity); break;
                }
            }
        }
           
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (!GameObject.Find("Manager").GetComponent<ScriptSnake>().getApples1() && isPlayer1)
            {
                int pos = Random.Range(0, 4);
                while (pred == pos)
                {
                    pos = Random.Range(0, 4);
                }
                pred = pos;
                transform.position = positions[pos];
            }
            else if (!GameObject.Find("Manager").GetComponent<ScriptSnake>().getApples2() && !isPlayer1)
            {
                int pos = Random.Range(0, 4);
                while (pred == pos)
                {
                    pos = Random.Range(0, 4);
                }
                pred = pos;
                transform.position = positions[pos];
            } 
            else
            {
                Destroy(apple);
            }
            if (isPlayer1)
            {
                GameObject.Find("Manager").GetComponent<ScriptSnake>().Apple1Eaten();
            }
            else
            {
                GameObject.Find("Manager").GetComponent<ScriptSnake>().Apple2Eaten();
            }
            

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour {

    Vector2 direction;
    public bool isPlayer1;

    public List<GameObject> segments;

	// Use this for initialization
	void Start () {
        reset();
	}

    void reset()
    {
        direction = Vector2.up;
        Time.timeScale = 0.2f;
    }

	// Update is called once per frame
    void Update()
    {
        getUserInput();
    }

    void getUserInput()
    {
        if (isPlayer1)
        {
            if ((Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W)) && Time.timeScale != 0 && direction != Vector2.down)
            {
                direction = Vector2.up;
                transform.rotation = Quaternion.Euler(0, 0, -90);
            }
            else if (Input.GetKeyDown(KeyCode.S) && Time.timeScale != 0 && direction != Vector2.up)
            {
                direction = Vector2.down;
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else if (Input.GetKeyDown(KeyCode.D) && Time.timeScale != 0 && direction != Vector2.left)
            {
                direction = Vector2.right;
                transform.rotation = Quaternion.Euler(0, 0, 180);

            }
            else if ((Input.GetKeyDown(KeyCode.Q) || Input.GetKeyDown(KeyCode.A)) && Time.timeScale != 0 && direction != Vector2.right)
            {
                direction = Vector2.left;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && Time.timeScale != 0 && direction != Vector2.down)
            {
                direction = Vector2.up;
                transform.rotation = Quaternion.Euler(0, 0, -90);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && Time.timeScale != 0 && direction != Vector2.up)
            {
                direction = Vector2.down;
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) && Time.timeScale != 0 &&  direction != Vector2.left)
            {
                direction = Vector2.right;
                transform.rotation = Quaternion.Euler(0, 0, 180);

            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && Time.timeScale != 0 && direction != Vector2.right)
            {
                direction = Vector2.left;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
        
    }

	void FixedUpdate () {
        moveSegments();
        moveSnake();
	}

    void moveSnake()
    {
        float x = transform.position.x + direction.x;
        float y = transform.position.y + direction.y;
        transform.position = new Vector2(x, y);
    }

    void moveSegments()
    {
        for (int i = segments.Count - 1 ; i > 0; i--)
        {
            segments[i].transform.position = segments[i - 1].transform.position;
            segments[i].transform.rotation = segments[i - 1].transform.rotation;
        }
        segments[0].transform.position = transform.position;
        segments[0].transform.rotation = transform.rotation;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Obstacle")
        {
            Time.timeScale = 0;
            GameObject.Find("Manager").GetComponent<ScriptSnake>().GameOver(isPlayer1);
        }
    }

}

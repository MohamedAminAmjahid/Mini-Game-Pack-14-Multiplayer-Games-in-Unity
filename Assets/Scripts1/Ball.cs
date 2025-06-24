using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    public float speed;
    public Rigidbody2D rb;
    public Vector3 startPosition;
	// Use this for initialization
	void Start () {
        startPosition = transform.position;
        Invoke("Launch",1f);
	}
	
	// Update is called once per frame
	void Update () {
	
    }

    private void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.velocity = new Vector2(speed * x, speed * y);
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
        Launch();
        speed = speed + 1;
        
    }

}

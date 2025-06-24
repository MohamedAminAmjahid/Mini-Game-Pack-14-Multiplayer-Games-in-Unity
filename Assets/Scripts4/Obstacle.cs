using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public float speed;
    public Rigidbody2D rb;

	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        
    }
}

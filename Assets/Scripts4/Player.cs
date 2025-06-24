using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Rigidbody2D rb;
    public bool isPlayer1;
    public float speed;

    public float jumpAmount;
    public float gravityScale;
    public float fallingGravityScale;

    private float movement;
    bool jumping;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isPlayer1)
        {
            movement = Input.GetAxisRaw("Horizontal2");
            if ((Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.W)) && rb.position.y < -23)
            {
                rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);

                if (rb.velocity.y >= 0)
                {
                    rb.gravityScale = gravityScale;
                }
                else if (rb.velocity.y < 0)
                {
                    rb.gravityScale = fallingGravityScale;
                }
            }
        }
        else
        {
            movement = Input.GetAxisRaw("Horizontal1");
            if (Input.GetKeyDown(KeyCode.UpArrow) && rb.position.y < -23)
            {
                rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);

                if (rb.velocity.y >= 0)
                {
                    rb.gravityScale = gravityScale;
                }
                else if (rb.velocity.y < 0)
                {
                    rb.gravityScale = fallingGravityScale;
                }
            }
        }

        rb.velocity = new Vector2(movement * speed,rb.velocity.y);

       
	}

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Physics2D.IgnoreCollision(other.gameObject.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
        else if (other.gameObject.tag == "Obstacle")
        {
            rb.velocity = Vector3.zero;
        }
    }
}

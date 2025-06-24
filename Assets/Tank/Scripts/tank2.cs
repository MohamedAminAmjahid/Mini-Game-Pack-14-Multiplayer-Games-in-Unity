using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tank2 : MonoBehaviour
{
    public float ms;

    public Rigidbody2D rb;

    private Vector2 moveDirection;
    void Start()
    {
        
    }

    void Update()
    {
        ProcssInputs();
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcssInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal2");
        float moveY = Input.GetAxisRaw("Vertical2");

        moveDirection = new Vector2(moveX, moveY);
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * ms, moveDirection.y * ms);
    }
}

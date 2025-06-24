using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankRed : MonoBehaviour
{
    public float ms = 5;

    public Rigidbody2D rb;

    private Vector2 moveDirection;

    void Start()
    {

    }

    // Update is called once per frame
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
        float moveX = Input.GetAxisRaw("Horizontal1");
        float moveY = Input.GetAxisRaw("Vertical1");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.velocity = new Vector2(moveDirection.x * ms, moveDirection.y * ms);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankCollier2 : MonoBehaviour
{
    public Pistol2 p;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player2")
        {
            p.Translate2();
        }
    }
}

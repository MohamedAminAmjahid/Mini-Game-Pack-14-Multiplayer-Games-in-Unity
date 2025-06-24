using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankcollider : MonoBehaviour
{
    public Pistol2 p;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            p.Translate1();
        }
    }

}

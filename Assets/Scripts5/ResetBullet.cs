using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBullet : MonoBehaviour {

    public Pistol pistol1;
    public Pistol pistol2;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.name == "bullet1")
        {
            pistol1.reload();
        }
        if (other.name == "bullet2")
        {
            pistol2.reload();
        }
    }
}

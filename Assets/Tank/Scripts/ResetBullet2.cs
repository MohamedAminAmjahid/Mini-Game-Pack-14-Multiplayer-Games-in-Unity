using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBullet2 : MonoBehaviour {

    public Pistol2 pistol1;
    public Pistol2 pistol2;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("bullet1"))
        {
            
            pistol1.reload();
        }
        if (col.gameObject.CompareTag("bullet2"))
        {
            pistol2.reload();
        }
    }
}

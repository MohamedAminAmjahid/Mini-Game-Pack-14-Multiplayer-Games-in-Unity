using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour {

    public bool isPlayer1;
    public GameObject bullet;
    public float bulletSpeed;

    float movement;
    float angle = 0;

    Vector3 ud = new Vector3(0, 0.0067f, 0);

    bool fire = false;

    GameObject b;
    void FixedUpdate()
    {
        if (isPlayer1)
        {
            movement = Input.GetAxisRaw("Vertical2");
            if (Input.GetKey(KeyCode.F) && fire == false)
            {
                fire = true;
                b = Instantiate(bullet, transform.position + new Vector3(0, 0.26f, 0), transform.rotation);
                b.name = "bullet1";
            }
            if (fire == true)
            {
                b.transform.Translate(new Vector3(bulletSpeed, 0, 0));
            }
        }
        else
        {
            movement = Input.GetAxisRaw("Vertical1");
            if (Input.GetKey(KeyCode.K) && fire == false)
            {
                fire = true;
                b = Instantiate(bullet, transform.position + new Vector3(0, 0.26f, 0), transform.rotation);
                b.name = "bullet2";
            }
            if (fire == true)
            {
                b.transform.Translate(new Vector3(bulletSpeed, 0, 0));
            }
        }
        if ((angle < 30 && movement == 1) || (angle > -30 && movement == -1))
        {
            transform.Rotate(new Vector3(0, 0, movement));
            if (movement == 1) transform.Translate(ud);
            else transform.Translate(-ud);
            angle += movement;
        }
    }
    public void reload()
    {
        fire = false;
        Destroy(b);
    }
}

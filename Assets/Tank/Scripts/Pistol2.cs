using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol2 : MonoBehaviour {

    public bool isPlayer1;
    public GameObject bullet;
    public float bulletSpeed;

    public int points1 = 0;
    public int points2 = 0;

    float movement;

    Vector3 ud = new Vector3(0, 0.0067f, 0);

    bool fire = false;

    GameObject b;
    void Update()
    {
        if (isPlayer1)
        {
            movement = Input.GetAxisRaw("Vertical2");
            if (Input.GetKeyDown(KeyCode.F) && fire == false)
            {
                fire = true;
                b = Instantiate(bullet, transform.position + new Vector3(0.8f, 0, 0), transform.rotation);
                b.name = "bullet1";
                b.tag = "bullet1";
            }
            if (fire == true)
            {
                b.transform.Translate(new Vector3(bulletSpeed, 0, 0));
            }
        }
        else
        {
            movement = Input.GetAxisRaw("Vertical1");
            if (Input.GetKeyDown(KeyCode.K) && fire == false)
            {
                fire = true;
                b = Instantiate(bullet, transform.position + new Vector3(-0.8f, 0, 0), transform.rotation);
                b.name = "bullet2";
                b.tag = "bullet2";
            }
            if (fire == true)
            {
                b.transform.Translate(new Vector3(-bulletSpeed, 0, 0));
            }
        }
    }

    public void reload()
    {
        fire = false;
        Destroy(b);
    }

    public void Translate1()
    {
        transform.position = new Vector2(-transform.position.x, transform.position.y);
    }

    public void Translate2()
    {
        transform.position = new Vector2(-transform.position.x, transform.position.y);
    }
}

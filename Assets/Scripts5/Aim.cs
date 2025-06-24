using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour {

    public bool isPlayer1;

    float movement;

    void FixedUpdate()
    {
        if (isPlayer1)
        {
            movement = Input.GetAxisRaw("Vertical2");
        }
        else movement = Input.GetAxisRaw("Vertical1");
        if ((movement == 1 && transform.rotation.eulerAngles.z < 120) || (movement == -1 && transform.rotation.eulerAngles.z > 60))
        {
            transform.Rotate(new Vector3(0, 0, movement));
        }
    }
}

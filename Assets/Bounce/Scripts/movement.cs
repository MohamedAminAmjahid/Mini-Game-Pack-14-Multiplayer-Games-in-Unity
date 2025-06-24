using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour
{

    public float speed;
    public int number;
    public Text numbert;
    public GameObject win1;
    public GameObject win2;

    void FixedUpdate()
    {
		if (Input.GetKey(KeyCode.LeftArrow)) { transform.Translate(-speed * Time.deltaTime, 0, 0); }

		if (Input.GetKey(KeyCode.RightArrow)) { transform.Translate(speed * Time.deltaTime, 0, 0); }
        numbert.text = number.ToString();
		if (number >= 50) {
            win2.SetActive(true);

            GameList.gameswonP2++;
            Time.timeScale = 0;
		}else if (number <= -50)
        {
            win1.SetActive(true);

            Time.timeScale = 0;
		}
    }


   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("white")) {
			number++;
        }
        if (collision.gameObject.CompareTag("red"))
        {
            number -= 5;
        }
        if (collision.gameObject.CompareTag("yellow"))
        {
            number += 2;
        }
        if (collision.gameObject.CompareTag("pink"))
        {
            number -= 2;
        }
        if (collision.gameObject.CompareTag("green"))
        {
            number += 3;
        }
    }

}

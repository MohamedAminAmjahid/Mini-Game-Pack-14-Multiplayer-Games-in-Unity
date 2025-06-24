using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mouvement2 : MonoBehaviour {

	public float speed;
	public int number2;
	public Text numbert;
	public GameObject win1;
	public GameObject win2;

	void FixedUpdate()
	{
		
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.Q)) { transform.Translate(-speed * Time.deltaTime, 0, 0); }

		if (Input.GetKey(KeyCode.D)) { transform.Translate(speed * Time.deltaTime, 0, 0); }
		numbert.text = number2.ToString();
		if (number2 >= 50) {
			win1.SetActive(true);

			GameList.gameswonP1++;
			Time.timeScale = 0;
		}else if (number2 <= -50) {
			win2.SetActive(true);

			Time.timeScale = 0;
		}
	}


	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("white")) {
			number2++;
		}
		if (collision.gameObject.CompareTag("red"))
		{
			number2 -= 5;
		}
		if (collision.gameObject.CompareTag("yellow"))
		{
			number2 += 2;
		}
		if (collision.gameObject.CompareTag("pink"))
		{
			number2 -= 2;
		}
		if (collision.gameObject.CompareTag("green"))
		{
			number2 += 3;
		}
	}
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colliderbull2 : MonoBehaviour
{
	public Pistol2 pistol;

	public Image[] images2 = new Image[3];

	private int cp = 2;

	public  Image tank;

	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.CompareTag("bullet1"))
		{
			pistol.reload();
			images2[cp].enabled = false;
			cp--;
		}
		if(cp < 0)
        {
			tank.enabled = false;
			GameList.gameswonP1++;
			Time.timeScale = 0;
        }
	}
}

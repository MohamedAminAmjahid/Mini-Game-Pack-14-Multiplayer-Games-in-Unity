using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class colliderBullet2 : MonoBehaviour
{
	public Pistol2 pistol;

	public Image[] images = new Image[3];
	
	private int cp = 2;

	public Image tank;

	private void OnCollisionEnter2D(Collision2D col)
	{
		if (col.gameObject.CompareTag("bullet2"))
		{
			pistol.reload();
			images[cp].enabled = false;
			cp--;
		}
		if (cp < 0)
		{
			tank.enabled = false;
			GameList.gameswonP2++;
			Time.timeScale = 0;
		}
	}
}


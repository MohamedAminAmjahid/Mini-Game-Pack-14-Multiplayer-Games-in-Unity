using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour {

	private void OnCollisionEnter2D(Collision2D col)
	{
		if(col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("mur2")  || col.gameObject.CompareTag("mur") || col.gameObject.CompareTag("Player2") )
		{
			if(col.gameObject.CompareTag("mur")){
				if (col.otherCollider.gameObject.CompareTag("yellow"))
				{
					GameObject.Find ("Player").GetComponent<movement> ().number -= 1;
				}
				if (col.otherCollider.gameObject.CompareTag("green"))
				{
					GameObject.Find ("Player").GetComponent<movement> ().number -= 2;
				}
			}
			if(col.gameObject.CompareTag("mur2")){
				
				if (col.otherCollider.gameObject.CompareTag("yellow"))
				{
					GameObject.Find ("Player2").GetComponent<mouvement2> ().number2 -= 1;
				}
				if (col.otherCollider.gameObject.CompareTag("green"))
				{
					GameObject.Find ("Player2").GetComponent<mouvement2> ().number2 -= 2;
				}
			}
			Destroy (gameObject);
		}
	
	}
	
}

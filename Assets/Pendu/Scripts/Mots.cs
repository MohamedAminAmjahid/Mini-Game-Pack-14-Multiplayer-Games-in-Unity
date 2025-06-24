using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Mots {
	private List<string> mots = new List<string> ();
	public string motCourant;

	public Mots() {
		mots.Add ("AMJAHID Mohamed Amin");
		mots.Add ("Goseling James");
		mots.Add ("Tim Berners Lee");
		mots.Add ("Bennani Yassine");
		StreamReader f = new StreamReader("BD\\mots.txt");
		while(!f.EndOfStream)
		{
			mots.Add (f.ReadLine());
		}	

		f.Close();
	}

	public string getMotCourant() {
		motCourant = mots[Random.Range(0, mots.Count)];
		return motCourant;
	}


}

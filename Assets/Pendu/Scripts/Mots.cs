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
        string path = Path.Combine(Application.streamingAssetsPath, "mots.txt");
        StreamReader f = new StreamReader(path);
		while(!f.EndOfStream)
		{
			mots.Add (f.ReadLine());
		}	

		f.Close();
	}

	public string getMotCourant() {
		motCourant = mots[UnityEngine.Random.Range(0, mots.Count)]; 

        return motCourant;
	}


}

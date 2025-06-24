using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapsAndTime : MonoBehaviour {

	public Text txtLaps;
	public Text txtTime;
	public int laps = 3;
	public Text txtLaps2;
	public int laps2 = 3;

	private float t;

	void Start () {
		txtLaps.text = "Lap : " + laps;

		txtLaps2.text = "Lap : " + laps2;
		t = Time.time;
	}

	void Update () {
		int minutes = Mathf.FloorToInt ((Time.time - t) / 60);		
		int seconds = Mathf.FloorToInt ((Time.time - t) - minutes * 60);
		txtTime.text = "Time : " + string.Format ("{0:0}:{1:00}", minutes, seconds);
	}

	public void UpdateLaps() {
		laps--;

		txtLaps.text = "Lap : " + laps;

		if (laps == 0) {
			GameList.gameswonP2++;
			Time.timeScale = 0;
		}
	}

	public void UpdateLaps2()
	{
		laps2--;

		txtLaps2.text = "Lap : " + laps2;

		if (laps2 == 0)
		{
			GameList.gameswonP1++;
			Time.timeScale = 0;
		}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour {
	
	public float maxSpeed = 50;
	public int CoefRotation = 200;

	void Update () {
		transform.Translate (Input.GetAxis ("Vertical1") * Vector2.up * maxSpeed * Time.deltaTime);
		transform.Rotate (0, 0, -Input.GetAxis ("Horizontal1") * CoefRotation * Time.deltaTime);
	}
}
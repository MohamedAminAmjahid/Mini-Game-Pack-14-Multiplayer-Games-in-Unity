using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript2 : MonoBehaviour {

	public float maxSpeed = 50;
	public int CoefRotation = 200;

	void Update () {
		transform.Translate (Input.GetAxis ("Vertical2") * Vector2.up * maxSpeed * Time.deltaTime);
		transform.Rotate (0, 0, -Input.GetAxis ("Horizontal2") * CoefRotation * Time.deltaTime);
	}
}

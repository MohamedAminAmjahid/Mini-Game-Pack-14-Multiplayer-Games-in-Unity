using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GameObject[] circles;
    public Transform[] positions;

    void Start()
    {
        InvokeRepeating("Generate", 0.1f, 0.5f);
    }

    void Generate()
    {
        int randomCircle = Random.Range(0,circles.Length);
		GameObject Object = Instantiate<GameObject>(circles[randomCircle]);
        int randomGenerate = Random.Range(0, positions.Length);
        Object.transform.position = positions[randomGenerate].position;
    }
} 
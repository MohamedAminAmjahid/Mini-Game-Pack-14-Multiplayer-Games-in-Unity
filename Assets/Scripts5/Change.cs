using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change : MonoBehaviour {

    public GameObject target;
    public GameObject bonus;

    public bool isPlayer1;


    void Start()
    {
        if (isPlayer1)
        {
            float x = Random.Range(-1f, 3.5f);
            float y = Random.Range(1f, 4f);
            transform.position = new Vector3(x, y, 0);

        }
        else
        {
            float x = Random.Range(-1f, 3.5f);
            float y = Random.Range(-3.5f, -1f);
            transform.position = new Vector3(x, y, 0);
        }
    }

	void Update () {
        if (target.GetComponent<Target>().getTargeted() || bonus.GetComponent<BonusPoints>().getTargeted())
        {
            target.GetComponent<Target>().initialise();
            bonus.GetComponent<BonusPoints>().initialise();

            if (isPlayer1)
            {
                float x = Random.Range(-1f, 3.5f);
                float y = Random.Range(1f, 4f);
                transform.position = new Vector3(x, y, 0);
                
            }
            else
            {
                float x = Random.Range(-1f, 3.5f);
                float y = Random.Range(-3.5f, -1f);
                transform.position = new Vector3(x, y, 0);
            }
            
            
        }
	}
}

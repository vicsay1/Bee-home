using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy1 : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "bala")
        {
            Destroy(hit.gameObject);
        }
        if (hit.gameObject.tag == "Enemy")
        {
            Destroy(hit.gameObject);
        }

    }
}

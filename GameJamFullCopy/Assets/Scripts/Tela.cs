using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tela : MonoBehaviour {
    Rigidbody2D obj;
    Vector2 Mov;
	// Use this for initialization
	void Start () {
        obj = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void Update () {
        movimiento();
	}

    void movimiento()
    {
        if (Time.timeScale == 1)
        {
            Mov = transform.position;
            Mov.y -= 0.1f;
            transform.position = Mov;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tela_I : MonoBehaviour {
    Rigidbody2D obj;
    Vector2 Mov;
    // Use this for initialization
    void Start()
    {
        obj = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        movimiento();
    }


    void movimiento()
    {

        Mov = transform.position;
        Mov.y -= 0.1f;
        Mov.x -= 0.03f;
        transform.position = Mov;
    }
}

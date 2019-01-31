using UnityEngine;
using System.Collections;

public class Hoja : MonoBehaviour
{
    Rigidbody2D obj;
    Vector2 Mov;
    // Use this for initialization
    void Start()
    {
        obj = GetComponent<Rigidbody2D>();

    }
    
    void Update()
    {
        movimiento();
    }

    void movimiento()
    {
        if (Time.timeScale == 1)
        {
            Mov = transform.position;
            Mov.y -= 0.03f;
            transform.position = Mov;
        }
    }
}
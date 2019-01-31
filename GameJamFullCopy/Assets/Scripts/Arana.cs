using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arana : MonoBehaviour {
    public GameObject tyfObject;
    public GameController tyf;
    Rigidbody2D obj;
    Vector2 mov;
    Vector2 posPlayer;
    public GameObject jugador;
    public GameObject tela;
    bool disparo;
	void Start () {
        tyfObject = GameObject.Find("GameController");
        jugador = GameObject.Find("Abeja");
        tyf = tyfObject.GetComponent<GameController>();
        obj = GetComponent<Rigidbody2D>();
        disparo = true;
    }
	
	// Update is called once per frame
	void Update () {
        movEnemy();
        Disparo();
    }



    void movEnemy()
    {
        if (Time.timeScale == 1)
        {
            mov = transform.position;
            if (tyf.IzyDeBool)
            {
                mov.x += 0.05f;
            }
            if (!tyf.IzyDeBool)
            {
                mov.x -= 0.05f;
            }
            obj.transform.position = mov;
        }
    }


    void Disparo()
    {
        if (jugador != null) {
            posPlayer = jugador.transform.position;
        }
        if (gameObject.transform.position.x <= posPlayer.x + 0.1f && gameObject.transform.position.x >= posPlayer.x - 0.1f && disparo)
        {
            if (Time.timeScale == 1)
            {
                Instantiate(tela, transform.position, Quaternion.identity);
                disparo = false;
            }

        }
    }
}

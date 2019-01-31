using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public AudioSource BossDeadSound;
    public Transform[] points;
    int ramdom;
    float speed;
    public int vida_escudo;
    public bool disminuirT;
    public bool Ataque_bool;
    public int tiempo_AtaqueEnemy;
    public GameObject escudo;
    public GameObject player;
    public GameObject AtaqueAraña;
    public GameObject ArañaParada;
    Rigidbody2D rb;
    public GameObject tela;
    public GameObject tela_D;
    public GameObject tela_I;
    bool Ataque_special;
    int Ataque_specialN;
    public float vidaBoss;
    bool BossRestarVida;
    public bool animFin = false;
    GameController gamess;
    public Abeja script_abeja;
    //public GameObject slider;

    void Start()
    {
        //Slider sliderVida = slider.GetComponent<Slider>();
        
        ArañaParada.GetComponent<Renderer>().enabled = true;
        AtaqueAraña.GetComponent<Renderer>().enabled = false;
        speed = 1f;
        vida_escudo = 100;
        vidaBoss = 10;
        BossRestarVida = false;
        ramdom = Random.Range(0, 5);
        tiempo_AtaqueEnemy = 10;
        disminuirT = true;
        Ataque_bool = true;
        rb = GetComponent<Rigidbody2D>();
        player=GameObject.Find("Abeja");
    }
    void Update()
    {
        Comportamiento();
        if (vidaBoss <= 0)
        {
            BossDeadSound.Play();
            script_abeja.StartCoroutine("revisar");
            //SceneManager.LoadScene("Final");
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }


    void Comportamiento()
    {
        if (vida_escudo > 0)
        {
            Movimiento();
            escudo.GetComponent<Renderer>().enabled = true;
            escudo.GetComponent<Collider2D>().enabled = true;
            StopCoroutine(Tiempo_Disparo());
        }
        else if (vida_escudo <= 0)
        {
            BossRestarVida = true;
            if (disminuirT)
            {
                StartCoroutine(Tiempo_Ataque());
            }
            escudo.GetComponent<Renderer>().enabled = false;
            escudo.GetComponent<Collider2D>().enabled = false;
            MovimientoAtaque();
        }
        if (tiempo_AtaqueEnemy <= 0)
        {
            vida_escudo = 100;
            if (vidaBoss>0.50) {
                tiempo_AtaqueEnemy = 11;
            }
            if (vidaBoss <= 0.50)
            {
                tiempo_AtaqueEnemy = 6;
            }
            Debug.Log(tiempo_AtaqueEnemy);
        }
    }

    void Movimiento()
    {
        BossRestarVida = false;

        ArañaParada.GetComponent<Renderer>().enabled = true;
        AtaqueAraña.GetComponent<Renderer>().enabled = false;
        for (int i = 0; i < points.Length; i++)
        {
            if (transform.position == points[ramdom].position)
            {
                ramdom = Random.Range(0, 5);

            }
        }
        transform.position = Vector3.MoveTowards(transform.position, points[ramdom].position, speed * Time.deltaTime);
    }


    void MovimientoAtaque()
    {
        BossRestarVida = true;
        if (player!=null)
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.GetComponent<Transform>().position.x, transform.position.y), speed * Time.deltaTime);
        }
        if (Ataque_bool)
        { 
        StartCoroutine(Tiempo_Disparo());
        }
    }



    void Ataque()
    {
        Ataque_specialN = Random.Range(0,3);
        //ArañaParada.GetComponent<Renderer>().enabled = false;
        //AtaqueAraña.GetComponent<Renderer>().enabled = true;
        if (Ataque_specialN == 0 || Ataque_specialN == 2)
        {
            Ataque_special = true;
        }
        if (Ataque_specialN == 1 || Ataque_specialN == 3)
        {
            Ataque_special = false;
        }
        if (Ataque_special)
        {
            if (animFin) {
                Instantiate(tela, transform.position, Quaternion.identity);
                Instantiate(tela_D, transform.position, Quaternion.identity);
                Instantiate(tela_I, transform.position, Quaternion.identity);
                animFin = false;
            }
        }
        else
        {
            if (animFin)
            {
                Instantiate(tela, transform.position, Quaternion.identity);
                animFin = false;
            }
        }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag=="bala")
        {
            if (vidaBoss > 0.50)
            {
                vida_escudo -= 40;
                Destroy(col.gameObject);
                if (BossRestarVida)
                {
                    vidaBoss -= 0.15f;
                }
            }
            if (vidaBoss <= 50)
            {
                vida_escudo -= 30;
                Destroy(col.gameObject);
                if (BossRestarVida)
                {
                    vidaBoss -= 0.05f;
                    gamess.sliderVida.value = vidaBoss;
                }
            }
        }
    }

    IEnumerator Tiempo_Ataque()
    {
        disminuirT = false;
        yield return new WaitForSeconds(1);
        tiempo_AtaqueEnemy -= 1;
        Debug.Log(tiempo_AtaqueEnemy);
        disminuirT = true;
    }

    IEnumerator Tiempo_Disparo()
    {
        Ataque_bool = false;
        ArañaParada.GetComponent<Renderer>().enabled = true;
        AtaqueAraña.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(4);
        ArañaParada.GetComponent<Renderer>().enabled = false;
        AtaqueAraña.GetComponent<Renderer>().enabled = true;
        Ataque();
        Ataque_bool = true;
    }
}
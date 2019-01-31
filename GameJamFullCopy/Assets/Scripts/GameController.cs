using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public AudioSource BossSound;
    public float CordX;
    public float CordXPowerUp;
    public float CordX_Hoja;
    public float CordY;
    public float CordYPowerUp;
    public Vector2 Cord;
    public Vector2 CordPowerUp;
    public Vector2 Cord_H;
    public GameObject gota;
    public GameObject Araña;
    public GameObject Hoja_obj;
    public GameObject Iz;
    public GameObject De;
    public Transform Lado;
    public int tiempo_Lluvia;
    public int tiempo_Araña;
    public int tiempo_Hoja;
    public int IzyDe;
    public bool IzyDeBool;
    public bool Respawn_Lluvia = true;
    public bool Respawn_Araña = true;
    public bool Respawn_Hoja = true;
    public int tiempo_oleadas;
    public bool enemy;
    int elegir;
    bool elegirfyt;
    public GameObject Bosss;
    public GameObject Instata;
    public int tiempoPowerUp;
    public bool SpawnPowerUp;

    public GameObject vida;
    public GameObject velocidad;
    public GameObject balas;

    public GameObject slider;
    public Slider sliderVida;
    public Boss BossScript;
    public float porcentajeBoss;
    public GameObject time;
    public int TimeBoss;
    int timeBossActual;
    public bool RestaTime;
    void Start() {
        RestaTime = true;
        timeBossActual = TimeBoss;
        sliderVida = slider.GetComponent<Slider>();
        sliderVida.maxValue = BossScript.vidaBoss;

        SpawnPowerUp = true;
        tiempoPowerUp = Random.Range(10, 15);
        elegirfyt = true;

        Bosss.SetActive(false);

        StartCoroutine("Boss");
    }

    // Update is called once per frame
    void Update() {
        respawnEnemys();
        if (elegirfyt)
        {
            elegir = Random.Range(0, 3);
            if (elegir == 0 || elegir == 2)
            {
                enemy = true;
            }
            if (elegir == 1 || elegir == 3)
            {
                enemy = false;
            }
            tiempo_oleadas = Random.Range(10, 30);
            StartCoroutine(tiempo());
        }
        if (SpawnPowerUp)
        {
            StartCoroutine(PowerUp());
        }

        //porcentajeBoss = BossScript.vidaBoss / 100;
        sliderVida.value = BossScript.vidaBoss;
        Debug.Log(porcentajeBoss);

        if (timeBossActual >= 0) {
            time.GetComponent<Text>().text = "Time: " + timeBossActual;
            if (RestaTime)
            {
                StartCoroutine(Time());
            }
        }
    }

    void respawnEnemys()
    {
        if (Respawn_Lluvia)
        {
            tiempo_Lluvia = Random.Range(1, 5);
            CordX = Random.Range(-2.90f, 2.97f);
            CordY = Random.Range(-4.80f, 4.73f);
            Cord = new Vector2(CordX, CordY);
            Instantiate(gota, Cord, Quaternion.identity);
            StartCoroutine(SpawnLluvia());
            Respawn_Lluvia = false;
        }
        if (Respawn_Araña && enemy)
        {
            Lado_M();
            tiempo_Araña = Random.Range(5, 10);
            Instantiate(Araña, Lado.transform.position, Quaternion.identity);
            StartCoroutine(SpawnAraña());
            Respawn_Araña = false;
        }
        if (Respawn_Hoja && !enemy)
        {
            CordX_Hoja = Random.Range(-2.90f, 2.97f);
            Cord_H = new Vector2(CordX_Hoja, 6);
            tiempo_Hoja = Random.Range(5, 10);
            Instantiate(Hoja_obj, Cord_H, Quaternion.identity);
            StartCoroutine(SpawnHoja());
            Respawn_Hoja = false;
        }
    }
    void Lado_M()
    {
        IzyDe = Random.Range(0, 3);
        if (IzyDe == 0 || IzyDe == 2)
        {
            Lado = Iz.GetComponent<Transform>();
            IzyDeBool=true;
        }
        else if(IzyDe == 1 || IzyDe == 3)
        {
            Lado = De.GetComponent<Transform>();
            IzyDeBool = false;
        }
    }
    IEnumerator SpawnLluvia()
    {
        yield return new WaitForSeconds(tiempo_Lluvia);
        Respawn_Lluvia = true;
    }
    IEnumerator SpawnAraña()
    {
        yield return new WaitForSeconds(tiempo_Araña);
        Respawn_Araña = true;
    }
    IEnumerator SpawnHoja()
    {
        yield return new WaitForSeconds(tiempo_Hoja);
        Respawn_Hoja = true;
    }
    IEnumerator tiempo()
    {
        elegirfyt = false;
        yield return new WaitForSeconds(tiempo_oleadas);
        elegirfyt = true;
    }
    IEnumerator Boss()
    {
        yield return new WaitForSeconds(TimeBoss);
        Bosss.SetActive(true);
        BossSound.Play();
        StopCoroutine("SpawnAraña");
        slider.SetActive(true);
    }


    void SpawnPUM()
    {
            int randomPowerUp = Random.Range(0, 7);
            CordXPowerUp = Random.Range(-2.90f, 2.97f);
            CordYPowerUp = Random.Range(-4.5f, -0.40f);
            CordPowerUp = new Vector2(CordXPowerUp, CordYPowerUp);
            if (randomPowerUp == 0 || randomPowerUp == 2)
            { 
                Instantiate(balas, CordPowerUp, Quaternion.identity);
            }

            if (randomPowerUp == 3 || randomPowerUp == 5)
            {

                Instantiate(vida, CordPowerUp, Quaternion.identity);
            }
            if (randomPowerUp == 1 || randomPowerUp == 7)
            {

                Instantiate(velocidad, CordPowerUp, Quaternion.identity);
            }
            if (randomPowerUp == 4 || randomPowerUp == 6)
            {
                Debug.Log("Fierrro sigue participando");
            }
    }




    IEnumerator PowerUp()
    {
        SpawnPowerUp = false;
        yield return new WaitForSeconds(tiempoPowerUp);
        SpawnPUM();
        tiempoPowerUp = Random.Range(10, 15);
        SpawnPowerUp = true;
       
    }

    IEnumerator Time()
    {
        RestaTime = false;
        yield return new WaitForSeconds(1);
        timeBossActual -= 1;
        RestaTime = true;

    }
}
    
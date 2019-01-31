using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparar : MonoBehaviour {
    public AudioSource DisparoSound;
    public GameObject bala;
    public GameObject cañon1, cañon2; 
    public float recoildisparo;
    public bool puededisparar = true;
    public bool powerup_disparo = false;

    void Start ()
    {
		
	}
	
	
	void Update ()
    {
        revision_de_estados();
	}
    public void Disparo()
    {
        if (puededisparar == true) {
            Debug.Log("DISPARANDO BALA");
            DisparoSound.Play();
            Instantiate(bala, gameObject.transform.position, gameObject.transform.rotation);//instancia la bala hacia donde está el mouse xd

            //AudioSource sonidobala = gameObject.GetComponent<AudioSource>();
            //sonidobala.Play();
            if (powerup_disparo == true)
            {
                Instantiate(bala, cañon1.transform.position, gameObject.transform.rotation);
                Instantiate(bala, cañon2.transform.position, gameObject.transform.rotation);
            }
            puededisparar = false;
        }
    }
    public void revision_de_estados()
    {


        if (recoildisparo > 0 && puededisparar == false)
        {
            recoildisparo -= Time.deltaTime;
            //Debug.Log(recoildisparo);
        }
        if (recoildisparo < 0 && powerup_disparo == false)
        {
            recoildisparo = 1.5f;
            puededisparar = true;
        }
        if (recoildisparo < 0 && powerup_disparo == true)
        {
            recoildisparo = 0.5f;
            puededisparar = true;
        }

    }
    IEnumerator waitFunction1()
    {
        recoildisparo = 1;
        powerup_disparo = true;
        yield return new WaitForSeconds(10); 
        powerup_disparo = false;
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == ("powerup_disparo"))
        {
            Debug.Log("entro a el triger");
            StartCoroutine(waitFunction1());
            Destroy(col.gameObject);
        }
    }
}

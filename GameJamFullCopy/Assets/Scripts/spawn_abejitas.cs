using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class spawn_abejitas : MonoBehaviour {

    public GameObject abejita;
    public GameObject lugar1, lugar2, lugar3;
    public Boss script_boss;
    public bool primera = true,segunda = true,tercera = true,cuarta = true,quinta = true;
    
	void Start ()
    {
		
	}
	void Update ()
    {
        verificador_abejas();
	}

    void verificador_abejas()
    {
        if (script_boss.vidaBoss < 7.5 && primera == true)
        {
            
            Debug.Log("instancia una abejita");
            Instantiate(abejita, lugar1.transform.position, gameObject.transform.rotation);
            primera = false;
        }
        if (script_boss.vidaBoss < 6 && segunda == true)
        {
            Instantiate(abejita, lugar2.transform.position, gameObject.transform.rotation);
            segunda = false;
        }
        if (script_boss.vidaBoss < 4.5 && tercera == true)
        {
            Instantiate(abejita, lugar3.transform.position, gameObject.transform.rotation);
            tercera = false;
        }
        if (script_boss.vidaBoss < 2.5 && cuarta == true)
        {
            Instantiate(abejita, lugar2.transform.position, gameObject.transform.rotation);
            cuarta = false;
        }
        if (script_boss.vidaBoss < 1 && quinta == true)
        {
            Instantiate(abejita, lugar3.transform.position, gameObject.transform.rotation);
            quinta = false;
        }
    }
    //public void OnCollisionEnter2D(Collision2D collision)
    //{
    //        if (collision.gameObject.tag == "bala")
    //        {
    //        Debug.Log("holakdanjnhsdnjasbd");
    //            supuestavidadelboss -= 15;
    //        }
    //}
}
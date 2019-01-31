using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class cambio_de_pagina : MonoBehaviour {

    public GameObject pagina1,pagina2,pagina3;
     
	void Start ()
    {
        StartCoroutine("tiempo");
    }
	

	void Update ()
    {
		
	}

    public void saltar()
    {
        SceneManager.LoadScene("Gameplay");
    }

    IEnumerator tiempo()
    {
        yield return new WaitForSeconds(5f);
        pagina1.SetActive(false);
        pagina2.SetActive(true);
        yield return new WaitForSeconds(5f);
        pagina2.SetActive(false);
        pagina3.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene("Gameplay");
    }
}

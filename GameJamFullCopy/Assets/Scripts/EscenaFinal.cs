using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EscenaFinal : MonoBehaviour {

    public bool buliano = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(buliano == true)
        {
            MainMenu();
        }
	}

    public void MainMenu()
    {
        SceneManager.LoadScene("MenuPrincipal");
    }
}

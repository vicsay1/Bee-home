using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pestaña : MonoBehaviour {
    public Animator animator;
    public AudioSource buttonSound;
	void Start ()
    {
        animator = GetComponent<Animator>();
	}
	

	void Update ()
    {
		
	}

    public void aparece_pestaña()
    {
        //Debug.Log("azucar");
        //animator.SetBool("activo",true);
        if (animator.GetBool("activo") == true)
        {
            buttonSound.Play();
            animator.SetBool("activo", false);
        }
        else
        {
            buttonSound.Play();
            animator.SetBool("activo", true);
        }
    }

}

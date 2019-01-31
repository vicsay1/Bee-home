using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vidas : MonoBehaviour {

    public GameObject vida1;
    public GameObject vida2;
    public GameObject vida3;
    public GameObject vida4;

    public Abeja vg;

    public bool vid1 = true;
    public bool vid2 = true;
    public bool vid3 = true;
    public bool vid4 = false;

    void Start () {
        
	}

	void Update () {
		if(vid1 == true)
        {
            vida1.SetActive(true);
        }
        else
        {
            vida1.SetActive(false);

        }
        if (vid2 == true)
        {
            vida2.SetActive(true);
        }
        else
        {
            vida2.SetActive(false);

        }
        if (vid3 == true)
        {
            vida3.SetActive(true);
        }
        else
        {
            vida3.SetActive(false);

        }
        if (vid4 == true)
        {
            vida4.SetActive(true);
        }
        else
        {
            vida4.SetActive(false);
        }

        if(vg.vida == 4)
        {
            vid1 = true;
            vid2 = true;
            vid3 = true;
            vid4 = true;
        }
        if (vg.vida == 3)
        {
            vid1 = true;
            vid2 = true;
            vid3 = true;
            vid4 = false;
        }
        if (vg.vida == 2)
        {
            vid1 = true;
            vid2 = true;
            vid3 = false;
            vid4 = false;
        }
        if (vg.vida == 1)
        {
            vid1 = true;
            vid2 = false;
            vid3 = false;
            vid4 = false;
        }
        if (vg.vida == 0)
        {
            vid1 = false;
            vid2 = false;
            vid3 = false;
            vid4 = false;
        }
    }
}

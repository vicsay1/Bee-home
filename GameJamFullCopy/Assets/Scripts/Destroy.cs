using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {
    public float tiempo;
	// Use this for initialization
	void Start () {
        Destroy(gameObject, tiempo);
	}
}

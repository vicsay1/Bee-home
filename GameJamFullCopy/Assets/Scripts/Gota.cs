using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gota : MonoBehaviour {
    public WaitForSeconds tiempo_daño;
    public bool daño_Bool;
    public Transform tamano;
    public GameObject part;
    // Use this for initialization
    void Start() {
        tiempo_daño = new WaitForSeconds(1.5f);
        daño_Bool = false;
        tamano = gameObject.GetComponent<Transform>();
        
    }
	
	// Update is called once per frame
	void Update () {
        StartCoroutine(Daño());
	}


    IEnumerator Daño()
    {
        yield return tiempo_daño;
        daño_Bool = true;
        tamano.localScale = new Vector2(0.1f,0.1f);
        StartCoroutine(Destroy());
    }
    IEnumerator Destroy()
    {
        tamano.localScale = new Vector2(0.08f, 0.08f);
        Instantiate(part, gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player" && daño_Bool)
        {
            Destroy(collision.gameObject);
        }
    }
}

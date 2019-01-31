using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour {

    public int speed;
    public spawn_abejitas script_boss;
    public disparar script_disparo;
    
    void Start()
    {       
	}

	void Update ()
    {
        if (script_disparo.powerup_disparo == true)
        {
            speed = 8;
        }
        if (script_disparo.powerup_disparo == false)
        {
            speed = 6;
        }
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
            Destroy(hit.gameObject);
        }
    }
}

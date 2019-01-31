using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrenoControl : MonoBehaviour {

    Vector2 Terreno1;
    public GameObject Insta;
    public GameObject Terre1;

	void Update () {
        Move();
	}
    public void Move()
    {
        Terreno1 = transform.position;
        Terreno1.y -= 0.05f;
        transform.position = Terreno1;
        if(Terreno1.y <= -10.27f)
        {
            Instantiate(Terre1, Insta.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}

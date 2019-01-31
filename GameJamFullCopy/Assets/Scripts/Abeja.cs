using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class Abeja : MonoBehaviour
{
    public AudioSource powerUpSound;
    public AudioSource DañoSound;
    public AudioSource DeadSound;
    public AudioSource GameOvers;
    public AudioSource GameSong;
    public GameObject TextBees;
    public float moveSpeed;
    public int vida = 3;
    PausaControl paupau;
    public Animator animabeja;
    public int abejas_rescatadas;
    public TextMeshProUGUI text_component;
    public GameObject GameOver;

    private void Start()
    {
        GameSong.Play();
    }
    private void Update()
    {
        text_component.text = abejas_rescatadas.ToString();
        //GameOver = GetComponent<GameObject>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("PowerUp"))
        {
            powerUpSound.Play();
            Destroy(collision.gameObject);
            moveSpeed = moveSpeed * 2;
            StartCoroutine(DisVel());
        }
        if (collision.tag.Equals("1UP"))
        {
            powerUpSound.Play();
            Destroy(collision.gameObject);
            vida = vida + 1;
            if(vida >= 4)
            {
                vida = 4;
            }
        }
        if (collision.tag.Equals("Enemy"))
        {
            DañoSound.Play();
            vida = vida - 1;
            animabeja.SetTrigger("dañado");

            if (vida <= 0)
            {
                GameSong.Stop();
                DeadSound.Play();
                GameOvers.Play();
                vida = 0;
                GameOver.SetActive(true);
                Destroy(gameObject);

            }
        }
        if (collision.tag.Equals("abejita"))
        {
            abejas_rescatadas += 1;
            Destroy(collision.gameObject);
        }
        }
    IEnumerator DisVel()
    {
        yield return new WaitForSeconds(5.0f);
        moveSpeed = moveSpeed / 2;
    }
    IEnumerator revisar()
    {
        yield return new WaitForSeconds(2);
        if (abejas_rescatadas >= 3)
        {
            SceneManager.LoadScene("Final");
        }
        else
        {
            GameOver.SetActive(true);
            TextBees.GetComponent<Text>().enabled = true;
        }
    }
    }
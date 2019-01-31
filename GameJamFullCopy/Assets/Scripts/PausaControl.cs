using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PausaControl : MonoBehaviour {

    public GameObject GameSong;
    AudioSource GameSongOnScene;
    public AudioSource GameOverSound;
    public AudioSource botonSound;
    public GameObject pausa;
    public GameObject Gameover;
    bool pau = false;

    public void Pausa()
    {
        botonSound.Play();
        pausa.SetActive(true);
        Time.timeScale = 0;
        StopAllCoroutines();
    }
    public void Reanudar()
    {
        botonSound.Play();
        pausa.SetActive(false);
        Time.timeScale = 1;
    }
    public void GameOver()
    {
        GameSong = GameObject.Find("GameSong");
        GameSongOnScene = GameSong.GetComponent<AudioSource>();
        GameSongOnScene.Stop();
        GameOverSound.Play();
        
    }
    public void MenuP()
    {
        botonSound.Play();
        SceneManager.LoadScene("MenuPrincipal");
        Time.timeScale = 1;
    }

    public void Play()
    {
        botonSound.Play();
        SceneManager.LoadScene("intro");
    }
}
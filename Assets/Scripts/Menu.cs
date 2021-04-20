using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //public string sceneName;
    //public string previousScene;
    void Start()
    {
        Time.timeScale = 1;
        Cursor.visible = true;
        Screen.lockCursor = false;
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Splash()
    {
        SceneManager.LoadScene("Splash");
    }

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayTravel()
    {
        SceneManager.LoadScene("PlayTravel");
    }

    public void Play3Dmap()
    {
        SceneManager.LoadScene("Play3Dmap");
    }

    public void PlayResource()
    {
        SceneManager.LoadScene("PlayResource");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}

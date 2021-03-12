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

    public void HowToPlay()
    {
        SceneManager.LoadScene("HowToPlay");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}

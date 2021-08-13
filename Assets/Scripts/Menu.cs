using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    //public string sceneName;
    //public string previousScene;
    public GameObject playTravelObj;

    void Start()
    {
        Time.timeScale = 1;
        Cursor.visible = true;
        Screen.lockCursor = false;
        //playTravelObj = GameObject.FindWithTag("travel");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    //public void MainMenu()
    //{
    //    SceneManager.LoadScene("MainMenu");
    //}

    public void Play3Dmap()
    {
        SceneManager.LoadScene("Map3Dworld");
    }

    public void PlayResource()
    {
        SceneManager.LoadScene("PlayResource");
    }

    public void PlayTravel()
    {
        playTravelObj = GameObject.FindWithTag("travel");
        playTravelObj.SetActive(true);
        SceneManager.LoadScene("PlayTravel");
    }


    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}

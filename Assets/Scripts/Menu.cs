using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{


    void Start()
    {
        Time.timeScale = 1;
        Cursor.visible = true;
        Screen.lockCursor = false;

    }


    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }


    //public void MainMenu()
    //{
    //    SceneManager.LoadScene("MainMenu");
    //}

    public void Play3Dmap()
    {
        SceneManager.LoadScene("Map3Dworld");
        //playTravelObj.SetActive(false);
    }

    public void PlayResource()
    {
        SceneManager.LoadScene("PlayResource");
        //playTravelObj.SetActive(false);
    }

    public void PlayTravel()
    {
        //playTravelObj = GameObject.FindWithTag("travel");
        //playTravelObj.SetActive(true);
        SceneManager.LoadScene("PlayTravel");
    }


    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}

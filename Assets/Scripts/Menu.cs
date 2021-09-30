using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Menu : MonoBehaviour
{
    //public string sceneName;
    //public string previousScene;

    public TMP_Text playerWin;
    //public GameObject playTravelObj;
    public int[] trophyOne = new int[6];
    public int[] trophyTwo = new int[6];
    public int[] trophyThree = new int[6];
    public int[] trophyFour = new int[6];


    void Start()
    {
        Time.timeScale = 1;
        Cursor.visible = true;
        Screen.lockCursor = false;
        //playTravelObj.SetActive(false);
        //playTravelObj = GameObject.FindWithTag("travel");

        //playTravelObj.SetActive(false);

    }

    public void Update()
    {

        trophyOne = GlobalController.Instance.trophyOne;
        trophyTwo = GlobalController.Instance.trophyTwo;
        trophyThree = GlobalController.Instance.trophyThree;
        trophyFour = GlobalController.Instance.trophyFour;

        if (trophyOne[0] >= 3 && trophyTwo[0] >= 3 && trophyThree[0] >= 3 && trophyFour[0] >= 3)
        {
            playerWin.text = "Player 1 wins!!";
        }

        if (trophyOne[1] >= 3 && trophyTwo[1] >= 3 && trophyThree[1] >= 3 && trophyFour[1] >= 3)
        {
            playerWin.text = "Player 2 wins!!";
        }

        if (trophyOne[2] >= 3 && trophyTwo[2] >= 3 && trophyThree[2] >= 3 && trophyFour[2] >= 3)
        {
            playerWin.text = "Player 3 wins!!";
        }

        if (trophyOne[3] >= 3 && trophyTwo[3] >= 3 && trophyThree[3] >= 3 && trophyFour[3] >= 3)
        {
            playerWin.text = "Player 4 wins!!";
        }

        if (trophyOne[4] >= 3 && trophyTwo[4] >= 3 && trophyThree[4] >= 3 && trophyFour[4] >= 3)
        {
            playerWin.text = "Player 5 wins!!";
        }

        if (trophyOne[5] >= 3 && trophyTwo[5] >= 3 && trophyThree[5] >= 3 && trophyFour[5] >= 3)
        {
            playerWin.text = "Player 6 wins!!";
        }
        //playerWin.text = "Player " + playerTurn + " wins!!";
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
        SceneManager.LoadScene("PlayResource", LoadSceneMode.Single);
        //playTravelObj.SetActive(false);
    }

    public void PlayTravel()
    {
        //playTravelObj = GameObject.FindWithTag("travel");
        //playTravelObj.SetActive(true);
        SceneManager.LoadScene("PlayTravel", LoadSceneMode.Single);
    }


    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}

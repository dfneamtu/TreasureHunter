using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using TMPro;
using UnityEngine.SceneManagement;

public class LocationReader : MonoBehaviour
{
    public int[] pLocation = new int[6];
    public int[] hubLocation = new int[6];

    public int playerTurnTickets;

    public TMP_Text fromLocation;
    public TMP_Text toLocation;
    public TMP_Text airTravel;
    public TMP_Text boatTravel;
    public TMP_Text trainTravel;
    public TMP_Text roadTravel;


    public Button fwdButton;
    public Button prevButton;

    public void Update()
    {

        pLocation = GlobalController.Instance.pLocation;
        hubLocation = GlobalController.Instance.hubLocation;

        playerTurnTickets = GameController.playerTurn;

    }

    public void SavePlayer()
    {

        GlobalController.Instance.pLocation = pLocation;
        GlobalController.Instance.hubLocation = hubLocation;

    }

    public void FwdButton()
    {
        //if (counter + 1 < locationPaths.Count)
        //{
        //    counter++;
        //    Debug.Log("current player " + playerTurnTickets + " can travel to " + locationPaths[counter].travelToStr);
        //}
    }

    public void PrevButton()
    {
        //if (counter - 1 == -1)
        //{
        //    Debug.Log("current player " + playerTurnTickets + " can travel to " + locationPaths[counter].travelToStr);
        //}

    }


}

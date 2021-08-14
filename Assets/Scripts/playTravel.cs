using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using TMPro;
using UnityEngine.SceneManagement;

public class playTravel : MonoBehaviour
{
    public GameObject LocationsObj;
    public GameObject LocationPathsObj;

    private ReadLocationPaths locationPathsScript;
    private ReadLocations locationsScript;

    public int[] pLocation = new int[6];
    public int[] hubLocation = new int[6];

    public int playerTurnTickets;

    public Button fwdButton;
    public Button prevButton;

    public TMP_Text fromLocation;
    public TMP_Text toLocation;
    public TMP_Text airTravel;
    public TMP_Text boatTravel;
    public TMP_Text trainTravel;
    public TMP_Text roadTravel;

    //need access to player turn and player location/hubs
    // Start is called before the first frame update
    void Start()
    {
      locationsScript = LocationsObj.GetComponent<ReadLocations>();
      locationPathsScript = LocationPathsObj.GetComponent<ReadLocationPaths>();


    }

    void onEnable()
    {
      pLocation = GlobalController.Instance.pLocation;
      hubLocation = GlobalController.Instance.hubLocation;
      List<Location> adjacentLocations = getAdjacentLocations();
      int length = adjacentLocations.Count;
      int counter = 0;

     //Debug.Log("current player " + playerTurnTickets + " can travel to: " + adjacentLocations[0].travelToStr);
      
    }

    public List<Location> getAdjacentLocations()
    {
      List<Location> adjacentLocations = new List<Location>();

      foreach(Location l in locationsScript.locations)
      {
        if (l.hubNum == hubLocation[playerTurnTickets - 1])
        {
          if (l.locationNum == pLocation[playerTurnTickets - 1])
          {
            adjacentLocations.Add(l);
          }
        }
      }
      return adjacentLocations;
    }

    // Update is called once per frame
    void Update()
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
        //listCounter++;

    }

    public void PrevButton()
    {
        //listCounter--;

    }
}

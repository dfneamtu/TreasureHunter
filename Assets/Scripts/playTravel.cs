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
    public List<LocationPath> paths;
    private ReadLocationPaths locationPathsScript;

    public List<LocationPath> adjacentLocations;

    //public int playerTurn;

    public int[] pLocation = new int[6];
    public int[] hubLocation = new int[6];

    public int playerTurnTickets;
    public int counter;

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
    void Awake()
    {
      Debug.Log("AWAKE CALLED");
      locationPathsScript = LocationPathsObj.GetComponent<ReadLocationPaths>();
      paths = locationPathsScript.locationPaths;
      Debug.Log(paths.Count);
    }
    void Start()
    {
      Debug.Log("START CALLED");
      //playerTurn = GlobalController.Instance.playerTurn;

    }

    void OnEnable()
    {
      locationPathsScript = LocationPathsObj.GetComponent<ReadLocationPaths>();
      paths = locationPathsScript.locationPaths;
      Debug.Log(paths.Count);
      Debug.Log(paths[0].travelToStr);

      // pLocation = GlobalController.Instance.pLocation;
      // hubLocation = GlobalController.Instance.hubLocation;
      // adjacentLocations = getAdjacentLocations();
      // int length = adjacentLocations.Count;
      // counter = 0;
      //
      // Debug.Log(locationPathsScript.locationPaths[0].travelToStr);
      // //Debug.Log("current player " + playerTurnTickets + " can travel to " + adjacentLocations[counter].travelToStr);
      // //Debug.Log("current player " + playerTurnTickets + " can travel to: " + adjacentLocations[0].travelToStr);
      // Debug.Log("ON ENABLE OVER");

    }

    public List<LocationPath> getAdjacentLocations()
    {
      Debug.Log("vot here!!");

      foreach(LocationPath lp in paths)
      {
        Debug.Log("in foreach");
        if (lp.hubNum == hubLocation[playerTurnTickets - 1])
        {
          if (lp.locationNum == pLocation[playerTurnTickets - 1])
          {
            adjacentLocations.Add(lp);

          }
        }
      }
      Debug.Log("returning");
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
      if (counter + 1 < adjacentLocations.Count)
      {
        counter++;
        Debug.Log("current player " + playerTurnTickets + " can travel to " + adjacentLocations[counter].travelToStr);
      }

    }

    public void PrevButton()
    {
        if (counter - 1 == -1)
        {
          Debug.Log("current player " + playerTurnTickets + " can travel to " + adjacentLocations[counter].travelToStr);
        }
    }
}

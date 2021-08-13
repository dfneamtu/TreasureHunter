using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playTravel : MonoBehaviour
{
    public GameObject LocationsObj;
    public GameObject LocationPathsObj;

    private ReadLocationPaths locationPathsScript;
    private ReadLocations locationsScript;

    public int[] pLocation = new int[6];
    public int[] hubLocation = new int[6];

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

      Debug.Log("current player " + playerTurn + " can travel to: " + adjacentLocations[0].travelToStr);
      
    }

    public List<Location> getAdjacentLocations()
    {
      List<Location> adjacentLocations = new List<Location>();

      foreach(Location l in locationsScript.locations)
      {
        if (l.hubNum == hubLocation[playerTurn - 1])
        {
          if (l.locationNum == pLocation[playerTurn - 1])
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

    }
}

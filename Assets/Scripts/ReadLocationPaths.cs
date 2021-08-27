using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using TMPro;
using UnityEngine.SceneManagement;


public class ReadLocationPaths : MonoBehaviour
{
    public List<LocationPath> locationPaths = new List<LocationPath>();

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

    int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("working");
        TextAsset locationPathData = Resources.Load<TextAsset>("LocationPaths");


        string[] data = locationPathData.text.Split(new char[] { '\n'});

        for (int i = 1; i < data.Length - 1; i++)
        {
          string[] row = data[i].Split(new char[] { ',' });
          LocationPath lp = new LocationPath();
          int.TryParse(row[0], out lp.hubNum);
          int.TryParse(row[1], out lp.locationNum);
          lp.locationStr = row[2];
          lp.travelType = row[3];
          int.TryParse(row[4], out lp.ticketNum);
          lp.travelToStr = row[5];
          int.TryParse(row[6], out lp.hubToNum);
          int.TryParse(row[7], out lp.travelToNum);

          locationPaths.Add(lp);
        }


    }

    
}

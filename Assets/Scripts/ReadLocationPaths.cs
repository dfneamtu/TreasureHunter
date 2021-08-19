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

    void Update()
    {
        UpdateUIStats();
    }


    void UpdateUIStats()
    {
        pLocation = GlobalController.Instance.pLocation;
        hubLocation = GlobalController.Instance.hubLocation;

        playerTurnTickets = GameController.playerTurn;

        List<LocationPath> adjacentLocationPaths = new List<LocationPath>();

        foreach (LocationPath lp in locationPaths)
        {
            int length = adjacentLocationPaths.Count;

            if (lp.hubNum == hubLocation[playerTurnTickets - 1])
            {
                if (lp.locationNum ==  pLocation[playerTurnTickets - 1])
                {

                    adjacentLocationPaths.Add(lp);
                    Debug.Log("Player can travel to: " + lp.travelToStr + " with " + lp.ticketNum + " " + lp.travelType + " tickets. FROM: " + lp.locationStr);

                    fromLocation.text = adjacentLocationPaths[counter].locationStr.ToString();
                    toLocation.text = adjacentLocationPaths[counter].travelToStr.ToString();

                    if (lp.travelType == "Air")
                    {
                        airTravel.text = adjacentLocationPaths[counter].ticketNum.ToString();
                    }

                    if (lp.travelType == "Train")
                    {
                        airTravel.text = adjacentLocationPaths[counter].ticketNum.ToString();
                    }

                    if (lp.travelType == "Boat")
                    {
                        airTravel.text = adjacentLocationPaths[counter].ticketNum.ToString();
                    }

                    if (lp.travelType == "Road")
                    {
                        airTravel.text = adjacentLocationPaths[counter].ticketNum.ToString();
                    }

                }
            }
        }
    }

    public void SavePlayer()
    {

        GlobalController.Instance.pLocation = pLocation;
        GlobalController.Instance.hubLocation = hubLocation;

    }

    public void FwdButton()
    {
        if (counter + 1 < locationPaths.Count)
        {
            counter++;
            Debug.Log("current player " + playerTurnTickets + " can travel to " + locationPaths[counter].travelToStr);
        }
    }

    public void PrevButton()
    {
        if (counter - 1 == -1)
        {
            Debug.Log("current player " + playerTurnTickets + " can travel to " + locationPaths[counter].travelToStr);
        }

    }
}

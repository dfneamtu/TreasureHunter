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

    public TMP_Text fromLocation;
    public TMP_Text toLocation;
    public TMP_Text airTravel;
    public TMP_Text boatTravel;
    public TMP_Text trainTravel;
    public TMP_Text roadTravel;


    public Button fwdButton;
    public Button prevButton;

    int listCounter = 0;

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


        List<LocationPath> adjacentLocationPaths = new List<LocationPath>();

        foreach (LocationPath lp in locationPaths)
        {
            int length = adjacentLocationPaths.Count;

            if (lp.hubNum == hubLocation[0])
            {
                if (lp.locationNum == pLocation[0])
                {

                    adjacentLocationPaths.Add(lp);
                    Debug.Log("Player can travel to: " + lp.travelToStr + " with " + lp.ticketNum + " " + lp.travelType + " tickets. FROM: " + lp.locationStr);

                    fromLocation.text = adjacentLocationPaths[listCounter].locationStr.ToString();
                    toLocation.text = adjacentLocationPaths[listCounter].travelToStr.ToString();

                    if (lp.travelType == "Air")
                    {
                        airTravel.text = adjacentLocationPaths[listCounter].ticketNum.ToString();
                    }

                    if (lp.travelType == "Train")
                    {
                        airTravel.text = adjacentLocationPaths[listCounter].ticketNum.ToString();
                    }

                    if (lp.travelType == "Boat")
                    {
                        airTravel.text = adjacentLocationPaths[listCounter].ticketNum.ToString();
                    }

                    if (lp.travelType == "Road")
                    {
                        airTravel.text = adjacentLocationPaths[listCounter].ticketNum.ToString();
                    }

                }
            }


            // if (adjacentLocationPaths.Count == 12) break;
        }
        foreach (LocationPath lp in locationPaths)
        {
            if (lp.hubNum == hubLocation[1])
            {
                if (lp.locationNum == pLocation[1])
                {
                    adjacentLocationPaths.Add(lp);
                    Debug.Log("Player can travel to: " + lp.travelToStr + " with " + lp.ticketNum + " " + lp.travelType + " tickets. FROM: " + lp.locationStr);
                    fromLocation.text = lp.locationStr.ToString();
                    toLocation.text = lp.travelToStr.ToString();

                    if (lp.travelType == "Air")
                    {
                        airTravel.text = lp.ticketNum.ToString();

                    }

                    if (lp.travelType == "Train")
                    {
                        airTravel.text = lp.ticketNum.ToString();
                    }

                    if (lp.travelType == "Boat")
                    {
                        airTravel.text = lp.ticketNum.ToString();
                    }

                    if (lp.travelType == "Road")
                    {
                        airTravel.text = lp.ticketNum.ToString();
                    }

                }
            }
        }
        foreach (LocationPath lp in locationPaths)
        {
            if (lp.hubNum == pLocation[2])
            {
                if (lp.locationNum == pLocation[2])
                {
                    adjacentLocationPaths.Add(lp);
                    Debug.Log("Player can travel to: " + lp.travelToStr + " with " + lp.ticketNum + " " + lp.travelType + " tickets. FROM: " + lp.locationStr);
                    fromLocation.text = lp.locationStr.ToString();
                    toLocation.text = lp.travelToStr.ToString();

                    if (lp.travelType == "Air")
                    {
                        airTravel.text = lp.ticketNum.ToString();

                    }

                    if (lp.travelType == "Train")
                    {
                        airTravel.text = lp.ticketNum.ToString();
                    }

                    if (lp.travelType == "Boat")
                    {
                        airTravel.text = lp.ticketNum.ToString();
                    }

                    if (lp.travelType == "Road")
                    {
                        airTravel.text = lp.ticketNum.ToString();
                    }

                }
            }
        }
        foreach (LocationPath lp in locationPaths)
        {
            if (lp.hubNum == pLocation[3])
            {
                if (lp.locationNum == pLocation[3])
                {
                    adjacentLocationPaths.Add(lp);
                    Debug.Log("Player can travel to: " + lp.travelToStr + " with " + lp.ticketNum + " " + lp.travelType + " tickets. FROM: " + lp.locationStr);
                    fromLocation.text = lp.locationStr.ToString();
                    toLocation.text = lp.travelToStr.ToString();

                    if (lp.travelType == "Air")
                    {
                        airTravel.text = lp.ticketNum.ToString();

                    }

                    if (lp.travelType == "Train")
                    {
                        airTravel.text = lp.ticketNum.ToString();
                    }

                    if (lp.travelType == "Boat")
                    {
                        airTravel.text = lp.ticketNum.ToString();
                    }

                    if (lp.travelType == "Road")
                    {
                        airTravel.text = lp.ticketNum.ToString();
                    }

                }
            }
        }
        foreach (LocationPath lp in locationPaths)
        {
            if (lp.hubNum == pLocation[4])
            {
                if (lp.locationNum == pLocation[4])
                {
                    adjacentLocationPaths.Add(lp);
                    Debug.Log("Player can travel to: " + lp.travelToStr + " with " + lp.ticketNum + " " + lp.travelType + " tickets. FROM: " + lp.locationStr);
                    fromLocation.text = lp.locationStr.ToString();
                    toLocation.text = lp.travelToStr.ToString();

                    if (lp.travelType == "Air")
                    {
                        airTravel.text = lp.ticketNum.ToString();

                    }

                    if (lp.travelType == "Train")
                    {
                        airTravel.text = lp.ticketNum.ToString();
                    }

                    if (lp.travelType == "Boat")
                    {
                        airTravel.text = lp.ticketNum.ToString();
                    }

                    if (lp.travelType == "Road")
                    {
                        airTravel.text = lp.ticketNum.ToString();
                    }

                }
            }
        }
        foreach (LocationPath lp in locationPaths)
        {
            if (lp.hubNum == pLocation[5])
            {
                if (lp.locationNum == pLocation[5])
                {
                    adjacentLocationPaths.Add(lp);
                    Debug.Log("Player can travel to: " + lp.travelToStr + " with " + lp.ticketNum + " " + lp.travelType + " tickets. FROM: " + lp.locationStr);
                    fromLocation.text = lp.locationStr.ToString();
                    toLocation.text = lp.travelToStr.ToString();

                    if (lp.travelType == "Air")
                    {
                        airTravel.text = lp.ticketNum.ToString();

                    }

                    if (lp.travelType == "Train")
                    {
                        airTravel.text = lp.ticketNum.ToString();
                    }

                    if (lp.travelType == "Boat")
                    {
                        airTravel.text = lp.ticketNum.ToString();
                    }

                    if (lp.travelType == "Road")
                    {
                        airTravel.text = lp.ticketNum.ToString();
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
        listCounter++;

    }

    public void PrevButton()
    {
        listCounter--;

    }
}

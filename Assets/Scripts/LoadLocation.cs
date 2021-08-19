using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using TMPro;
using UnityEngine.SceneManagement;


public class LoadLocation : MonoBehaviour
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

    int counter = 0;

    public TextAsset textAssetData;

    [System.Serializable]

    public class Info
    {
        public int hubNum;
        public int locationNum;
        public string locationStr;
        public string travelType;
        public int ticketNum;
        public string traveltoStr;
        public int hubtoNum;
        public int traveltoNum;

    }

    [System.Serializable]

    public class InfoList
    {
        public Info[] info;
    }

    public InfoList myInfoList = new InfoList();

    // Start is called before the first frame update
    public void Start()
    {
        ReadCSV();


    }

    public void ReadCSV()
    {
        string[] data = textAssetData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

        int tableSize = data.Length / 8 - 1;
        myInfoList.info = new Info[tableSize];

        for (int i = 0; i < tableSize; i++)
        {
            myInfoList.info[i] = new Info();
            myInfoList.info[i].hubNum = int.Parse(data[8 * (i + 1)]);
            myInfoList.info[i].locationNum = int.Parse(data[8 * (i + 1) + 1]);
            myInfoList.info[i].locationStr = data[8 * (i + 1) + 2];
            myInfoList.info[i].travelType = data[8 * (i + 1) + 3];
            myInfoList.info[i].ticketNum = int.Parse(data[8 * (i + 1) + 4]);
            myInfoList.info[i].traveltoStr = data[8 * (i + 1) + 5];
            myInfoList.info[i].hubtoNum = int.Parse(data[8 * (i + 1) + 6]);
            myInfoList.info[i].traveltoNum = int.Parse(data[8 * (i + 1) + 7]);
        }
    }

    public void Update()
    {
        pLocation = GlobalController.Instance.pLocation;
        hubLocation = GlobalController.Instance.hubLocation;

        playerTurnTickets = GameController.playerTurn;
        //Debug.Log("in Update");

        //Debug.Log("Player can travel to: " + myInfoList.info[hubLocation[playerTurnTickets]].traveltoStr + " with " + myInfoList.info[hubLocation[playerTurnTickets]].ticketNum + " " + myInfoList.info[hubLocation[playerTurnTickets]].travelType + " tickets. From: " + myInfoList.info[hubLocation[playerTurnTickets]].locationStr);
        
        
        for (int i = 0; i < myInfoList.info.Length; i++)
        {
            if (myInfoList.info[i].hubNum == hubLocation[playerTurnTickets - 1])
            {
                if (myInfoList.info[i].locationNum == pLocation[playerTurnTickets - 1])
                {
                    Debug.Log("Player can travel to: " + myInfoList.info[i].traveltoStr + " with " + myInfoList.info[i].ticketNum + " " + myInfoList.info[i].travelType + " tickets. From: " + myInfoList.info[i].locationStr);

                    fromLocation.text = myInfoList.info[counter].locationStr.ToString();
                    toLocation.text = myInfoList.info[counter].traveltoStr.ToString();

                    if (myInfoList.info[i].travelType == "Air")
                    {
                        airTravel.text = myInfoList.info[counter].ticketNum.ToString();
                    }

                    if (myInfoList.info[i].travelType == "Train")
                    {
                        airTravel.text = myInfoList.info[counter].ticketNum.ToString();
                    }

                    if (myInfoList.info[i].travelType == "Boat")
                    {
                        airTravel.text = myInfoList.info[counter].ticketNum.ToString();
                    }

                    if (myInfoList.info[i].travelType == "Road")
                    {
                        airTravel.text = myInfoList.info[counter].ticketNum.ToString();
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
        if (counter + 1 < myInfoList.info.Length)
        {
            counter++;
            //Debug.Log("current player " + playerTurnTickets + " can travel to " + locationPaths[counter].travelToStr);
        }
    }

    public void PrevButton()
    {
        if (counter - 1 == -1)
        {
            counter--;
            //Debug.Log("current player " + playerTurnTickets + " can travel to " + locationPaths[counter].travelToStr);
        }

    }

}

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
    public TMP_Text InfoText;
    public GameObject InfoPopup;
    public GameObject ConfirmInfoPopup;

    public GameObject[] hub1Targets;
    public GameObject[] hub2Targets;
    public GameObject[] hub3Targets;

    public GameObject[] fromhub1Targets;
    public GameObject[] fromhub2Targets;
    public GameObject[] fromhub3Targets;

    public GameObject airportPopup;

    public int[] pLocation = new int[6];
    public int[] hubLocation = new int[6];
    public int[] counters = new int[6];
    public int[] travelled = new int[6];

    public Sprite[] tickets;
    public SpriteRenderer spriteRenderer;

    public int playerTurnTickets;

    public TMP_Text fromLocation;
    public TMP_Text toLocation;
    public TMP_Text airTravel;
    public TMP_Text boatTravel;
    public TMP_Text trainTravel;
    public TMP_Text roadTravel;

    public int tableSize;

    public GameObject confirmTravelBtn;
    public GameObject nopeBtn;

    public Button fwdButton;
    public Button prevButton;

    public int counter;
    int i;

    public TextAsset textAssetData;

    //Player 1 Stats
    public int[] player1Tickets = new int[4];

    //Player2 Stats
    public int[] player2Tickets = new int[4];

    //Player3 Stats
    public int[] player3Tickets = new int[4];

    //Player4 Stats
    public int[] player4Tickets = new int[4];

    //Player5 Stats
    public int[] player5Tickets = new int[4];

    //Player6 Stats
    public int[] player6Tickets = new int[4];

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
        //Time.timeScale = 1;
    }

    public void ReadCSV()
    {
        string[] data = textAssetData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

        tableSize = data.Length / 8 - 1;
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
        //Debug.Log("CALLING UPDATE");
        //Player 1 info to load
        player1Tickets = GlobalController.Instance.player1Tickets;

        //Player 2 info to load
        player2Tickets = GlobalController.Instance.player2Tickets;

        //Player 3 info to load
        player3Tickets = GlobalController.Instance.player3Tickets;

        //Player 4 info to load
        player4Tickets = GlobalController.Instance.player4Tickets;

        //Player 5 info to load
        player5Tickets = GlobalController.Instance.player5Tickets;

        //Player 6 info to load
        player6Tickets = GlobalController.Instance.player6Tickets;

        pLocation = GlobalController.Instance.pLocation;
        hubLocation = GlobalController.Instance.hubLocation;

        counters = GlobalController.Instance.counters;
        travelled = GlobalController.Instance.travelled;


        playerTurnTickets = GameController.playerTurn;
        //Debug.Log("in Update");

        //Debug.Log("Player can travel to: " + myInfoList.info[hubLocation[playerTurnTickets]].traveltoStr + " with " + myInfoList.info[hubLocation[playerTurnTickets]].ticketNum + " " + myInfoList.info[hubLocation[playerTurnTickets]].travelType + " tickets. From: " + myInfoList.info[hubLocation[playerTurnTickets]].locationStr);
        if (myInfoList.info[counters[playerTurnTickets - 1]].hubNum == hubLocation[playerTurnTickets - 1])
        {
            //Debug.Log("INSIDE HUB IF");
            if (myInfoList.info[counters[playerTurnTickets - 1]].locationNum == pLocation[playerTurnTickets - 1])
            {

                fromLocation.text = myInfoList.info[counters[playerTurnTickets - 1]].locationStr.ToString();
                toLocation.text = myInfoList.info[counters[playerTurnTickets - 1]].traveltoStr.ToString();

                //If its an airport
                if (myInfoList.info[counters[playerTurnTickets - 1]].traveltoStr == "London")
                {
                    airportPopup.gameObject.SetActive(true);
                }
                else if (myInfoList.info[counters[playerTurnTickets - 1]].traveltoStr == "Paris")
                {
                    airportPopup.gameObject.SetActive(true);
                }
                else if (myInfoList.info[counters[playerTurnTickets - 1]].traveltoStr == "Stockholm")
                {
                    airportPopup.gameObject.SetActive(true);
                }
                else
                {
                    airportPopup.gameObject.SetActive(false);
                }

                //No targets for airports 
                //Hub1 Locations
                if (myInfoList.info[counters[playerTurnTickets - 1]].traveltoStr == "Canterbury")
                {
                    hub1Targets[1].gameObject.SetActive(true);
                }
                else
                {
                    hub1Targets[1].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].traveltoStr == "Brussels")
                {
                    hub1Targets[2].gameObject.SetActive(true);
                }
                else
                {
                    hub1Targets[2].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].traveltoStr == "Amsterdam")
                {
                    hub1Targets[3].gameObject.SetActive(true);
                }
                else
                {
                    hub1Targets[3].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].traveltoStr == "Birmingham")
                {
                    hub1Targets[4].gameObject.SetActive(true);
                } 
                else
                {
                    hub1Targets[4].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].traveltoStr == "Liverpool")
                {
                    hub1Targets[5].gameObject.SetActive(true);
                }
                else
                {
                    hub1Targets[5].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].traveltoStr == "Leeds")
                {
                    hub1Targets[6].gameObject.SetActive(true);
                } 
                else 
                {
                    hub1Targets[6].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].traveltoStr == "Edinburgh")
                {
                    hub1Targets[7].gameObject.SetActive(true);
                } 
                else
                {
                    hub1Targets[7].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].traveltoStr == "Dublin")
                {
                    hub1Targets[8].gameObject.SetActive(true);
                }
                else
                {
                    hub1Targets[8].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].traveltoStr == "Belfast")
                {
                    hub1Targets[9].gameObject.SetActive(true);
                } 
                else
                {
                    hub1Targets[9].gameObject.SetActive(false);
                }

                //Hub2 Locations
                if (myInfoList.info[counters[playerTurnTickets - 1]].traveltoStr == "Luxembourg")
                {
                    hub2Targets[0].gameObject.SetActive(true);
                }
                else
                {
                    hub2Targets[0].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].traveltoStr == "Bern")
                {
                    hub2Targets[1].gameObject.SetActive(true);
                }
                else
                {
                    hub2Targets[1].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].traveltoStr == "Milan")
                {
                    hub2Targets[2].gameObject.SetActive(true);
                }
                else
                {
                    hub2Targets[2].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].traveltoStr == "Genoa")
                {
                    hub2Targets[3].gameObject.SetActive(true);
                }
                else
                {
                    hub2Targets[3].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].traveltoStr == "Monaco")
                {
                    hub2Targets[4].gameObject.SetActive(true);
                }
                else
                {
                    hub2Targets[4].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].traveltoStr == "Marseille")
                {
                    hub2Targets[5].gameObject.SetActive(true);
                }
                else
                {
                    hub2Targets[5].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].traveltoStr == "Toulouse")
                {
                    hub2Targets[6].gameObject.SetActive(true);
                }
                else
                {
                    hub2Targets[6].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].traveltoStr == "Boreaux")
                {
                    hub2Targets[7].gameObject.SetActive(true);
                }
                else
                {
                    hub2Targets[7].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].traveltoStr == "Lyon")
                {
                    hub2Targets[8].gameObject.SetActive(true);
                }
                else
                {
                    hub2Targets[8].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].traveltoStr == "Nantes")
                {
                    hub2Targets[9].gameObject.SetActive(true);
                }
                else
                {
                    hub2Targets[9].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].traveltoStr == "Brussels")
                {
                    hub2Targets[10].gameObject.SetActive(true);
                }
                else
                {
                    hub2Targets[10].gameObject.SetActive(false);
                }

                //Hub3 Locations
                if (myInfoList.info[counters[playerTurnTickets - 1]].traveltoStr == "Copenhagen")
                {
                    hub3Targets[0].gameObject.SetActive(true);
                }
                else
                {
                    hub3Targets[0].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].traveltoStr == "Gavle")
                {
                    hub3Targets[1].gameObject.SetActive(true);
                }
                else
                {
                    hub3Targets[1].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].traveltoStr == "Oslo")
                {
                    hub3Targets[2].gameObject.SetActive(true);
                }
                else
                {
                    hub3Targets[2].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].traveltoStr == "Bergen")
                {
                    hub3Targets[3].gameObject.SetActive(true);
                }
                else
                {
                    hub3Targets[3].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].traveltoStr == "Trondheim")
                {
                    hub3Targets[4].gameObject.SetActive(true);
                }
                else
                {
                    hub3Targets[4].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].traveltoStr == "Umea")
                {
                    hub3Targets[5].gameObject.SetActive(true);
                }
                else
                {
                    hub3Targets[5].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].traveltoStr == "Lulea")
                {
                    hub3Targets[6].gameObject.SetActive(true);
                }
                else
                {
                    hub3Targets[6].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].traveltoStr == "Oulu")
                {
                    hub3Targets[7].gameObject.SetActive(true);
                }
                else
                {
                    hub3Targets[7].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].traveltoStr == "Tampere")
                {
                    hub3Targets[8].gameObject.SetActive(true);
                }
                else
                {
                    hub3Targets[8].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].traveltoStr == "Helsinki")
                {
                    hub3Targets[9].gameObject.SetActive(true);
                }
                else
                {
                    hub3Targets[9].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].traveltoStr == "St. Petersburg")
                {
                    hub3Targets[10].gameObject.SetActive(true);
                }
                else
                {
                    hub3Targets[10].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].traveltoStr == "Gdansk")
                {
                    hub3Targets[11].gameObject.SetActive(true);
                }
                else
                {
                    hub3Targets[11].gameObject.SetActive(false);
                }

                //No targets for airports 
                //FromHub1 Locations
                if (myInfoList.info[counters[playerTurnTickets - 1]].locationStr == "London")
                {
                    fromhub1Targets[0].gameObject.SetActive(true);
                }
                else
                {
                    fromhub1Targets[0].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].locationStr == "Canterbury")
                {
                    fromhub1Targets[1].gameObject.SetActive(true);
                }
                else
                {
                    fromhub1Targets[1].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].locationStr == "Brussels")
                {
                    fromhub1Targets[2].gameObject.SetActive(true);
                }
                else
                {
                    fromhub1Targets[2].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].locationStr == "Amsterdam")
                {
                    fromhub1Targets[3].gameObject.SetActive(true);
                }
                else
                {
                    fromhub1Targets[3].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].locationStr == "Birmingham")
                {
                    fromhub1Targets[4].gameObject.SetActive(true);
                }
                else
                {
                    fromhub1Targets[4].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].locationStr == "Liverpool")
                {
                    fromhub1Targets[5].gameObject.SetActive(true);
                }
                else
                {
                    fromhub1Targets[5].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].locationStr == "Leeds")
                {
                    fromhub1Targets[6].gameObject.SetActive(true);
                }
                else
                {
                    fromhub1Targets[6].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].locationStr == "Edinburgh")
                {
                    fromhub1Targets[7].gameObject.SetActive(true);
                }
                else
                {
                    fromhub1Targets[7].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].locationStr == "Dublin")
                {
                    fromhub1Targets[8].gameObject.SetActive(true);
                }
                else
                {
                    fromhub1Targets[8].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].locationStr == "Belfast")
                {
                    fromhub1Targets[9].gameObject.SetActive(true);
                }
                else
                {
                    fromhub1Targets[9].gameObject.SetActive(false);
                }

                //FromHub2 Locations
                if (myInfoList.info[counters[playerTurnTickets - 1]].locationStr == "Luxembourg")
                {
                    fromhub2Targets[0].gameObject.SetActive(true);
                }
                else
                {
                    fromhub2Targets[0].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].locationStr == "Bern")
                {
                    fromhub2Targets[1].gameObject.SetActive(true);
                }
                else
                {
                    fromhub2Targets[1].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].locationStr == "Milan")
                {
                    fromhub2Targets[2].gameObject.SetActive(true);
                }
                else
                {
                    fromhub2Targets[2].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].locationStr == "Genoa")
                {
                    fromhub2Targets[3].gameObject.SetActive(true);
                }
                else
                {
                    fromhub2Targets[3].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].locationStr == "Monaco")
                {
                    fromhub2Targets[4].gameObject.SetActive(true);
                }
                else
                {
                    fromhub2Targets[4].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].locationStr == "Marseille")
                {
                    fromhub2Targets[5].gameObject.SetActive(true);
                }
                else
                {
                    fromhub2Targets[5].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].locationStr == "Toulouse")
                {
                    fromhub2Targets[6].gameObject.SetActive(true);
                }
                else
                {
                    fromhub2Targets[6].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].locationStr == "Boreaux")
                {
                    fromhub2Targets[7].gameObject.SetActive(true);
                }
                else
                {
                    fromhub2Targets[7].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].locationStr == "Lyon")
                {
                    fromhub2Targets[8].gameObject.SetActive(true);
                }
                else
                {
                    fromhub2Targets[8].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].locationStr == "Nantes")
                {
                    fromhub2Targets[9].gameObject.SetActive(true);
                }
                else
                {
                    fromhub2Targets[9].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].locationStr == "Brussels")
                {
                    fromhub2Targets[10].gameObject.SetActive(true);
                }
                else
                {
                    fromhub2Targets[10].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].locationStr == "Paris")
                {
                    fromhub2Targets[11].gameObject.SetActive(true);
                }
                else
                {
                    fromhub2Targets[11].gameObject.SetActive(false);
                }

                //FromHub3 Locations
                if (myInfoList.info[counters[playerTurnTickets - 1]].locationStr == "Copenhagen")
                {
                    fromhub3Targets[0].gameObject.SetActive(true);
                }
                else
                {
                    fromhub3Targets[0].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].locationStr == "Gavle")
                {
                    fromhub3Targets[1].gameObject.SetActive(true);
                }
                else
                {
                    fromhub3Targets[1].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].locationStr == "Oslo")
                {
                    fromhub3Targets[2].gameObject.SetActive(true);
                }
                else
                {
                    fromhub3Targets[2].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].locationStr == "Bergen")
                {
                    fromhub3Targets[3].gameObject.SetActive(true);
                }
                else
                {
                    fromhub3Targets[3].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].locationStr == "Trondheim")
                {
                    fromhub3Targets[4].gameObject.SetActive(true);
                }
                else
                {
                    fromhub3Targets[4].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].locationStr == "Umea")
                {
                    fromhub3Targets[5].gameObject.SetActive(true);
                }
                else
                {
                    fromhub3Targets[5].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].locationStr == "Lulea")
                {
                    fromhub3Targets[6].gameObject.SetActive(true);
                }
                else
                {
                    fromhub3Targets[6].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].locationStr == "Oulu")
                {
                    fromhub3Targets[7].gameObject.SetActive(true);
                }
                else
                {
                    fromhub3Targets[7].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].locationStr == "Tampere")
                {
                    fromhub3Targets[8].gameObject.SetActive(true);
                }
                else
                {
                    fromhub3Targets[8].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].locationStr == "Helsinki")
                {
                    fromhub3Targets[9].gameObject.SetActive(true);
                }
                else
                {
                    fromhub3Targets[9].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].locationStr == "St. Petersburg")
                {
                    fromhub3Targets[10].gameObject.SetActive(true);
                }
                else
                {
                    fromhub3Targets[10].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].locationStr == "Gdansk")
                {
                    fromhub3Targets[11].gameObject.SetActive(true);
                }
                else
                {
                    fromhub3Targets[11].gameObject.SetActive(false);
                }
                if (myInfoList.info[counters[playerTurnTickets - 1]].locationStr == "Stockholm")
                {
                    fromhub3Targets[12].gameObject.SetActive(true);
                }
                else
                {
                    fromhub3Targets[12].gameObject.SetActive(false);
                }


                if (myInfoList.info[counters[playerTurnTickets - 1]].travelType == "Air")
                {
                    airTravel.text = myInfoList.info[counters[playerTurnTickets - 1]].ticketNum.ToString();
                    trainTravel.text = "0";
                    boatTravel.text = "0";
                    roadTravel.text = "0";

                    spriteRenderer.sprite = tickets[0];

                }

                if (myInfoList.info[counters[playerTurnTickets - 1]].travelType == "Train")
                {
                    trainTravel.text = myInfoList.info[counters[playerTurnTickets - 1]].ticketNum.ToString();
                    airTravel.text = "0";
                    boatTravel.text = "0";
                    roadTravel.text = "0";
                    spriteRenderer.sprite = tickets[1];
                }

                if (myInfoList.info[counters[playerTurnTickets - 1]].travelType == "Boat")
                {
                    boatTravel.text = myInfoList.info[counters[playerTurnTickets - 1]].ticketNum.ToString();
                    trainTravel.text = "0";
                    airTravel.text = "0";
                    roadTravel.text = "0";
                    spriteRenderer.sprite = tickets[2];
                }

                if (myInfoList.info[counters[playerTurnTickets - 1]].travelType == "Road")
                {
                    roadTravel.text = myInfoList.info[counters[playerTurnTickets - 1]].ticketNum.ToString();
                    trainTravel.text = "0";
                    boatTravel.text = "0";
                    airTravel.text = "0";
                    spriteRenderer.sprite = tickets[3];
                }
            }
        }
    }

    public void setCounter()
    {
      for (int i = tableSize - 1; i >= 0; i--)
      {
        if (myInfoList.info[i].hubNum == hubLocation[playerTurnTickets - 1])
        {
          if (myInfoList.info[i].locationNum == pLocation[playerTurnTickets - 1])
          {
            counters[playerTurnTickets - 1] = i;
            Debug.Log("new counter value: " + counters[playerTurnTickets - 1]);
          }
        }
      }
    }

    public void SavePlayer()
    {
        //Player 1 info to save
        GlobalController.Instance.player1Tickets = player1Tickets;

        //Player 2 info to save
        GlobalController.Instance.player2Tickets = player2Tickets;

        //Player 3 info to save
        GlobalController.Instance.player3Tickets = player3Tickets;

        //Player 4 info to save
        GlobalController.Instance.player4Tickets = player4Tickets;

        //Player 5 info to save
        GlobalController.Instance.player5Tickets = player5Tickets;

        //Player 6 info to save
        GlobalController.Instance.player6Tickets = player6Tickets;

        GlobalController.Instance.pLocation = pLocation;
        GlobalController.Instance.hubLocation = hubLocation;
        GlobalController.Instance.counters = counters;

    }

    public void FwdButton()
    {
      if (counters[playerTurnTickets - 1] != (tableSize - 1) && hubLocation[playerTurnTickets - 1] == myInfoList.info[counters[playerTurnTickets - 1] + 1].hubNum && pLocation[playerTurnTickets - 1] == myInfoList.info[counters[playerTurnTickets - 1] + 1].locationNum)
      {
        counters[playerTurnTickets - 1]++;
      }
    }

    public void PrevButton()
    {
      if (counters[playerTurnTickets - 1] != 0 && hubLocation[playerTurnTickets - 1] == myInfoList.info[counters[playerTurnTickets - 1] - 1].hubNum && pLocation[playerTurnTickets - 1] == myInfoList.info[counters[playerTurnTickets - 1] - 1].locationNum)
      {
        counters[playerTurnTickets - 1]--;
      }
    }

    public void TravelBtn()
    {
        InfoPopup.gameObject.SetActive(true);
        InfoText.text = "Are you sure you want to travel? Traveling will end your turn.";
        confirmTravelBtn.gameObject.SetActive(true);
        nopeBtn.gameObject.SetActive(true);
    }

    public void noBtn()
    {
        InfoPopup.gameObject.SetActive(false);
        confirmTravelBtn.gameObject.SetActive(false);
        nopeBtn.gameObject.SetActive(false);
    }

    public void ConfirmTravelBtn()
    {
      if (travelled[playerTurnTickets - 1] == 1)
      {
        InfoPopup.gameObject.SetActive(true);
        InfoText.text = "You cannot travel twice in a turn";
        Debug.Log("cannot travel twice a turn");
        return;
      }
      switch (playerTurnTickets)
      {
        case 1:
        if (myInfoList.info[counters[playerTurnTickets - 1]].travelType == "Air")
        {
            if (player1Tickets[1] >= myInfoList.info[counters[playerTurnTickets - 1]].ticketNum)
            {
              player1Tickets[1] = player1Tickets[1] - myInfoList.info[counters[playerTurnTickets - 1]].ticketNum;
              hubLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].hubtoNum;
              pLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].traveltoNum;

              InfoPopup.gameObject.SetActive(true);
              InfoText.text = "You've committed to travel to " + myInfoList.info[counters[playerTurnTickets - 1]].locationStr + ". You will begin your next turn there.";

              setCounter();
              travelled[playerTurnTickets - 1] = 1;



              SceneManager.LoadScene("PlayResource", LoadSceneMode.Single);
            }
            else
            {
                        InfoPopup.gameObject.SetActive(true);
                        ConfirmInfoPopup.gameObject.SetActive(true);
                        InfoText.text = "Insufficient Ticket Amount";
                        Debug.Log("insufficient");
                        confirmTravelBtn.gameObject.SetActive(false);
                        nopeBtn.gameObject.SetActive(false);
                        //insufficient tickets
                    }
        }

        if (myInfoList.info[counters[playerTurnTickets - 1]].travelType == "Train")
        {
            //trainTravel;
            if (player1Tickets[2] >= myInfoList.info[counters[playerTurnTickets - 1]].ticketNum)
            {
              player1Tickets[2] = player1Tickets[2] - myInfoList.info[counters[playerTurnTickets - 1]].ticketNum;
              hubLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].hubtoNum;
              pLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].traveltoNum;

              InfoPopup.gameObject.SetActive(true);
              InfoText.text = "You've committed to travel to " + myInfoList.info[counters[playerTurnTickets - 1]].locationStr + ". You will begin your next turn there.";

              setCounter();

              travelled[playerTurnTickets - 1] = 1;

              SceneManager.LoadScene("PlayResource", LoadSceneMode.Single);
            }
            else
            {
                        InfoPopup.gameObject.SetActive(true);
                        ConfirmInfoPopup.gameObject.SetActive(true);
                        InfoText.text = "Insufficient Ticket Amount";
                        Debug.Log("insufficient");
                        confirmTravelBtn.gameObject.SetActive(false);
                        nopeBtn.gameObject.SetActive(false);
                        //insufficient tickets
                    }
        }

        if (myInfoList.info[counters[playerTurnTickets - 1]].travelType == "Boat")
        {
            //boatTravel;
            if (player1Tickets[0] >= myInfoList.info[counters[playerTurnTickets - 1]].ticketNum)
            {
              player1Tickets[0] = player1Tickets[0] - myInfoList.info[counters[playerTurnTickets - 1]].ticketNum;
              hubLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].hubtoNum;
              pLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].traveltoNum;

              InfoPopup.gameObject.SetActive(true);
              InfoText.text = "You've committed to travel to " + myInfoList.info[counters[playerTurnTickets - 1]].locationStr + ". You will begin your next turn there.";

              setCounter();

              travelled[playerTurnTickets - 1] = 1;
              SceneManager.LoadScene("PlayResource", LoadSceneMode.Single);
            }
            else
            {
                        InfoPopup.gameObject.SetActive(true);
                        ConfirmInfoPopup.gameObject.SetActive(true);
                        InfoText.text = "Insufficient Ticket Amount";
                        Debug.Log("insufficient");
                        confirmTravelBtn.gameObject.SetActive(false);
                        nopeBtn.gameObject.SetActive(false);
                        //insufficient tickets
                    }
        }

        if (myInfoList.info[counters[playerTurnTickets - 1]].travelType == "Road")
        {
            //roadTravel;
            if (player1Tickets[3] >= myInfoList.info[counters[playerTurnTickets - 1]].ticketNum)
            {
              player1Tickets[3] = player1Tickets[3] - myInfoList.info[counters[playerTurnTickets - 1]].ticketNum;
              hubLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].hubtoNum;
              pLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].traveltoNum;

              InfoPopup.gameObject.SetActive(true);
              InfoText.text = "You've committed to travel to " + myInfoList.info[counters[playerTurnTickets - 1]].locationStr + ". You will begin your next turn there.";

              setCounter();

              travelled[playerTurnTickets - 1] = 1;
              SceneManager.LoadScene("PlayResource", LoadSceneMode.Single);
            }
            else
            {
                        InfoPopup.gameObject.SetActive(true);
                        ConfirmInfoPopup.gameObject.SetActive(true);
                        InfoText.text = "Insufficient Ticket Amount";
                        Debug.Log("insufficient");
                        confirmTravelBtn.gameObject.SetActive(false);
                        nopeBtn.gameObject.SetActive(false);
                        //insufficient tickets
                    }
        }
        break;

        case 2:

        if (myInfoList.info[counters[playerTurnTickets - 1]].travelType == "Air")
        {
          if (player2Tickets[1] >= myInfoList.info[counters[playerTurnTickets - 1]].ticketNum)
          {
            player2Tickets[1] = player2Tickets[1] - myInfoList.info[counters[playerTurnTickets - 1]].ticketNum;
            hubLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].hubtoNum;
            pLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].traveltoNum;

            InfoPopup.gameObject.SetActive(true);
            InfoText.text = "You've committed to travel to " + myInfoList.info[counters[playerTurnTickets - 1]].locationStr + ". You will begin your next turn there.";

            setCounter();
            //playerMoves--;
            travelled[playerTurnTickets - 1] = 1;
            SceneManager.LoadScene("PlayResource", LoadSceneMode.Single);
          }
          else
          {
                        InfoPopup.gameObject.SetActive(true);
                        ConfirmInfoPopup.gameObject.SetActive(true);
                        InfoText.text = "Insufficient Ticket Amount";
                        confirmTravelBtn.gameObject.SetActive(false);
                        nopeBtn.gameObject.SetActive(false);
                        //insufficient tickets
                    }
        }

        if (myInfoList.info[counters[playerTurnTickets - 1]].travelType == "Train")
        {
          if (player2Tickets[2] >= myInfoList.info[counters[playerTurnTickets - 1]].ticketNum)
          {
            player2Tickets[2] = player2Tickets[2] - myInfoList.info[counters[playerTurnTickets - 1]].ticketNum;
            hubLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].hubtoNum;
            pLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].traveltoNum;
            setCounter();
            //playerMoves--;
            travelled[playerTurnTickets - 1] = 1;
            SceneManager.LoadScene("PlayResource", LoadSceneMode.Single);
          }
          else
          {
                        InfoPopup.gameObject.SetActive(true);
                        ConfirmInfoPopup.gameObject.SetActive(true);
                        InfoText.text = "Insufficient Ticket Amount";
                        Debug.Log("insufficient");
                        confirmTravelBtn.gameObject.SetActive(false);
                        nopeBtn.gameObject.SetActive(false);
                        //insufficient tickets
                    }
        }

        if (myInfoList.info[counters[playerTurnTickets - 1]].travelType == "Boat")
        {
          if (player2Tickets[0] >= myInfoList.info[counters[playerTurnTickets - 1]].ticketNum)
          {
            player2Tickets[0] = player2Tickets[0] - myInfoList.info[counters[playerTurnTickets - 1]].ticketNum;
            hubLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].hubtoNum;
            pLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].traveltoNum;
            setCounter();
            //playerMoves--;
            travelled[playerTurnTickets - 1] = 1;
            SceneManager.LoadScene("PlayResource", LoadSceneMode.Single);
          }
          else
          {
                        InfoPopup.gameObject.SetActive(true);
                        ConfirmInfoPopup.gameObject.SetActive(true);
                        InfoText.text = "Insufficient Ticket Amount";
                        Debug.Log("insufficient");
                        confirmTravelBtn.gameObject.SetActive(false);
                        nopeBtn.gameObject.SetActive(false);
                        //insufficient tickets
                    }
        }

        if (myInfoList.info[counters[playerTurnTickets - 1]].travelType == "Road")
        {
          if (player2Tickets[3] >= myInfoList.info[counters[playerTurnTickets - 1]].ticketNum)
          {
            player2Tickets[3] = player2Tickets[3] - myInfoList.info[counters[playerTurnTickets - 1]].ticketNum;
            hubLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].hubtoNum;
            pLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].traveltoNum;
            setCounter();
            //playerMoves--;
            travelled[playerTurnTickets - 1] = 1;
            SceneManager.LoadScene("PlayResource", LoadSceneMode.Single);
          }
          else
          {
                        InfoPopup.gameObject.SetActive(true);
                        ConfirmInfoPopup.gameObject.SetActive(true);
                        InfoText.text = "Insufficient Ticket Amount";
                        Debug.Log("insufficient");
                        confirmTravelBtn.gameObject.SetActive(false);
                        nopeBtn.gameObject.SetActive(false);
                        //insufficient tickets
                    }
        }

        break;

        case 3:

        if (myInfoList.info[counters[playerTurnTickets - 1]].travelType == "Air")
        {
          if (player3Tickets[1] >= myInfoList.info[counters[playerTurnTickets - 1]].ticketNum)
          {
            player3Tickets[1] = player3Tickets[1] - myInfoList.info[counters[playerTurnTickets - 1]].ticketNum;
            hubLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].hubtoNum;
            pLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].traveltoNum;
            setCounter();
            //playerMoves--;
            travelled[playerTurnTickets - 1] = 1;
            SceneManager.LoadScene("PlayResource", LoadSceneMode.Single);
          }
          else
          {
                        InfoPopup.gameObject.SetActive(true);
                        ConfirmInfoPopup.gameObject.SetActive(true);
                        InfoText.text = "Insufficient Ticket Amount";
                        Debug.Log("insufficient");
                        confirmTravelBtn.gameObject.SetActive(false);
                        nopeBtn.gameObject.SetActive(false);
                        //insufficient tickets
                    }
        }

        if (myInfoList.info[counters[playerTurnTickets - 1]].travelType == "Train")
        {
          if (player3Tickets[2] >= myInfoList.info[counters[playerTurnTickets - 1]].ticketNum)
          {
            player3Tickets[2] = player3Tickets[2] - myInfoList.info[counters[playerTurnTickets - 1]].ticketNum;
            hubLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].hubtoNum;
            pLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].traveltoNum;
            setCounter();
            //playerMoves--;
            travelled[playerTurnTickets - 1] = 1;
            SceneManager.LoadScene("PlayResource", LoadSceneMode.Single);
          }
          else
          {
                        InfoPopup.gameObject.SetActive(true);
                        ConfirmInfoPopup.gameObject.SetActive(true);
                        InfoText.text = "Insufficient Ticket Amount";
                        Debug.Log("insufficient");
                        confirmTravelBtn.gameObject.SetActive(false);
                        nopeBtn.gameObject.SetActive(false);
                        //insufficient tickets
                    }
            //trainTravel;
        }

        if (myInfoList.info[counters[playerTurnTickets - 1]].travelType == "Boat")
        {
          if (player3Tickets[0] >= myInfoList.info[counters[playerTurnTickets - 1]].ticketNum)
          {
            player3Tickets[0] = player3Tickets[0] - myInfoList.info[counters[playerTurnTickets - 1]].ticketNum;
            hubLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].hubtoNum;
            pLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].traveltoNum;
            setCounter();
            //playerMoves--;
            travelled[playerTurnTickets - 1] = 1;
            SceneManager.LoadScene("PlayResource", LoadSceneMode.Single);
          }
          else
          {
                        InfoPopup.gameObject.SetActive(true);
                        ConfirmInfoPopup.gameObject.SetActive(true);
                        InfoText.text = "Insufficient Ticket Amount";
                        Debug.Log("insufficient");
                        confirmTravelBtn.gameObject.SetActive(false);
                        nopeBtn.gameObject.SetActive(false);
                        //insufficient tickets
                    }
            //boatTravel;
        }

        if (myInfoList.info[counters[playerTurnTickets - 1]].travelType == "Road")
        {
          if (player3Tickets[3] >= myInfoList.info[counters[playerTurnTickets - 1]].ticketNum)
          {
            player3Tickets[3] = player3Tickets[3] - myInfoList.info[counters[playerTurnTickets - 1]].ticketNum;
            hubLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].hubtoNum;
            pLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].traveltoNum;
            setCounter();
            //playerMoves--;
            travelled[playerTurnTickets - 1] = 1;
            SceneManager.LoadScene("PlayResource", LoadSceneMode.Single);
          }
          else
          {
                        InfoPopup.gameObject.SetActive(true);
                        ConfirmInfoPopup.gameObject.SetActive(true);
                        InfoText.text = "Insufficient Ticket Amount";
                        Debug.Log("insufficient");
                        confirmTravelBtn.gameObject.SetActive(false);
                        nopeBtn.gameObject.SetActive(false);
                        //insufficient tickets
                    }
            //roadTravel;
        }

        break;

        case 4:

        if (myInfoList.info[counters[playerTurnTickets - 1]].travelType == "Air")
        {
          if (player4Tickets[1] >= myInfoList.info[counters[playerTurnTickets - 1]].ticketNum)
          {
            player4Tickets[1] = player4Tickets[1] - myInfoList.info[counters[playerTurnTickets - 1]].ticketNum;
            hubLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].hubtoNum;
            pLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].traveltoNum;
            setCounter();
            //playerMoves--;
            travelled[playerTurnTickets - 1] = 1;
            SceneManager.LoadScene("PlayResource", LoadSceneMode.Single);
          }
          else
          {
                        InfoPopup.gameObject.SetActive(true);
                        ConfirmInfoPopup.gameObject.SetActive(true);
                        InfoText.text = "Insufficient Ticket Amount";
                        Debug.Log("insufficient");
                        confirmTravelBtn.gameObject.SetActive(false);
                        nopeBtn.gameObject.SetActive(false);
                        //insufficient tickets
                    }
        }

        if (myInfoList.info[counters[playerTurnTickets - 1]].travelType == "Train")
        {
          if (player4Tickets[2] >= myInfoList.info[counters[playerTurnTickets - 1]].ticketNum)
          {
            player4Tickets[2] = player4Tickets[2] - myInfoList.info[counters[playerTurnTickets - 1]].ticketNum;
            hubLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].hubtoNum;
            pLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].traveltoNum;
            setCounter();
            //playerMoves--;
            travelled[playerTurnTickets - 1] = 1;
            SceneManager.LoadScene("PlayResource", LoadSceneMode.Single);
          }
          else
          {
                        InfoPopup.gameObject.SetActive(true);
                        ConfirmInfoPopup.gameObject.SetActive(true);
                        InfoText.text = "Insufficient Ticket Amount";
                        Debug.Log("insufficient");
                        confirmTravelBtn.gameObject.SetActive(false);
                        nopeBtn.gameObject.SetActive(false);
                        //insufficient tickets
                    }
            //trainTravel;
        }

        if (myInfoList.info[counters[playerTurnTickets - 1]].travelType == "Boat")
        {
            //boatTravel;
            if (player4Tickets[0] >= myInfoList.info[counters[playerTurnTickets - 1]].ticketNum)
            {
              player4Tickets[0] = player4Tickets[0] - myInfoList.info[counters[playerTurnTickets - 1]].ticketNum;
              hubLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].hubtoNum;
              pLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].traveltoNum;
              setCounter();
              //playerMoves--;
              travelled[playerTurnTickets - 1] = 1;
              SceneManager.LoadScene("PlayResource", LoadSceneMode.Single);
            }
            else
            {
                        InfoPopup.gameObject.SetActive(true);
                        ConfirmInfoPopup.gameObject.SetActive(true);
                        InfoText.text = "Insufficient Ticket Amount";
                        Debug.Log("insufficient");
                        confirmTravelBtn.gameObject.SetActive(false);
                        nopeBtn.gameObject.SetActive(false);
                        //insufficient tickets
                    }
        }

        if (myInfoList.info[counters[playerTurnTickets - 1]].travelType == "Road")
        {
            //roadTravel;
            if (player4Tickets[3] >= myInfoList.info[counters[playerTurnTickets - 1]].ticketNum)
            {
              player4Tickets[3] = player4Tickets[3] - myInfoList.info[counters[playerTurnTickets - 1]].ticketNum;
              hubLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].hubtoNum;
              pLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].traveltoNum;
              setCounter();
              //playerMoves--;
              travelled[playerTurnTickets - 1] = 1;

              SceneManager.LoadScene("PlayResource", LoadSceneMode.Single);
            }
            else
            {
                        InfoPopup.gameObject.SetActive(true);
                        ConfirmInfoPopup.gameObject.SetActive(true);
                        InfoText.text = "Insufficient Ticket Amount";
                        Debug.Log("insufficient");
                        confirmTravelBtn.gameObject.SetActive(false);
                        nopeBtn.gameObject.SetActive(false);
                        //insufficient tickets
                    }
        }

        break;

        case 5:

        if (myInfoList.info[counters[playerTurnTickets - 1]].travelType == "Air")
        {
          if (player5Tickets[1] >= myInfoList.info[counters[playerTurnTickets - 1]].ticketNum)
          {
            player5Tickets[1] = player5Tickets[1] - myInfoList.info[counters[playerTurnTickets - 1]].ticketNum;
            hubLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].hubtoNum;
            pLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].traveltoNum;
            setCounter();
            //playerMoves--;
            travelled[playerTurnTickets - 1] = 1;
            SceneManager.LoadScene("PlayResource", LoadSceneMode.Single);
          }
          else
          {
                        InfoPopup.gameObject.SetActive(true);
                        ConfirmInfoPopup.gameObject.SetActive(true);
                        InfoText.text = "Insufficient Ticket Amount";
                        Debug.Log("insufficient");
                        confirmTravelBtn.gameObject.SetActive(false);
                        nopeBtn.gameObject.SetActive(false);
                        //insufficient tickets
                    }

        }

        if (myInfoList.info[counters[playerTurnTickets - 1]].travelType == "Train")
        {
          if (player5Tickets[2] >= myInfoList.info[counters[playerTurnTickets - 1]].ticketNum)
          {
            player5Tickets[2] = player5Tickets[2] - myInfoList.info[counters[playerTurnTickets - 1]].ticketNum;
            hubLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].hubtoNum;
            pLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].traveltoNum;
            setCounter();
            //playerMoves--;
            travelled[playerTurnTickets - 1] = 1;
            SceneManager.LoadScene("PlayResource", LoadSceneMode.Single);
          }
          else
          {
                        InfoPopup.gameObject.SetActive(true);
                        ConfirmInfoPopup.gameObject.SetActive(true);
                        InfoText.text = "Insufficient Ticket Amount";
                        Debug.Log("insufficient");
                        confirmTravelBtn.gameObject.SetActive(false);
                        nopeBtn.gameObject.SetActive(false);
                        //insufficient tickets
                    }
            //trainTravel;
        }

        if (myInfoList.info[counters[playerTurnTickets - 1]].travelType == "Boat")
        {
          if (player5Tickets[0] >= myInfoList.info[counters[playerTurnTickets - 1]].ticketNum)
          {
            player5Tickets[0] = player5Tickets[0] - myInfoList.info[counters[playerTurnTickets - 1]].ticketNum;
            hubLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].hubtoNum;
            pLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].traveltoNum;
            setCounter();
            //playerMoves--;
            travelled[playerTurnTickets - 1] = 1;
            SceneManager.LoadScene("PlayResource", LoadSceneMode.Single);
          }
          else
          {
                        InfoPopup.gameObject.SetActive(true);
                        ConfirmInfoPopup.gameObject.SetActive(true);
                        InfoText.text = "Insufficient Ticket Amount";
                        Debug.Log("insufficient");
                        confirmTravelBtn.gameObject.SetActive(false);
                        nopeBtn.gameObject.SetActive(false);
                        //insufficient tickets
                    }
            //boatTravel;
        }

        if (myInfoList.info[counters[playerTurnTickets - 1]].travelType == "Road")
        {
          if (player5Tickets[3] >= myInfoList.info[counters[playerTurnTickets - 1]].ticketNum)
          {
            player5Tickets[3] = player5Tickets[3] - myInfoList.info[counters[playerTurnTickets - 1]].ticketNum;
            hubLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].hubtoNum;
            pLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].traveltoNum;
            setCounter();
            //playerMoves--;
            travelled[playerTurnTickets - 1] = 1;
            SceneManager.LoadScene("PlayResource", LoadSceneMode.Single);
          }
          else
          {
                        InfoPopup.gameObject.SetActive(true);
                        ConfirmInfoPopup.gameObject.SetActive(true);
                        InfoText.text = "Insufficient Ticket Amount";
                        Debug.Log("insufficient");
                        confirmTravelBtn.gameObject.SetActive(false);
                        nopeBtn.gameObject.SetActive(false);
                        //insufficient tickets
                    }
            //roadTravel;
        }

        break;

        case 6:

        if (myInfoList.info[counters[playerTurnTickets - 1]].travelType == "Air")
        {
          if (player6Tickets[1] >= myInfoList.info[counters[playerTurnTickets - 1]].ticketNum)
          {
            player6Tickets[1] = player6Tickets[1] - myInfoList.info[counters[playerTurnTickets - 1]].ticketNum;
            hubLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].hubtoNum;
            pLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].traveltoNum;
            setCounter();
            //playerMoves--;
            travelled[playerTurnTickets - 1] = 1;
            SceneManager.LoadScene("PlayResource", LoadSceneMode.Single);
          }
          else
          {
                        InfoPopup.gameObject.SetActive(true);
                        ConfirmInfoPopup.gameObject.SetActive(true);
                        InfoText.text = "Insufficient Ticket Amount";
                        Debug.Log("insufficient");
                        confirmTravelBtn.gameObject.SetActive(false);
                        nopeBtn.gameObject.SetActive(false);
                        //insufficient tickets
                    }
        }

        if (myInfoList.info[counters[playerTurnTickets - 1]].travelType == "Train")
        {
          if (player6Tickets[2] >= myInfoList.info[counters[playerTurnTickets - 1]].ticketNum)
          {
            player6Tickets[2] = player6Tickets[2] - myInfoList.info[counters[playerTurnTickets - 1]].ticketNum;
            hubLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].hubtoNum;
            pLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].traveltoNum;
            setCounter();
            //playerMoves--;
            travelled[playerTurnTickets - 1] = 1;
            SceneManager.LoadScene("PlayResource", LoadSceneMode.Single);
          }
          else
          {
                        InfoPopup.gameObject.SetActive(true);
                        ConfirmInfoPopup.gameObject.SetActive(true);
                        InfoText.text = "Insufficient Ticket Amount";
                        Debug.Log("insufficient");
                        confirmTravelBtn.gameObject.SetActive(false);
                        nopeBtn.gameObject.SetActive(false);
                        //insufficient tickets
                    }
        }

        if (myInfoList.info[counters[playerTurnTickets - 1]].travelType == "Boat")
        {
          if (player6Tickets[0] >= myInfoList.info[counters[playerTurnTickets - 1]].ticketNum)
          {
            player6Tickets[0] = player6Tickets[0] - myInfoList.info[counters[playerTurnTickets - 1]].ticketNum;
            hubLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].hubtoNum;
            pLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].traveltoNum;
            setCounter();
            //playerMoves--;
            travelled[playerTurnTickets - 1] = 1;
            SceneManager.LoadScene("PlayResource", LoadSceneMode.Single);
          }
          else
          {
                        InfoPopup.gameObject.SetActive(true);
                        ConfirmInfoPopup.gameObject.SetActive(true);
                        InfoText.text = "Insufficient Ticket Amount";
                        Debug.Log("insufficient");
                        confirmTravelBtn.gameObject.SetActive(false);
                        nopeBtn.gameObject.SetActive(false);
                        //insufficient tickets
                    }
        }

        if (myInfoList.info[counters[playerTurnTickets - 1]].travelType == "Road")
        {
          if (player6Tickets[3] >= myInfoList.info[counters[playerTurnTickets - 1]].ticketNum)
          {
            player6Tickets[3] = player6Tickets[3] - myInfoList.info[counters[playerTurnTickets - 1]].ticketNum;
            hubLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].hubtoNum;
            pLocation[playerTurnTickets - 1] = myInfoList.info[counters[playerTurnTickets - 1]].traveltoNum;
            setCounter();
            //playerMoves--;
            travelled[playerTurnTickets - 1] = 1;
            SceneManager.LoadScene("PlayResource", LoadSceneMode.Single);
          }
          else
          {
                        InfoPopup.gameObject.SetActive(true);
                        ConfirmInfoPopup.gameObject.SetActive(true);
                        InfoText.text = "Insufficient Ticket Amount";
                        Debug.Log("insufficient");
                        confirmTravelBtn.gameObject.SetActive(false);
                        nopeBtn.gameObject.SetActive(false);
                    }
            //roadTravel;
        }
        break;
      }


        //SavePlayer();

    }

    public void confirmPopup()
    {
        InfoPopup.gameObject.SetActive(false);
        ConfirmInfoPopup.gameObject.SetActive(false);

    }

}

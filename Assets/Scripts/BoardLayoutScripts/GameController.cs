using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using TMPro;
using UnityEngine.SceneManagement;

public class Enemy
{
    public int hubNum;
    public int locationNum;
    public int damage;

    public Enemy(int h, int l)
    {
        hubNum = h;
        locationNum = l;
        damage = Random.Range(30, 50);
    }
}

public class Mission
{
    public int hubNum;
    public int locationNum;
    public int skillNum;
    public int pointsReq;
    public int victoryPoints;
    public bool[] completedBy = new bool[6];
    public int cooldown;
    public int trophyType;

    public Mission(int h, int l, int s, int t)
    {
        hubNum = h;
        locationNum = l;
        skillNum = s;
        trophyType = t;
        cooldown = 0;


        pointsReq = ML_Algo.ML() + 1;
        victoryPoints = ML_Algo.ML() + 3;

        for (int i = 0; i < 6; i++)
        {
            completedBy[i] = false;
        }
    }
}

public class GameController : MonoBehaviour
{
    public GameObject[] TargetsHub0;
    public GameObject[] TargetsHub1;
    public GameObject[] TargetsHub2;
    public GameObject infoPopup;
    public TMP_Text Popupinfo;

    public GameObject EndTurnBtn;
    public GameObject TicketsBtn;
    public GameObject AquireTicketsBtn;
    public GameObject ObjectsBtn;
    public GameObject SkillsBtn;
    public GameObject MissionBtn;


    public Text p1Popup;
    public Text p2Popup;
    public Text p3Popup;
    public Text p4Popup;
    public Text p5Popup;
    public Text p6Popup;

    public int rounds;
    //Skillsp1Script.GetComponent<Skillsp1>();
    public List<string> log = new List<string>();
    public List<Enemy> enemies = new List<Enemy>();

    public List<int> turnOrder = new List<int>();

    public static string[] skillNames = new string[] { "Strength", "Stealth", "Currency", "Intelligence", "Munitions", "Electronics", "Vehicle Piloting", "Code Breaking" };
    public int currentMissionIndex;

    public Image fillImage;
    public Slider slider;

    //public List<Mission> missions = new List<Mission>();
    public Mission[] missions;

    public GameObject LocationsObj;
    public GameObject LocationPathsObj;
    public GameObject MissionsObj;

    public int[] counters = new int[6];
    public int[] travelled = new int[6];

    private ReadLocationPaths locationPathsScript;
    private ReadLocations locationsScript;

    public int[] trophyOne = new int[6];
    public int[] trophyTwo = new int[6];
    public int[] trophyThree = new int[6];
    public int[] trophyFour = new int[6];

    public Text trophyOneTxt;
    public Text trophyTwoTxt;
    public Text trophyThreeTxt;
    public Text trophyFourTxt;


    public int p1VPs = 0;
    public int p2VPs = 0;
    public int p3VPs = 0;
    public int p4VPs = 0;
    public int p5VPs = 0;
    public int p6VPs = 0;
    static public int playerTurn = 1;
    static public int maxPlayers;
    public int[] pLocation = new int[6];
    public int[] hubLocation = new int[6];


    public int[] pHealth = new int[6];
    public static int maxHealth = 100;

    //Player GameObjects to set true and false

    public GameObject[] playerSkills;

    public GameObject[] playerTickets;

    public GameObject[] playerBGs;

    public GameObject completeMissionBtn;

    //public GameObject movesLeftTag;
    public Text movesLeft;
    public bool startOfTurn;

    public Text ItemTxt;
    public Text ObjItemTxt;
    public Text AmountTxt;
    public Text ObjAmountTxt;
    public Text TypeTxt;
    public Text TurnTxt;
    public Text turnOrderTxt;

    public string[] playersItemTxt = new string[6];
    public string[] playersObjItemTxt = new string[6];
    public string[] playersAmountTxt = new string[6];
    public string[] playersObjAmountTxt = new string[6];
    public string[] playersTypeTxt = new string[6];

    //Player 1 Stats
    public TMP_Text[] skillTextsp1 = new TMP_Text[8];
    public int[] player1Values = new int[8];
    public TMP_Text[] ticketTextsp1 = new TMP_Text[4];
    public int[] player1Tickets = new int[4];

    //Player2 Stats
    public TMP_Text[] skillTextsp2 = new TMP_Text[8];
    public int[] player2Values = new int[8];
    public TMP_Text[] ticketTextsp2 = new TMP_Text[4];
    public int[] player2Tickets = new int[4];

    //Player3 Stats
    public TMP_Text[] skillTextsp3 = new TMP_Text[8];
    public int[] player3Values = new int[8];
    public TMP_Text[] ticketTextsp3 = new TMP_Text[4];
    public int[] player3Tickets = new int[4];

    //Player4 Stats
    public TMP_Text[] skillTextsp4 = new TMP_Text[8];
    public int[] player4Values = new int[8];
    public TMP_Text[] ticketTextsp4 = new TMP_Text[4];
    public int[] player4Tickets = new int[4];

    //Player5 Stats
    public TMP_Text[] skillTextsp5 = new TMP_Text[8];
    public int[] player5Values = new int[8];
    public TMP_Text[] ticketTextsp5 = new TMP_Text[4];
    public int[] player5Tickets = new int[4];

    //Player6 Stats
    public TMP_Text[] skillTextsp6 = new TMP_Text[8];
    public int[] player6Values = new int[8];
    public TMP_Text[] ticketTextsp6 = new TMP_Text[4];
    public int[] player6Tickets = new int[4];

    //Moves left
    static public int playerMoves = 4;

    public string[] playerObjects = new string[6];

    public string p1CurrentObject;
    public string p2CurrentObject;
    public string p3CurrentObject;
    public string p4CurrentObject;
    public string p5CurrentObject;
    public string p6CurrentObject;

    public GameObject Hub1;
    public GameObject Hub2;
    public GameObject Hub3;

    //false = Player 1 Turn | true = Player 2 Turn
    //static public bool turn = false;

    void UpdateUIStats()
    {
        movesLeft.text = (playerMoves - 1).ToString() ;
    }

    void Awake()
    {
        locationsScript = LocationsObj.GetComponent<ReadLocations>();
        locationPathsScript = LocationPathsObj.GetComponent<ReadLocationPaths>();
    }

    void Start()
    {

        // p1CurrentObject = "NONE";
        // p2CurrentObject = "NONE";
        // p3CurrentObject = "NONE";
        // p4CurrentObject = "NONE";
        // p5CurrentObject = "NONE";
        // p6CurrentObject = "NONE";

        for (int i = 0; i < 8; i++)
        {
            skillTextsp1[i].text = 0.ToString();
            skillTextsp2[i].text = 0.ToString();
            skillTextsp3[i].text = 0.ToString();
            skillTextsp4[i].text = 0.ToString();
            skillTextsp5[i].text = 0.ToString();
            skillTextsp6[i].text = 0.ToString();
            //player1Values[i] = 0;
            //player2Values[i] = 0;

        }

        for (int i = 0; i < 6; i++)
        {
            playersItemTxt[i] = "";
            playersTypeTxt[i] = "";
            playersTypeTxt[i] = "";


            trophyOneTxt.text = 0.ToString();
            trophyTwoTxt.text = 0.ToString();
            trophyThreeTxt.text = 0.ToString();
            trophyFourTxt.text = 0.ToString();
        }

        for (int i = 0; i < 4; i++)
        {
            ticketTextsp1[i].text = 0.ToString();
            ticketTextsp2[i].text = 0.ToString();
            ticketTextsp3[i].text = 0.ToString();
            ticketTextsp4[i].text = 0.ToString();
            ticketTextsp5[i].text = 0.ToString();
            ticketTextsp6[i].text = 0.ToString();
        }

        if (pHealth == null)
        {
            for (int i = 0; i < 6; i++)
            {
                pHealth[i] = maxHealth;
            }
        }
        else
        {
            pHealth = GlobalController.Instance.pHealth;
        }

        if (rounds == null)
        {
            rounds = 1;
        }


        CheckPlayerTurn();



        //Game size
        if (PlayerPrefs.GetInt("players") == 2)
        {
            maxPlayers = 2;
        }

        if (PlayerPrefs.GetInt("players") == 3)
        {
            maxPlayers = 3;
        }

        if (PlayerPrefs.GetInt("players") == 4)
        {
            maxPlayers = 4;
        }

        if (PlayerPrefs.GetInt("players") == 5)
        {
            maxPlayers = 5;
        }

        if (PlayerPrefs.GetInt("players") == 6)
        {
            maxPlayers = 6;
        }




        for (int i = 0; i < 6; i++)
        {
            playerObjects[i] = "NONE";
        }

        missions = GlobalController.Instance.missions;
        if (missions == null)
        {
            missions = generateMissions();
            GlobalController.Instance.missions = missions;
        }


        if (turnOrder.Count == 0 && turnOrder.Count == null)
        {
            for (int i = 1; i < maxPlayers; i++)
            {
                turnOrder.Add(i + 1);
            }
            playerTurn = turnOrder[0];
            turnOrder.RemoveAt(0);
        }
        else
        {
            turnOrder = GlobalController.Instance.turnOrder;
        }



        //for (int i = 0; i < missions.Length; i++)
        //{
        //  //Outputting missions
        //  //Debug.Log("mission: " + (i+1) + " at " + missions[i].hubNum + ", " + missions[i].locationNum);
        //}

        enemies = GlobalController.Instance.enemies;
        trophyOne = GlobalController.Instance.trophyOne;
        trophyTwo = GlobalController.Instance.trophyTwo;
        trophyThree = GlobalController.Instance.trophyThree;
        trophyFour = GlobalController.Instance.trophyFour;

        confrontEnemies();

        GlobalController.Instance.enemies = enemies;
        GlobalController.Instance.trophyOne = trophyOne;
        GlobalController.Instance.trophyTwo = trophyTwo;
        GlobalController.Instance.trophyThree = trophyThree;
        GlobalController.Instance.trophyFour = trophyFour;

        //GlobalController.Instance.travelled = travelled;


        for (int i = 0; i < 6; i++)
        {
            travelled[i] = 0;
        }

    }

    private void Update()
    {
        for (int i = 0; i < 8; i++)
        {
            skillTextsp1[i].text = player1Values[i].ToString();
            skillTextsp2[i].text = player2Values[i].ToString();
            skillTextsp3[i].text = player3Values[i].ToString();
            skillTextsp4[i].text = player4Values[i].ToString();
            skillTextsp5[i].text = player5Values[i].ToString();
            skillTextsp6[i].text = player6Values[i].ToString();
        }

        for (int i = 0; i < 4; i++)
        {
            ticketTextsp1[i].text = player1Tickets[i].ToString();
            ticketTextsp2[i].text = player2Tickets[i].ToString();
            ticketTextsp3[i].text = player3Tickets[i].ToString();
            ticketTextsp4[i].text = player4Tickets[i].ToString();
            ticketTextsp5[i].text = player5Tickets[i].ToString();
            ticketTextsp6[i].text = player6Tickets[i].ToString();
        }

        trophyOne = GlobalController.Instance.trophyOne;
        trophyTwo = GlobalController.Instance.trophyTwo;
        trophyThree = GlobalController.Instance.trophyThree;
        trophyFour = GlobalController.Instance.trophyFour;

        trophyOneTxt.text = trophyOne[playerTurn - 1].ToString();
        trophyTwoTxt.text = trophyTwo[playerTurn - 1].ToString();
        trophyThreeTxt.text = trophyThree[playerTurn - 1].ToString();
        trophyFourTxt.text = trophyFour[playerTurn - 1].ToString();

        ObjItemTxt.text = playersObjItemTxt[playerTurn - 1];
        ObjAmountTxt.text = playersObjAmountTxt[playerTurn - 1];
        TypeTxt.text = playersTypeTxt[playerTurn - 1];


        CheckPlayerTurn();


        if (trophyOne[0] >= 3 && trophyTwo[0] >= 3 && trophyThree[0] >= 3 && trophyFour[0] >= 3)
        {
            PlayerOneWin();
        }

        if (trophyOne[1] >= 3 && trophyTwo[1] >= 3 && trophyThree[1] >= 3 && trophyFour[1] >= 3)
        {
            PlayerOneWin();
        }

        if (trophyOne[2] >= 3 && trophyTwo[2] >= 3 && trophyThree[2] >= 3 && trophyFour[2] >= 3)
        {
            PlayerOneWin();
        }

        if (trophyOne[3] >= 3 && trophyTwo[3] >= 3 && trophyThree[3] >= 3 && trophyFour[3] >= 3)
        {
            PlayerOneWin();
        }

        if (trophyOne[4] >= 3 && trophyTwo[4] >= 3 && trophyThree[4] >= 3 && trophyFour[4] >= 3)
        {
            PlayerOneWin();
        }

        if (trophyOne[5] >= 3 && trophyTwo[5] >= 3 && trophyThree[5] >= 3 && trophyFour[5] >= 3)
        {
            PlayerOneWin();
        }

        turnOrder = GlobalController.Instance.turnOrder;
        enemies = GlobalController.Instance.enemies;
        turnOrderTxt = GlobalController.Instance.turnOrderTxt;
        //playerTurn = GlobalController.Instance.playerTurn;
        //Player 1 info to load
        player1Values = GlobalController.Instance.player1Values;
        player1Tickets = GlobalController.Instance.player1Tickets;

        //Player 2 info to load
        player2Values = GlobalController.Instance.player2Values;
        player2Tickets = GlobalController.Instance.player2Tickets;

        //Player 3 info to load
        player3Values = GlobalController.Instance.player3Values;
        player3Tickets = GlobalController.Instance.player3Tickets;

        //Player 4 info to load
        player4Values = GlobalController.Instance.player4Values;
        player4Tickets = GlobalController.Instance.player4Tickets;

        //Player 5 info to load
        player5Values = GlobalController.Instance.player5Values;
        player5Tickets = GlobalController.Instance.player5Tickets;

        //Player 6 info to load
        player6Values = GlobalController.Instance.player6Values;
        player6Tickets = GlobalController.Instance.player6Tickets;

        pLocation = GlobalController.Instance.pLocation;
        hubLocation = GlobalController.Instance.hubLocation;
        counters = GlobalController.Instance.counters;


        missions = GlobalController.Instance.missions;
        travelled = GlobalController.Instance.travelled;

        playersObjItemTxt = GlobalController.Instance.playersObjItemTxt;
        playersTypeTxt = GlobalController.Instance.playersTypeTxt;
        playersObjAmountTxt = GlobalController.Instance.playersObjAmountTxt;

        trophyOne = GlobalController.Instance.trophyOne;
        trophyTwo = GlobalController.Instance.trophyTwo;
        trophyThree = GlobalController.Instance.trophyThree;
        trophyFour = GlobalController.Instance.trophyFour;

        playerObjects = GlobalController.Instance.playerObjects;

        startOfTurn = GlobalController.Instance.startOfTurn;

        pHealth = GlobalController.Instance.pHealth;

        //Game status stuff

        if (PlayerPrefs.GetInt("players") == 2)
        {
            p1Popup.text = "Player One has " + trophyOne[0].ToString() + " Enemy Points, " + trophyTwo[0].ToString() + " London Points, " + trophyThree[0].ToString() + " Paris Points, " + " and " + trophyFour[0].ToString() + " Stockholm Points";
            p2Popup.text = "Player Two has " + trophyOne[1].ToString() + " Enemy Points, " + trophyTwo[1].ToString() + " London Points, " + trophyThree[1].ToString() + " Paris Points, " + " and " + trophyFour[1].ToString() + " Stockholm Points";
        }

        if (PlayerPrefs.GetInt("players") == 3)
        {
            p1Popup.text = "Player One has " + trophyOne[0].ToString() + " Enemy Points, " + trophyTwo[0].ToString() + " London Points, " + trophyThree[0].ToString() + " Paris Points," + " and " + trophyFour[0].ToString() + " Stockholm Points";
            p2Popup.text = "Player Two has " + trophyOne[1].ToString() + " Enemy Points, " + trophyTwo[1].ToString() + " London Points, " + trophyThree[1].ToString() + " Paris Points, " + " and " + trophyFour[1].ToString() + " Stockholm Points";
            p3Popup.text = "Player Three has " + trophyOne[2].ToString() + " Enemy Points, " + trophyTwo[2].ToString() + " London Points, " + trophyThree[2].ToString() + " Paris Points, " + " and " + trophyFour[2].ToString() + " Stockholm Points";
        }

        if (PlayerPrefs.GetInt("players") == 4)
        {
            p1Popup.text = "Player One has " + trophyOne[0].ToString() + " Enemy Points, " + trophyTwo[0].ToString() + " London Points, " + trophyThree[0].ToString() + " Paris Points, " + " and " + trophyFour[0].ToString() + " Stockholm Points";
            p2Popup.text = "Player Two has " + trophyOne[1].ToString() + " Enemy Points, " + trophyTwo[1].ToString() + " London Points, " + trophyThree[1].ToString() + " Paris Points, " + " and " + trophyFour[1].ToString() + " Stockholm Points";
            p3Popup.text = "Player Three has " + trophyOne[2].ToString() + " Enemy Points, " + trophyTwo[2].ToString() + " London Points, " + trophyThree[2].ToString() + " Paris Points, " + " and " + trophyFour[2].ToString() + " Stockholm Points";
            p4Popup.text = "Player Four has " + trophyOne[3].ToString() + " Enemy Points, " + trophyTwo[3].ToString() + " London Points, " + trophyThree[3].ToString() + " Paris Points, " + " and " + trophyFour[3].ToString() + " Stockholm Points ";
        }

        if (PlayerPrefs.GetInt("players") == 5)
        {
            p1Popup.text = "Player One has " + trophyOne[0].ToString() + " Enemy Points, " + trophyTwo[0].ToString() + " London Points, " + trophyThree[0].ToString() + " Paris Points, " + " and " + trophyFour[0].ToString() + " Stockholm Points";
            p2Popup.text = "Player Two has " + trophyOne[1].ToString() + " Enemy Points, " + trophyTwo[1].ToString() + " London Points, " + trophyThree[1].ToString() + " Paris Points, " + " and " + trophyFour[1].ToString() + " Stockholm Points";
            p3Popup.text = "Player Three has " + trophyOne[2].ToString() + " Enemy Points, " + trophyTwo[2].ToString() + " London Points, " + trophyThree[2].ToString() + " Paris Points, " + " and " + trophyFour[2].ToString() + " Stockholm Points";
            p4Popup.text = "Player Four has " + trophyOne[3].ToString() + " Enemy Points, " + trophyTwo[3].ToString() + " London Points, " + trophyThree[3].ToString() + " Paris Points, " + " and " + trophyFour[3].ToString() + " Stockholm Points";
            p5Popup.text = "Player Five has " + trophyOne[4].ToString() + " Enemy Points, " + trophyTwo[4].ToString() + " London Points, " + trophyThree[4].ToString() + " Paris Points, " + " and " + trophyFour[4].ToString() + " Stockholm Points";
        }

        if (PlayerPrefs.GetInt("players") == 6)
        {
            p1Popup.text = "Player One has " + trophyOne[0].ToString() + " Enemy Points, " + trophyTwo[0].ToString() + " London Points, " + trophyThree[0].ToString() + " Paris Points, " + " and " + trophyFour[0].ToString() + " Stockholm Points ";
            p2Popup.text = "Player Two has " + trophyOne[1].ToString() + " Enemy Points, " + trophyTwo[1].ToString() + " London Points, " + trophyThree[1].ToString() + " Paris Points, " + " and " + trophyFour[1].ToString() + " Stockholm Points";
            p3Popup.text = "Player Three has " + trophyOne[2].ToString() + " Enemy Points, " + trophyTwo[2].ToString() + " London Points, " + trophyThree[2].ToString() + " Paris Points, " + " and " + trophyFour[2].ToString() + " Stockholm Points";
            p4Popup.text = "Player Four has " + trophyOne[3].ToString() + " Enemy Points, " + trophyTwo[3].ToString() + " London Points, " + trophyThree[3].ToString() + " Paris Points, " + " and " + trophyFour[3].ToString() + " Stockholm Points";
            p5Popup.text = "Player Five has " + trophyOne[4].ToString() + " Enemy Points, " + trophyTwo[4].ToString() + " London Points, " + trophyThree[4].ToString() + " Paris Points, " + " and " + trophyFour[4].ToString() + " Stockholm Points";
            p6Popup.text = "Player Six has " + trophyOne[5].ToString() + " Enemy Points, " + trophyTwo[5].ToString() + " London Points, " + trophyThree[5].ToString() + " Paris Points, " + " and " + trophyFour[5].ToString() + " Stockholm Points";
        }

        if (travelled[playerTurn - 1] == 1)
        {
            playerMoves = 0;
            travelled[playerTurn - 1] = 0;
        }

    }



    void playerGmo()
    {

        StartCoroutine(PlayerGraphics());
        //StartCoroutine(TurnDelayCoroutine());
        //PlayerGraphics();
    }

    public void CheckPlayerTurn()
    {

        if (playerMoves == 0) // end of turn
        {
            GlobalController.Instance.startOfTurn = true;

            if (playerTurn == maxPlayers)
            {
                rounds = GlobalController.Instance.rounds;
                rounds++;
                GlobalController.Instance.rounds = rounds;

                playerTurn = 1;
                //travelled[playerTurn - 1] = 0;

                if (rounds % 2 == 0)
                {
                    moveEnemies(enemies);
                    spawnEnemies(locationsScript.hostileLocations);
                }

                Debug.Log("missions count: " + missions.Length);

                // for(int i = 0; i < missions.Length; i++)
                // {
                //   if (missions[i].cooldown != 0)
                //   {
                //     missions[i].cooldown--;
                //   }
                // }

                reduceMissions(GlobalController.Instance.missions);
                AmountTxt.text = "";
                ItemTxt.text = "";
                TypeTxt.text = "";
                completeMissionBtn.SetActive(false);

                playerMoves = 4;
                //StartCoroutine(ExampleCoroutine());
                //SceneManager.LoadScene("Map3Dworld");
            }
            else
            {
                playerTurn++;
                //travelled[playerTurn - 1] = 0;

                Debug.Log("missions count: " + missions.Length);
                reduceMissions(GlobalController.Instance.missions);
                AmountTxt.text = "";
                ItemTxt.text = "";
                TypeTxt.text = "";
                completeMissionBtn.SetActive(false);

                playerMoves = 4;
                //StartCoroutine(ExampleCoroutine());
                //SceneManager.LoadScene("Map3Dworld");
            }
        }

        if (playerMoves == 1)
        {
            TurnTxt.text = "  ";
            EndTurnBtn.gameObject.SetActive(true);
            TicketsBtn.gameObject.SetActive(false);
            AquireTicketsBtn.gameObject.SetActive(false);
            ObjectsBtn.gameObject.SetActive(false);
            SkillsBtn.gameObject.SetActive(false);
            MissionBtn.gameObject.SetActive(false);

        }

        playerGmo();
        UpdateUIStats();

    }

    public void EndTurnBtnClicked()
    {
        playerMoves--;
    }

    void PlayerOneWin()
    {
        SceneManager.LoadScene("PlayerOneWin");
    }

    void PlayerTwoWin()
    {
        SceneManager.LoadScene("PlayerTwoWins");
    }

    public void SkillsClicked()
    {
        CheckPlayerTurn();

        switch (playerTurn)
        {
            case 1:
                int skillToLevel = Random.Range(0, 8);
                int experienceGained = ML_Algo.ML() + 2;
                //Actions.reduceActions();
                player1Values[skillToLevel] += experienceGained;
                skillTextsp1[skillToLevel].text = player1Values[skillToLevel].ToString();

                break;
            case 2:
                skillToLevel = Random.Range(0, 8);
                experienceGained = ML_Algo.ML();
                //Actions.reduceActions();

                player2Values[skillToLevel] += experienceGained;
                skillTextsp2[skillToLevel].text = player1Values[skillToLevel].ToString();

                break;
            case 3:
                skillToLevel = Random.Range(0, 8);
                experienceGained = ML_Algo.ML() + 2;
                //Actions.reduceActions();
                player3Values[skillToLevel] += experienceGained;
                skillTextsp3[skillToLevel].text = player3Values[skillToLevel].ToString();

                break;
            case 4:
                skillToLevel = Random.Range(0, 8);
                experienceGained = ML_Algo.ML() + 2;
                //Actions.reduceActions();
                player4Values[skillToLevel] += experienceGained;
                skillTextsp4[skillToLevel].text = player4Values[skillToLevel].ToString();

                break;
            case 5:
                skillToLevel = Random.Range(0, 8);
                experienceGained = ML_Algo.ML() + 2;
                //Actions.reduceActions();
                player5Values[skillToLevel] += experienceGained;
                skillTextsp5[skillToLevel].text = player5Values[skillToLevel].ToString();

                break;
            case 6:
                skillToLevel = Random.Range(0, 8);
                experienceGained = ML_Algo.ML() + 2;
                //Actions.reduceActions();
                player6Values[skillToLevel] += experienceGained;
                skillTextsp6[skillToLevel].text = player6Values[skillToLevel].ToString();

                break;
            default:
                break;
        }

        log.Add("Player " + playerTurn.ToString() + " leveled a skill.");
        TurnTxt.text = "Player " + playerTurn.ToString() + " leveled a skill.";

        playerMoves--;

    }

    public void TicketClicked()
    {
        CheckPlayerTurn();

        switch (playerTurn)
        {
            case 1:
                //TICKETS
                int ticketGained = 0;
                while (ticketGained == 0)
                {
                    ticketGained = ML_Algo.ML();
                }

                if (ticketGained == 1)
                {
                    player1Tickets[3]++;
                    ticketTextsp1[3].text = player1Tickets[3].ToString();

                }
                else if (ticketGained == 2)
                {
                    player1Tickets[2]++;
                    ticketTextsp1[2].text = player1Tickets[2].ToString();

                }
                else if (ticketGained == 3)
                {
                    player1Tickets[0]++;
                    ticketTextsp1[0].text = player1Tickets[0].ToString();

                }
                else
                {
                    player1Tickets[1]++;
                    ticketTextsp1[1].text = player1Tickets[1].ToString();

                }

                Actions.reduceActions();
                break;
            case 2:
                //TICKETS
                ticketGained = 0;
                while (ticketGained == 0)
                {
                    ticketGained = ML_Algo.ML();
                }

                if (ticketGained == 1)
                {
                    player2Tickets[3]++;
                    ticketTextsp2[3].text = player2Tickets[3].ToString();

                }
                else if (ticketGained == 2)
                {
                    player2Tickets[2]++;
                    ticketTextsp2[2].text = player2Tickets[2].ToString();


                }
                else if (ticketGained == 3)
                {
                    player2Tickets[0]++;
                    ticketTextsp2[0].text = player2Tickets[0].ToString();


                }
                else
                {
                    player2Tickets[1]++;
                    ticketTextsp2[1].text = player2Tickets[1].ToString();

                }

                Actions.reduceActions();
                break;
            case 3:
                //TICKETS
                ticketGained = 0;
                while (ticketGained == 0)
                {
                    ticketGained = ML_Algo.ML();
                }

                if (ticketGained == 1)
                {
                    player3Tickets[3]++;
                    ticketTextsp3[3].text = player3Tickets[3].ToString();

                }
                else if (ticketGained == 2)
                {
                    player3Tickets[2]++;
                    ticketTextsp3[2].text = player3Tickets[2].ToString();

                }
                else if (ticketGained == 3)
                {
                    player3Tickets[0]++;
                    ticketTextsp3[0].text = player3Tickets[0].ToString();

                }
                else
                {
                    player3Tickets[1]++;
                    ticketTextsp3[1].text = player3Tickets[1].ToString();

                }

                Actions.reduceActions();
                break;
            case 4:
                //TICKETS
                ticketGained = 0;
                while (ticketGained == 0)
                {
                    ticketGained = ML_Algo.ML();
                }

                if (ticketGained == 1)
                {
                    player4Tickets[3]++;
                    ticketTextsp4[3].text = player4Tickets[3].ToString();

                }
                else if (ticketGained == 2)
                {
                    player4Tickets[2]++;
                    ticketTextsp4[2].text = player4Tickets[2].ToString();

                }
                else if (ticketGained == 3)
                {
                    player4Tickets[0]++;
                    ticketTextsp4[0].text = player4Tickets[0].ToString();

                }
                else
                {
                    player4Tickets[1]++;
                    ticketTextsp4[1].text = player4Tickets[1].ToString();

                }

                Actions.reduceActions();
                break;
            case 5:
                //TICKETS
                ticketGained = 0;
                while (ticketGained == 0)
                {
                    ticketGained = ML_Algo.ML();
                }

                if (ticketGained == 1)
                {
                    player5Tickets[3]++;
                    ticketTextsp5[3].text = player5Tickets[3].ToString();

                }
                else if (ticketGained == 2)
                {
                    player5Tickets[2]++;
                    ticketTextsp5[2].text = player5Tickets[2].ToString();

                }
                else if (ticketGained == 3)
                {
                    player5Tickets[0]++;
                    ticketTextsp5[0].text = player5Tickets[0].ToString();

                }
                else
                {
                    player5Tickets[1]++;
                    ticketTextsp5[1].text = player5Tickets[1].ToString();

                }

                Actions.reduceActions();
                break;
            case 6:
                //TICKETS
                ticketGained = 0;
                while (ticketGained == 0)
                {
                    ticketGained = ML_Algo.ML();
                }

                if (ticketGained == 1)
                {
                    player6Tickets[3]++;
                    ticketTextsp6[3].text = player6Tickets[3].ToString();

                }
                else if (ticketGained == 2)
                {
                    player6Tickets[2]++;
                    ticketTextsp6[2].text = player6Tickets[2].ToString();

                }
                else if (ticketGained == 3)
                {
                    player6Tickets[0]++;
                    ticketTextsp6[0].text = player6Tickets[0].ToString();

                }
                else
                {
                    player6Tickets[1]++;
                    ticketTextsp6[1].text = player6Tickets[1].ToString();

                }

                Actions.reduceActions();
                break;
                log.Add("Player " + playerTurn.ToString() + " gained a ticket.");

        }
        log.Add("Player " + playerTurn.ToString() + " gained a ticket.");
        TurnTxt.text = "Player " + playerTurn.ToString() + " gained a ticket.";

        playerMoves--;
    }

    public void ObjectClicked()
    {

        CheckPlayerTurn();

        int[] newObjectInfo = new int[2];
        int[] oldObjectInfo = new int[2];
        string oldObject;
        string newObject;

        switch (playerTurn)
        {
            case 1:

                oldObjectInfo = getObjectStats(playerObjects[playerTurn - 1]);
                oldObject = playerObjects[playerTurn - 1];
                newObject = playerObjects[playerTurn - 1];
                while (oldObject == newObject)
                {
                    newObject = getObject();
                }
                playerObjects[playerTurn - 1] = newObject;
                newObjectInfo = getObjectStats(playerObjects[playerTurn - 1]);

                player1Values[oldObjectInfo[0]] -= oldObjectInfo[1];
                skillTextsp1[oldObjectInfo[0]].text = player1Values[newObjectInfo[0]].ToString();

                player1Values[newObjectInfo[0]] += newObjectInfo[1];
                skillTextsp1[newObjectInfo[0]].text = player1Values[newObjectInfo[0]].ToString();

                break;

            case 2:
                oldObjectInfo = getObjectStats(playerObjects[playerTurn - 1]);
                oldObject = playerObjects[playerTurn - 1];
                newObject = playerObjects[playerTurn - 1];
                while (oldObject == newObject)
                {
                    newObject = getObject();
                }
                playerObjects[playerTurn - 1] = newObject;
                newObjectInfo = getObjectStats(playerObjects[playerTurn - 1]);

                player2Values[oldObjectInfo[0]] -= oldObjectInfo[1];
                skillTextsp2[oldObjectInfo[0]].text = player2Values[newObjectInfo[0]].ToString();

                player2Values[newObjectInfo[0]] += newObjectInfo[1];
                skillTextsp2[newObjectInfo[0]].text = player2Values[newObjectInfo[0]].ToString();

                break;
            case 3:
                oldObjectInfo = getObjectStats(playerObjects[playerTurn - 1]);
                oldObject = playerObjects[playerTurn - 1];
                newObject = playerObjects[playerTurn - 1];
                while (oldObject == newObject)
                {
                    newObject = getObject();
                }
                playerObjects[playerTurn - 1] = newObject;
                newObjectInfo = getObjectStats(playerObjects[playerTurn - 1]);

                player3Values[oldObjectInfo[0]] -= oldObjectInfo[1];
                skillTextsp3[oldObjectInfo[0]].text = player3Values[newObjectInfo[0]].ToString();

                player3Values[newObjectInfo[0]] += newObjectInfo[1];
                skillTextsp3[newObjectInfo[0]].text = player3Values[newObjectInfo[0]].ToString();

                break;
            case 4:
                oldObjectInfo = getObjectStats(playerObjects[playerTurn - 1]);
                oldObject = playerObjects[playerTurn - 1];
                newObject = playerObjects[playerTurn - 1];
                while (oldObject == newObject)
                {
                    newObject = getObject();
                }
                playerObjects[playerTurn - 1] = newObject;
                newObjectInfo = getObjectStats(playerObjects[playerTurn - 1]);

                player4Values[oldObjectInfo[0]] -= oldObjectInfo[1];
                skillTextsp4[oldObjectInfo[0]].text = player4Values[newObjectInfo[0]].ToString();

                player4Values[newObjectInfo[0]] += newObjectInfo[1];
                skillTextsp4[newObjectInfo[0]].text = player4Values[newObjectInfo[0]].ToString();
                break;
            case 5:
                oldObjectInfo = getObjectStats(playerObjects[playerTurn - 1]);
                oldObject = playerObjects[playerTurn - 1];
                newObject = playerObjects[playerTurn - 1];
                while (oldObject == newObject)
                {
                    newObject = getObject();
                }
                playerObjects[playerTurn - 1] = newObject;
                newObjectInfo = getObjectStats(playerObjects[playerTurn - 1]);

                player5Values[oldObjectInfo[0]] -= oldObjectInfo[1];
                skillTextsp5[oldObjectInfo[0]].text = player5Values[newObjectInfo[0]].ToString();

                player5Values[newObjectInfo[0]] += newObjectInfo[1];
                skillTextsp5[newObjectInfo[0]].text = player5Values[newObjectInfo[0]].ToString();
                break;
            case 6:
                oldObjectInfo = getObjectStats(playerObjects[playerTurn - 1]);
                oldObject = playerObjects[playerTurn - 1];
                newObject = playerObjects[playerTurn - 1];
                while (oldObject == newObject)
                {
                    newObject = getObject();
                }
                playerObjects[playerTurn - 1] = newObject;
                newObjectInfo = getObjectStats(playerObjects[playerTurn - 1]);

                player6Values[oldObjectInfo[0]] -= oldObjectInfo[1];
                skillTextsp6[oldObjectInfo[0]].text = player6Values[newObjectInfo[0]].ToString();

                player6Values[newObjectInfo[0]] += newObjectInfo[1];
                skillTextsp6[newObjectInfo[0]].text = player6Values[newObjectInfo[0]].ToString();
                break;

            default:
                break;
        }

        playerMoves--;
        log.Add("Player " + playerTurn.ToString() + " acquired an object.");
        TurnTxt.text = "Player " + playerTurn.ToString() + " acquired an object.";

    }

    public void MissionsClicked()
    {
        completeMissionBtn.gameObject.SetActive(true);

        for (int i = 0; i < 9; i++)
        {
            Debug.Log(missions[i].hubNum + ", " + missions[i].locationNum + ", " + missions[i].trophyType + ", " + missions[i].victoryPoints);


            if (hubLocation[playerTurn - 1] == missions[i].hubNum)
            {
                if (pLocation[playerTurn - 1] == missions[i].locationNum)
                {
                    if (missions[i].completedBy[playerTurn - 1] == false && missions[i].cooldown == 0)
                    {
                        ItemTxt.text = skillNames[missions[i].skillNum];
                        AmountTxt.text = missions[i].pointsReq.ToString();
                        currentMissionIndex = i;
                        i = 10;
                        playerMoves--;
                        completeMissionBtn.gameObject.SetActive(true);
                    }

                    else if (missions[i].completedBy[playerTurn - 1])
                    {
                        ItemTxt.text = "Already completed this mission.";
                        AmountTxt.text = "";
                        i = 10;
                    }

                    else if (missions[i].cooldown != 0)
                    {
                        ItemTxt.text = "Mission on cooldown from another player.";
                        i = 10;
                    }
                    //
                }
            }

            if (i != 10)
            {
                completeMissionBtn.gameObject.SetActive(false);
                ItemTxt.text = "No mission found here.";
            }


        }

        log.Add("Player " + playerTurn.ToString() + " clicked mission button.");
        TurnTxt.text = "Player " + playerTurn.ToString() + " clicked mission button.";

    }

    public void reduceMissions(Mission[] missions)
    {
        for (int i = 0; i < missions.Length - 3; i++)
        {
            if (missions[i].cooldown != 0)
            {
                Debug.Log("ACCESSING " + i);
                missions[i].cooldown--;
            }
        }

        //int x = 0;
        //missions[x].cooldown--;
        //missions[0].cooldown--;
    }

    public void CompleteMissions()
    {

        switch (playerTurn)
        {
            case 1:
                Debug.Log("player has: " + player1Values[missions[currentMissionIndex].skillNum] + " points. Skillnum: " + missions[currentMissionIndex].skillNum);
                if (player1Values[missions[currentMissionIndex].skillNum] >= missions[currentMissionIndex].pointsReq)
                {
                    if (missions[currentMissionIndex].trophyType == 1)
                    {
                        trophyTwo[playerTurn - 1] += missions[currentMissionIndex].victoryPoints;

                    }
                    else if (missions[currentMissionIndex].trophyType == 2)
                    {
                        trophyThree[playerTurn - 1] += missions[currentMissionIndex].victoryPoints;

                    }
                    else
                    {
                        trophyFour[playerTurn - 1] += missions[currentMissionIndex].victoryPoints;
                    }
                    ItemTxt.text = "Completed mission! Awarded + " + missions[currentMissionIndex].victoryPoints + " victory points!";
                    AmountTxt.text = "";
                    TypeTxt.text = "";
                    missions[currentMissionIndex].completedBy[0] = true;
                    missions[currentMissionIndex].cooldown = 3;
                    completeMissionBtn.gameObject.SetActive(false);
                    playerMoves--;
                } else
                {
                    infoPopup.gameObject.SetActive(true);
                    Popupinfo.text = "You do not have enough skill points for this mission";
                }
                break;

            case 2:
                if (player2Values[missions[currentMissionIndex].skillNum] >= missions[currentMissionIndex].pointsReq)
                {
                    if (missions[currentMissionIndex].trophyType == 1)
                    {
                        trophyTwo[playerTurn - 1] += missions[currentMissionIndex].victoryPoints;

                    }
                    else if (missions[currentMissionIndex].trophyType == 2)
                    {
                        trophyThree[playerTurn - 1] += missions[currentMissionIndex].victoryPoints;

                    }
                    else
                    {
                        trophyFour[playerTurn - 1] += missions[currentMissionIndex].victoryPoints;
                    }

                    ItemTxt.text = "Completed mission! Awarded " + missions[currentMissionIndex].victoryPoints + " VPs!";
                    AmountTxt.text = "";
                    TypeTxt.text = "";
                    missions[currentMissionIndex].completedBy[1] = true;
                    missions[currentMissionIndex].cooldown = 3;
                    completeMissionBtn.gameObject.SetActive(false);
                    playerMoves--;
                }
                else
                {
                    infoPopup.gameObject.SetActive(true);
                    Popupinfo.text = "You do not have enough skill points for this mission";
                }


                break;

            case 3:
                if (player3Values[missions[currentMissionIndex].skillNum] >= missions[currentMissionIndex].pointsReq)
                {
                    if (missions[currentMissionIndex].trophyType == 1)
                    {
                        trophyTwo[playerTurn - 1] += missions[currentMissionIndex].victoryPoints;

                    }
                    else if (missions[currentMissionIndex].trophyType == 2)
                    {
                        trophyThree[playerTurn - 1] += missions[currentMissionIndex].victoryPoints;

                    }
                    else
                    {
                        trophyFour[playerTurn - 1] += missions[currentMissionIndex].victoryPoints;
                    }

                    ItemTxt.text = "Completed mission! Awarded + " + missions[currentMissionIndex].victoryPoints + " victory points!";
                    AmountTxt.text = "";
                    TypeTxt.text = "";
                    missions[currentMissionIndex].completedBy[2] = true;
                    missions[currentMissionIndex].cooldown = 3;
                    completeMissionBtn.gameObject.SetActive(false);
                    playerMoves--;
                }
                else
                {
                    infoPopup.gameObject.SetActive(true);
                    Popupinfo.text = "You do not have enough skill points for this mission";
                }
                break;

            case 4:
                if (player4Values[missions[currentMissionIndex].skillNum] >= missions[currentMissionIndex].pointsReq)
                {
                    if (missions[currentMissionIndex].trophyType == 1)
                    {
                        trophyTwo[playerTurn - 1] = missions[currentMissionIndex].victoryPoints;
                    }
                    else if (missions[currentMissionIndex].trophyType == 2)
                    {
                        trophyThree[playerTurn - 1] = missions[currentMissionIndex].victoryPoints;
                    }
                    else
                    {
                        trophyFour[playerTurn - 1] = missions[currentMissionIndex].victoryPoints;
                    }

                    ItemTxt.text = "Completed mission! Awarded + " + missions[currentMissionIndex].victoryPoints + " victory points!";
                    AmountTxt.text = "";
                    TypeTxt.text = "";
                    missions[currentMissionIndex].completedBy[3] = true;
                    missions[currentMissionIndex].cooldown = 3;
                    completeMissionBtn.gameObject.SetActive(false);
                    playerMoves--;
                }
                else
                {
                    infoPopup.gameObject.SetActive(true);
                    Popupinfo.text = "You do not have enough skill points for this mission";
                }
                break;

            case 5:
                if (player5Values[missions[currentMissionIndex].skillNum] >= missions[currentMissionIndex].pointsReq)
                {
                    if (missions[currentMissionIndex].trophyType == 1)
                    {
                        trophyTwo[playerTurn - 1] = missions[currentMissionIndex].victoryPoints;
                    }
                    else if (missions[currentMissionIndex].trophyType == 2)
                    {
                        trophyThree[playerTurn - 1] = missions[currentMissionIndex].victoryPoints;
                    }
                    else
                    {
                        trophyFour[playerTurn - 1] = missions[currentMissionIndex].victoryPoints;
                    }

                    ItemTxt.text = "Completed mission! Awarded + " + missions[currentMissionIndex].victoryPoints + " victory points!";
                    AmountTxt.text = "";
                    TypeTxt.text = "";
                    missions[currentMissionIndex].completedBy[4] = true;
                    missions[currentMissionIndex].cooldown = 3;
                    completeMissionBtn.gameObject.SetActive(false);
                    playerMoves--;
                }
                else
                {
                    infoPopup.gameObject.SetActive(true);
                    Popupinfo.text = "You do not have enough skill points for this mission";
                }
                break;

            case 6:
                if (player6Values[missions[currentMissionIndex].skillNum] >= missions[currentMissionIndex].pointsReq)
                {
                    if (missions[currentMissionIndex].trophyType == 1)
                    {
                        trophyTwo[playerTurn - 1] = missions[currentMissionIndex].victoryPoints;
                    }
                    else if (missions[currentMissionIndex].trophyType == 2)
                    {
                        trophyThree[playerTurn - 1] = missions[currentMissionIndex].victoryPoints;
                    }
                    else
                    {
                        trophyFour[playerTurn - 1] = missions[currentMissionIndex].victoryPoints;
                    }

                    ItemTxt.text = "Completed mission! Awarded + " + missions[currentMissionIndex].victoryPoints + " victory points!";
                    AmountTxt.text = "";
                    TypeTxt.text = "";
                    missions[currentMissionIndex].completedBy[5] = true;
                    missions[currentMissionIndex].cooldown = 3;
                    completeMissionBtn.gameObject.SetActive(false);
                    playerMoves--;
                }
                else
                {
                    infoPopup.gameObject.SetActive(true);
                    Popupinfo.text = "You do not have enough skill points for this mission";
                }
                break;


        }



    }

    public string getObject()
    {

        List<string> objectList = new List<string> { "Glock", "Rifle", "Med Kit", "Bribe Money", "Cloak", "Dynamite" };
        return objectList[Random.Range(0, objectList.Count)];

    }

    public int[] getObjectStats(string name)
    {
        int[] stats = new int[2];
        stats[0] = 0;
        stats[1] = 0;

        switch (name)
        {
            case "Glock":

                playersObjItemTxt[playerTurn - 1] = "Glock";
                playersObjAmountTxt[playerTurn - 1] = "+2";
                playersTypeTxt[playerTurn - 1] = "Munitions";

                stats[0] = 4;//munitions
                stats[1] = 2;
                break;
            case "Rifle":
                // ObjItemTxt.text = "Rifle";
                // ObjAmountTxt.text = "+5";
                // TypeTxt.text = "Munitions";

                playersObjItemTxt[playerTurn - 1] = "Rifle";
                playersObjAmountTxt[playerTurn - 1] = "+5";
                playersTypeTxt[playerTurn - 1] = "Munitions";
                stats[0] = 4;//munitions
                stats[1] = 5;
                break;
            case "Med Kit":
                // ObjItemTxt.text = "Med Kit";
                // ObjAmountTxt.text = "+3";
                // TypeTxt.text = "Strength";

                playersObjItemTxt[playerTurn - 1] = "Med Kit";
                playersObjAmountTxt[playerTurn - 1] = "+3";
                playersTypeTxt[playerTurn - 1] = "Strength";

                stats[0] = 0;//strength
                stats[1] = 3;
                break;
            case "Bribe Money":
                // ObjItemTxt.text = "Bribe Money";
                // ObjAmountTxt.text = "+3";
                // TypeTxt.text = "Currency";

                playersObjItemTxt[playerTurn - 1] = "Bribe Money";
                playersObjAmountTxt[playerTurn - 1] = "+3";
                playersTypeTxt[playerTurn - 1] = "Currency";
                stats[0] = 2;//currency
                stats[1] = 3;
                break;
            case "Cloak":
                // ObjItemTxt.text = "Cloak";
                // ObjAmountTxt.text = "+4";
                // TypeTxt.text = "Stealth";

                playersObjItemTxt[playerTurn - 1] = "Cloak";
                playersObjAmountTxt[playerTurn - 1] = "+4";
                playersTypeTxt[playerTurn - 1] = "Stealth";

                stats[0] = 1;//stealth
                stats[1] = 4;
                break;

            case "Dynamite":
                playersObjItemTxt[playerTurn - 1] = "Dynamite";
                playersObjAmountTxt[playerTurn - 1] = "+2";
                playersTypeTxt[playerTurn - 1] = "Electronics";

                stats[0] = 5;
                stats[1] = 2;

                break;

            case "NONE":
                stats[0] = 0;
                stats[0] = 0;
                break;
            default:
                Console.WriteLine("ERROR");
                break;
        }

        return stats;
    }



    public void SavePlayer()
    {
        GlobalController.Instance.playersObjItemTxt = playersObjItemTxt;
        GlobalController.Instance.playersTypeTxt = playersTypeTxt;
        GlobalController.Instance.playersObjAmountTxt = playersObjAmountTxt;

        GlobalController.Instance.playerObjects = playerObjects;

        GlobalController.Instance.enemies = enemies;
        GlobalController.Instance.counters = counters;
        //Player 1 info to save
        GlobalController.Instance.player1Values = player1Values;
        GlobalController.Instance.player1Tickets = player1Tickets;

        //Player 2 info to save
        GlobalController.Instance.player2Values = player2Values;
        GlobalController.Instance.player2Tickets = player2Tickets;

        //Player 3 info to save
        GlobalController.Instance.player3Values = player3Values;
        GlobalController.Instance.player3Tickets = player3Tickets;

        //Player 4 info to save
        GlobalController.Instance.player4Values = player4Values;
        GlobalController.Instance.player4Tickets = player4Tickets;

        //Player 5 info to save
        GlobalController.Instance.player5Values = player5Values;
        GlobalController.Instance.player5Tickets = player5Tickets;

        //Player 6 info to save
        GlobalController.Instance.player6Values = player6Values;
        GlobalController.Instance.player6Tickets = player6Tickets;

        GlobalController.Instance.pLocation = pLocation;
        GlobalController.Instance.hubLocation = hubLocation;

        GlobalController.Instance.travelled = travelled;
        GlobalController.Instance.turnOrder = turnOrder;

        GlobalController.Instance.turnOrderTxt = turnOrderTxt;

        GlobalController.Instance.trophyOne = trophyOne;
        GlobalController.Instance.trophyTwo = trophyTwo;
        GlobalController.Instance.trophyThree = trophyThree;
        GlobalController.Instance.trophyFour = trophyFour;


        GlobalController.Instance.pHealth = pHealth;



    }

    public void spawnEnemies(List<Location> hostileLocations)
    {
        foreach (Location l in hostileLocations)
        {
            Enemy e = new Enemy(l.hubNum, l.locationNum);
            enemies.Add(e);
            Debug.Log("Added a new enemy at: " + l.hubNum + ", " + l.locationNum);
        }

    }

    public void moveEnemies(List<Enemy> enemies)
    {
        foreach (Enemy e in enemies)
        {
            List<LocationPath> paths = getPaths(e.hubNum, e.locationNum);
            int randomPath = Random.Range(0, paths.Count);

            while (paths[randomPath].travelToNum == 1)
            {
                randomPath = Random.Range(0, paths.Count);
            }

            e.hubNum = paths[randomPath].hubToNum;
            e.locationNum = paths[randomPath].travelToNum;
        }

        foreach (Enemy e in enemies)
        {
            Debug.Log("enemy at: " + e.hubNum + " , " + e.locationNum);
        }
    }

    public List<LocationPath> getPaths(int hubNum, int locationNum)
    {
        List<LocationPath> paths = new List<LocationPath>();
        foreach (LocationPath lp in locationPathsScript.locationPaths)
        {
            if (lp.hubNum == hubNum)
            {
                if (lp.locationNum == locationNum)
                {
                    paths.Add(lp);
                }
            }
        }
        return paths;
    }
    //IEnumerator TurnDelayCoroutine()
    //{
    //    if (playerMoves == 0) // end of turn
    //    {
    //        yield return new WaitForSeconds(1);

    //    }

    //}

    IEnumerator PlayerGraphics()
    {
        if (hubLocation[playerTurn - 1] == 1)
        {
            Hub1.gameObject.SetActive(true);
            Hub2.gameObject.SetActive(false);
            Hub3.gameObject.SetActive(false);

            if (pLocation[playerTurn - 1] == 1)
            {
                TargetsHub0[1].gameObject.SetActive(true);
                TargetsHub0[2].gameObject.SetActive(false);
                TargetsHub0[3].gameObject.SetActive(false);
                TargetsHub0[4].gameObject.SetActive(false);
                TargetsHub0[5].gameObject.SetActive(false);
                TargetsHub0[6].gameObject.SetActive(false);
                TargetsHub0[7].gameObject.SetActive(false);
                TargetsHub0[8].gameObject.SetActive(false);
                TargetsHub0[9].gameObject.SetActive(false);
                TargetsHub0[10].gameObject.SetActive(false);
            }
            else if (pLocation[playerTurn - 1] == 2)
            {
                TargetsHub0[1].gameObject.SetActive(false);
                TargetsHub0[2].gameObject.SetActive(true);
                TargetsHub0[3].gameObject.SetActive(false);
                TargetsHub0[4].gameObject.SetActive(false);
                TargetsHub0[5].gameObject.SetActive(false);
                TargetsHub0[6].gameObject.SetActive(false);
                TargetsHub0[7].gameObject.SetActive(false);
                TargetsHub0[8].gameObject.SetActive(false);
                TargetsHub0[9].gameObject.SetActive(false);
                TargetsHub0[10].gameObject.SetActive(false);
            }
            else if (pLocation[playerTurn - 1] == 3)
            {
                TargetsHub0[1].gameObject.SetActive(false);
                TargetsHub0[2].gameObject.SetActive(false);
                TargetsHub0[3].gameObject.SetActive(true);
                TargetsHub0[4].gameObject.SetActive(false);
                TargetsHub0[5].gameObject.SetActive(false);
                TargetsHub0[6].gameObject.SetActive(false);
                TargetsHub0[7].gameObject.SetActive(false);
                TargetsHub0[8].gameObject.SetActive(false);
                TargetsHub0[9].gameObject.SetActive(false);
                TargetsHub0[10].gameObject.SetActive(false);
            }
            else if (pLocation[playerTurn - 1] == 4)
            {
                TargetsHub0[1].gameObject.SetActive(false);
                TargetsHub0[2].gameObject.SetActive(false);
                TargetsHub0[3].gameObject.SetActive(false);
                TargetsHub0[4].gameObject.SetActive(true);
                TargetsHub0[5].gameObject.SetActive(false);
                TargetsHub0[6].gameObject.SetActive(false);
                TargetsHub0[7].gameObject.SetActive(false);
                TargetsHub0[8].gameObject.SetActive(false);
                TargetsHub0[9].gameObject.SetActive(false);
                TargetsHub0[10].gameObject.SetActive(false);
            }
            else if (pLocation[playerTurn - 1] == 5)
            {
                TargetsHub0[1].gameObject.SetActive(false);
                TargetsHub0[2].gameObject.SetActive(false);
                TargetsHub0[3].gameObject.SetActive(false);
                TargetsHub0[4].gameObject.SetActive(false);
                TargetsHub0[5].gameObject.SetActive(true);
                TargetsHub0[6].gameObject.SetActive(false);
                TargetsHub0[7].gameObject.SetActive(false);
                TargetsHub0[8].gameObject.SetActive(false);
                TargetsHub0[9].gameObject.SetActive(false);
                TargetsHub0[10].gameObject.SetActive(false);
            }
            else if (pLocation[playerTurn - 1] == 6)
            {
                TargetsHub0[1].gameObject.SetActive(false);
                TargetsHub0[2].gameObject.SetActive(false);
                TargetsHub0[3].gameObject.SetActive(false);
                TargetsHub0[4].gameObject.SetActive(false);
                TargetsHub0[5].gameObject.SetActive(false);
                TargetsHub0[6].gameObject.SetActive(true);
                TargetsHub0[7].gameObject.SetActive(false);
                TargetsHub0[8].gameObject.SetActive(false);
                TargetsHub0[9].gameObject.SetActive(false);
                TargetsHub0[10].gameObject.SetActive(false);
            }
            else if (pLocation[playerTurn - 1] == 7)
            {
                TargetsHub0[1].gameObject.SetActive(false);
                TargetsHub0[2].gameObject.SetActive(false);
                TargetsHub0[3].gameObject.SetActive(false);
                TargetsHub0[4].gameObject.SetActive(false);
                TargetsHub0[5].gameObject.SetActive(false);
                TargetsHub0[6].gameObject.SetActive(false);
                TargetsHub0[7].gameObject.SetActive(true);
                TargetsHub0[8].gameObject.SetActive(false);
                TargetsHub0[9].gameObject.SetActive(false);
                TargetsHub0[10].gameObject.SetActive(false);
            }
            else if (pLocation[playerTurn - 1] == 8)
            {
                TargetsHub0[1].gameObject.SetActive(false);
                TargetsHub0[2].gameObject.SetActive(false);
                TargetsHub0[3].gameObject.SetActive(false);
                TargetsHub0[4].gameObject.SetActive(false);
                TargetsHub0[5].gameObject.SetActive(false);
                TargetsHub0[6].gameObject.SetActive(false);
                TargetsHub0[7].gameObject.SetActive(false);
                TargetsHub0[8].gameObject.SetActive(true);
                TargetsHub0[9].gameObject.SetActive(false);
                TargetsHub0[10].gameObject.SetActive(false);
            }
            else if (pLocation[playerTurn - 1] == 9)
            {
                TargetsHub0[1].gameObject.SetActive(false);
                TargetsHub0[2].gameObject.SetActive(false);
                TargetsHub0[3].gameObject.SetActive(false);
                TargetsHub0[4].gameObject.SetActive(false);
                TargetsHub0[5].gameObject.SetActive(false);
                TargetsHub0[6].gameObject.SetActive(false);
                TargetsHub0[7].gameObject.SetActive(false);
                TargetsHub0[8].gameObject.SetActive(false);
                TargetsHub0[9].gameObject.SetActive(true);
                TargetsHub0[10].gameObject.SetActive(false);
            }
            else if (pLocation[playerTurn - 1] == 10)
            {
                TargetsHub0[1].gameObject.SetActive(false);
                TargetsHub0[2].gameObject.SetActive(false);
                TargetsHub0[3].gameObject.SetActive(false);
                TargetsHub0[4].gameObject.SetActive(false);
                TargetsHub0[5].gameObject.SetActive(false);
                TargetsHub0[6].gameObject.SetActive(false);
                TargetsHub0[7].gameObject.SetActive(false);
                TargetsHub0[8].gameObject.SetActive(false);
                TargetsHub0[9].gameObject.SetActive(false);
                TargetsHub0[10].gameObject.SetActive(true);
            }
        }

        if (hubLocation[playerTurn - 1] == 2)
        {
            Hub1.gameObject.SetActive(false);
            Hub2.gameObject.SetActive(true);
            Hub3.gameObject.SetActive(false);

            if (pLocation[playerTurn - 1] == 1)
            {
                TargetsHub1[1].gameObject.SetActive(true);
                TargetsHub1[2].gameObject.SetActive(false);
                TargetsHub1[3].gameObject.SetActive(false);
                TargetsHub1[4].gameObject.SetActive(false);
                TargetsHub1[5].gameObject.SetActive(false);
                TargetsHub1[6].gameObject.SetActive(false);
                TargetsHub1[7].gameObject.SetActive(false);
                TargetsHub1[8].gameObject.SetActive(false);
                TargetsHub1[9].gameObject.SetActive(false);
                TargetsHub1[10].gameObject.SetActive(false);
                TargetsHub1[11].gameObject.SetActive(false);
                TargetsHub1[12].gameObject.SetActive(false);
            }
            else if (pLocation[playerTurn - 1] == 2)
            {
                TargetsHub1[1].gameObject.SetActive(false);
                TargetsHub1[2].gameObject.SetActive(true);
                TargetsHub1[3].gameObject.SetActive(false);
                TargetsHub1[4].gameObject.SetActive(false);
                TargetsHub1[5].gameObject.SetActive(false);
                TargetsHub1[6].gameObject.SetActive(false);
                TargetsHub1[7].gameObject.SetActive(false);
                TargetsHub1[8].gameObject.SetActive(false);
                TargetsHub1[9].gameObject.SetActive(false);
                TargetsHub1[10].gameObject.SetActive(false);
                TargetsHub1[11].gameObject.SetActive(false);
                TargetsHub1[12].gameObject.SetActive(false);
            }
            else if (pLocation[playerTurn - 1] == 3)
            {
                TargetsHub1[1].gameObject.SetActive(false);
                TargetsHub1[2].gameObject.SetActive(false);
                TargetsHub1[3].gameObject.SetActive(true);
                TargetsHub1[4].gameObject.SetActive(false);
                TargetsHub1[5].gameObject.SetActive(false);
                TargetsHub1[6].gameObject.SetActive(false);
                TargetsHub1[7].gameObject.SetActive(false);
                TargetsHub1[8].gameObject.SetActive(false);
                TargetsHub1[9].gameObject.SetActive(false);
                TargetsHub1[10].gameObject.SetActive(false);
                TargetsHub1[11].gameObject.SetActive(false);
                TargetsHub1[12].gameObject.SetActive(false);
            }
            else if (pLocation[playerTurn - 1] == 4)
            {
                TargetsHub1[1].gameObject.SetActive(false);
                TargetsHub1[2].gameObject.SetActive(false);
                TargetsHub1[3].gameObject.SetActive(false);
                TargetsHub1[4].gameObject.SetActive(true);
                TargetsHub1[5].gameObject.SetActive(false);
                TargetsHub1[6].gameObject.SetActive(false);
                TargetsHub1[7].gameObject.SetActive(false);
                TargetsHub1[8].gameObject.SetActive(false);
                TargetsHub1[9].gameObject.SetActive(false);
                TargetsHub1[10].gameObject.SetActive(false);
                TargetsHub1[11].gameObject.SetActive(false);
                TargetsHub1[12].gameObject.SetActive(false);
            }
            else if (pLocation[playerTurn - 1] == 5)
            {
                TargetsHub1[1].gameObject.SetActive(false);
                TargetsHub1[2].gameObject.SetActive(false);
                TargetsHub1[3].gameObject.SetActive(false);
                TargetsHub1[4].gameObject.SetActive(false);
                TargetsHub1[5].gameObject.SetActive(true);
                TargetsHub1[6].gameObject.SetActive(false);
                TargetsHub1[7].gameObject.SetActive(false);
                TargetsHub1[8].gameObject.SetActive(false);
                TargetsHub1[9].gameObject.SetActive(false);
                TargetsHub1[10].gameObject.SetActive(false);
                TargetsHub1[11].gameObject.SetActive(false);
                TargetsHub1[12].gameObject.SetActive(false);
            }
            else if (pLocation[playerTurn - 1] == 6)
            {
                TargetsHub1[1].gameObject.SetActive(false);
                TargetsHub1[2].gameObject.SetActive(false);
                TargetsHub1[3].gameObject.SetActive(false);
                TargetsHub1[4].gameObject.SetActive(false);
                TargetsHub1[5].gameObject.SetActive(false);
                TargetsHub1[6].gameObject.SetActive(true);
                TargetsHub1[7].gameObject.SetActive(false);
                TargetsHub1[8].gameObject.SetActive(false);
                TargetsHub1[9].gameObject.SetActive(false);
                TargetsHub1[10].gameObject.SetActive(false);
                TargetsHub1[11].gameObject.SetActive(false);
                TargetsHub1[12].gameObject.SetActive(false);
            }
            else if (pLocation[playerTurn - 1] == 7)
            {
                TargetsHub1[1].gameObject.SetActive(false);
                TargetsHub1[2].gameObject.SetActive(false);
                TargetsHub1[3].gameObject.SetActive(false);
                TargetsHub1[4].gameObject.SetActive(false);
                TargetsHub1[5].gameObject.SetActive(false);
                TargetsHub1[6].gameObject.SetActive(false);
                TargetsHub1[7].gameObject.SetActive(true);
                TargetsHub1[8].gameObject.SetActive(false);
                TargetsHub1[9].gameObject.SetActive(false);
                TargetsHub1[10].gameObject.SetActive(false);
                TargetsHub1[11].gameObject.SetActive(false);
                TargetsHub1[12].gameObject.SetActive(false);
            }
            else if (pLocation[playerTurn - 1] == 8)
            {
                TargetsHub1[1].gameObject.SetActive(false);
                TargetsHub1[2].gameObject.SetActive(false);
                TargetsHub1[3].gameObject.SetActive(false);
                TargetsHub1[4].gameObject.SetActive(false);
                TargetsHub1[5].gameObject.SetActive(false);
                TargetsHub1[6].gameObject.SetActive(false);
                TargetsHub1[7].gameObject.SetActive(false);
                TargetsHub1[8].gameObject.SetActive(true);
                TargetsHub1[9].gameObject.SetActive(false);
                TargetsHub1[10].gameObject.SetActive(false);
                TargetsHub1[11].gameObject.SetActive(false);
                TargetsHub1[12].gameObject.SetActive(false);
            }
            else if (pLocation[playerTurn - 1] == 9)
            {
                TargetsHub1[1].gameObject.SetActive(false);
                TargetsHub1[2].gameObject.SetActive(false);
                TargetsHub1[3].gameObject.SetActive(false);
                TargetsHub1[4].gameObject.SetActive(false);
                TargetsHub1[5].gameObject.SetActive(false);
                TargetsHub1[6].gameObject.SetActive(false);
                TargetsHub1[7].gameObject.SetActive(false);
                TargetsHub1[8].gameObject.SetActive(false);
                TargetsHub1[9].gameObject.SetActive(true);
                TargetsHub1[10].gameObject.SetActive(false);
                TargetsHub1[11].gameObject.SetActive(false);
                TargetsHub1[12].gameObject.SetActive(false);
            }
            else if (pLocation[playerTurn - 1] == 10)
            {
                TargetsHub1[1].gameObject.SetActive(false);
                TargetsHub1[2].gameObject.SetActive(false);
                TargetsHub1[3].gameObject.SetActive(false);
                TargetsHub1[4].gameObject.SetActive(false);
                TargetsHub1[5].gameObject.SetActive(false);
                TargetsHub1[6].gameObject.SetActive(false);
                TargetsHub1[7].gameObject.SetActive(false);
                TargetsHub1[8].gameObject.SetActive(false);
                TargetsHub1[9].gameObject.SetActive(false);
                TargetsHub1[10].gameObject.SetActive(true);
                TargetsHub1[11].gameObject.SetActive(false);
                TargetsHub1[12].gameObject.SetActive(false);
            }
            else if (pLocation[playerTurn - 1] == 11)
            {
                TargetsHub1[1].gameObject.SetActive(false);
                TargetsHub1[2].gameObject.SetActive(false);
                TargetsHub1[3].gameObject.SetActive(false);
                TargetsHub1[4].gameObject.SetActive(false);
                TargetsHub1[5].gameObject.SetActive(false);
                TargetsHub1[6].gameObject.SetActive(false);
                TargetsHub1[7].gameObject.SetActive(false);
                TargetsHub1[8].gameObject.SetActive(false);
                TargetsHub1[9].gameObject.SetActive(false);
                TargetsHub1[10].gameObject.SetActive(false);
                TargetsHub1[11].gameObject.SetActive(true);
                TargetsHub1[12].gameObject.SetActive(false);
            }
            else if (pLocation[playerTurn - 1] == 12)
            {
                TargetsHub1[1].gameObject.SetActive(false);
                TargetsHub1[2].gameObject.SetActive(false);
                TargetsHub1[3].gameObject.SetActive(false);
                TargetsHub1[4].gameObject.SetActive(false);
                TargetsHub1[5].gameObject.SetActive(false);
                TargetsHub1[6].gameObject.SetActive(false);
                TargetsHub1[7].gameObject.SetActive(false);
                TargetsHub1[8].gameObject.SetActive(false);
                TargetsHub1[9].gameObject.SetActive(false);
                TargetsHub1[10].gameObject.SetActive(false);
                TargetsHub1[11].gameObject.SetActive(false);
                TargetsHub1[12].gameObject.SetActive(true);
            }
        }

        if (hubLocation[playerTurn - 1] == 3)
        {
            Hub1.gameObject.SetActive(false);
            Hub2.gameObject.SetActive(false);
            Hub3.gameObject.SetActive(true);
            if (pLocation[playerTurn - 1] == 1)
            {
                TargetsHub2[1].gameObject.SetActive(true);
                TargetsHub2[2].gameObject.SetActive(false);
                TargetsHub2[3].gameObject.SetActive(false);
                TargetsHub2[4].gameObject.SetActive(false);
                TargetsHub2[5].gameObject.SetActive(false);
                TargetsHub2[6].gameObject.SetActive(false);
                TargetsHub2[7].gameObject.SetActive(false);
                TargetsHub2[8].gameObject.SetActive(false);
                TargetsHub2[9].gameObject.SetActive(false);
                TargetsHub2[10].gameObject.SetActive(false);
                TargetsHub2[11].gameObject.SetActive(false);
                TargetsHub2[12].gameObject.SetActive(false);
                TargetsHub2[13].gameObject.SetActive(false);
            }
            else if (pLocation[playerTurn - 1] == 2)
            {
                TargetsHub2[1].gameObject.SetActive(false);
                TargetsHub2[2].gameObject.SetActive(true);
                TargetsHub2[3].gameObject.SetActive(false);
                TargetsHub2[4].gameObject.SetActive(false);
                TargetsHub2[5].gameObject.SetActive(false);
                TargetsHub2[6].gameObject.SetActive(false);
                TargetsHub2[7].gameObject.SetActive(false);
                TargetsHub2[8].gameObject.SetActive(false);
                TargetsHub2[9].gameObject.SetActive(false);
                TargetsHub2[10].gameObject.SetActive(false);
                TargetsHub2[11].gameObject.SetActive(false);
                TargetsHub2[12].gameObject.SetActive(false);
                TargetsHub2[13].gameObject.SetActive(false);
            }
            else if (pLocation[playerTurn - 1] == 3)
            {
                TargetsHub2[1].gameObject.SetActive(false);
                TargetsHub2[2].gameObject.SetActive(false);
                TargetsHub2[3].gameObject.SetActive(true);
                TargetsHub2[4].gameObject.SetActive(false);
                TargetsHub2[5].gameObject.SetActive(false);
                TargetsHub2[6].gameObject.SetActive(false);
                TargetsHub2[7].gameObject.SetActive(false);
                TargetsHub2[8].gameObject.SetActive(false);
                TargetsHub2[9].gameObject.SetActive(false);
                TargetsHub2[10].gameObject.SetActive(false);
                TargetsHub2[11].gameObject.SetActive(false);
                TargetsHub2[12].gameObject.SetActive(false);
                TargetsHub2[13].gameObject.SetActive(false);
            }
            else if (pLocation[playerTurn - 1] == 4)
            {
                TargetsHub2[1].gameObject.SetActive(false);
                TargetsHub2[2].gameObject.SetActive(false);
                TargetsHub2[3].gameObject.SetActive(false);
                TargetsHub2[4].gameObject.SetActive(true);
                TargetsHub2[5].gameObject.SetActive(false);
                TargetsHub2[6].gameObject.SetActive(false);
                TargetsHub2[7].gameObject.SetActive(false);
                TargetsHub2[8].gameObject.SetActive(false);
                TargetsHub2[9].gameObject.SetActive(false);
                TargetsHub2[10].gameObject.SetActive(false);
                TargetsHub2[11].gameObject.SetActive(false);
                TargetsHub2[12].gameObject.SetActive(false);
                TargetsHub2[13].gameObject.SetActive(false);
            }
            else if (pLocation[playerTurn - 1] == 5)
            {
                TargetsHub2[1].gameObject.SetActive(false);
                TargetsHub2[2].gameObject.SetActive(false);
                TargetsHub2[3].gameObject.SetActive(false);
                TargetsHub2[4].gameObject.SetActive(false);
                TargetsHub2[5].gameObject.SetActive(true);
                TargetsHub2[6].gameObject.SetActive(false);
                TargetsHub2[7].gameObject.SetActive(false);
                TargetsHub2[8].gameObject.SetActive(false);
                TargetsHub2[9].gameObject.SetActive(false);
                TargetsHub2[10].gameObject.SetActive(false);
                TargetsHub2[11].gameObject.SetActive(false);
                TargetsHub2[12].gameObject.SetActive(false);
                TargetsHub2[13].gameObject.SetActive(false);
            }
            else if (pLocation[playerTurn - 1] == 6)
            {
                TargetsHub2[1].gameObject.SetActive(false);
                TargetsHub2[2].gameObject.SetActive(false);
                TargetsHub2[3].gameObject.SetActive(false);
                TargetsHub2[4].gameObject.SetActive(false);
                TargetsHub2[5].gameObject.SetActive(false);
                TargetsHub2[6].gameObject.SetActive(true);
                TargetsHub2[7].gameObject.SetActive(false);
                TargetsHub2[8].gameObject.SetActive(false);
                TargetsHub2[9].gameObject.SetActive(false);
                TargetsHub2[10].gameObject.SetActive(false);
                TargetsHub2[11].gameObject.SetActive(false);
                TargetsHub2[12].gameObject.SetActive(false);
                TargetsHub2[13].gameObject.SetActive(false);
            }
            else if (pLocation[playerTurn - 1] == 7)
            {
                TargetsHub2[1].gameObject.SetActive(false);
                TargetsHub2[2].gameObject.SetActive(false);
                TargetsHub2[3].gameObject.SetActive(false);
                TargetsHub2[4].gameObject.SetActive(false);
                TargetsHub2[5].gameObject.SetActive(false);
                TargetsHub2[6].gameObject.SetActive(false);
                TargetsHub2[7].gameObject.SetActive(true);
                TargetsHub2[8].gameObject.SetActive(false);
                TargetsHub2[9].gameObject.SetActive(false);
                TargetsHub2[10].gameObject.SetActive(false);
                TargetsHub2[11].gameObject.SetActive(false);
                TargetsHub2[12].gameObject.SetActive(false);
                TargetsHub2[13].gameObject.SetActive(false);
            }
            else if (pLocation[playerTurn - 1] == 8)
            {
                TargetsHub2[1].gameObject.SetActive(false);
                TargetsHub2[2].gameObject.SetActive(false);
                TargetsHub2[3].gameObject.SetActive(false);
                TargetsHub2[4].gameObject.SetActive(false);
                TargetsHub2[5].gameObject.SetActive(false);
                TargetsHub2[6].gameObject.SetActive(false);
                TargetsHub2[7].gameObject.SetActive(false);
                TargetsHub2[8].gameObject.SetActive(true);
                TargetsHub2[9].gameObject.SetActive(false);
                TargetsHub2[10].gameObject.SetActive(false);
                TargetsHub2[11].gameObject.SetActive(false);
                TargetsHub2[12].gameObject.SetActive(false);
                TargetsHub2[13].gameObject.SetActive(false);
            }
            else if (pLocation[playerTurn - 1] == 9)
            {
                TargetsHub2[1].gameObject.SetActive(false);
                TargetsHub2[2].gameObject.SetActive(false);
                TargetsHub2[3].gameObject.SetActive(false);
                TargetsHub2[4].gameObject.SetActive(false);
                TargetsHub2[5].gameObject.SetActive(false);
                TargetsHub2[6].gameObject.SetActive(false);
                TargetsHub2[7].gameObject.SetActive(false);
                TargetsHub2[8].gameObject.SetActive(false);
                TargetsHub2[9].gameObject.SetActive(true);
                TargetsHub2[10].gameObject.SetActive(false);
                TargetsHub2[11].gameObject.SetActive(false);
                TargetsHub2[12].gameObject.SetActive(false);
                TargetsHub2[13].gameObject.SetActive(false);
            }
            else if (pLocation[playerTurn - 1] == 10)
            {
                TargetsHub2[1].gameObject.SetActive(false);
                TargetsHub2[2].gameObject.SetActive(false);
                TargetsHub2[3].gameObject.SetActive(false);
                TargetsHub2[4].gameObject.SetActive(false);
                TargetsHub2[5].gameObject.SetActive(false);
                TargetsHub2[6].gameObject.SetActive(false);
                TargetsHub2[7].gameObject.SetActive(false);
                TargetsHub2[8].gameObject.SetActive(false);
                TargetsHub2[9].gameObject.SetActive(false);
                TargetsHub2[10].gameObject.SetActive(true);
                TargetsHub2[11].gameObject.SetActive(false);
                TargetsHub2[12].gameObject.SetActive(false);
                TargetsHub2[13].gameObject.SetActive(false);
            }
            else if (pLocation[playerTurn - 1] == 11)
            {
                TargetsHub2[1].gameObject.SetActive(false);
                TargetsHub2[2].gameObject.SetActive(false);
                TargetsHub2[3].gameObject.SetActive(false);
                TargetsHub2[4].gameObject.SetActive(false);
                TargetsHub2[5].gameObject.SetActive(false);
                TargetsHub2[6].gameObject.SetActive(false);
                TargetsHub2[7].gameObject.SetActive(false);
                TargetsHub2[8].gameObject.SetActive(false);
                TargetsHub2[9].gameObject.SetActive(false);
                TargetsHub2[10].gameObject.SetActive(false);
                TargetsHub2[11].gameObject.SetActive(true);
                TargetsHub2[12].gameObject.SetActive(false);
                TargetsHub2[13].gameObject.SetActive(false);
            }
            else if (pLocation[playerTurn - 1] == 12)
            {
                TargetsHub2[1].gameObject.SetActive(false);
                TargetsHub2[2].gameObject.SetActive(false);
                TargetsHub2[3].gameObject.SetActive(false);
                TargetsHub2[4].gameObject.SetActive(false);
                TargetsHub2[5].gameObject.SetActive(false);
                TargetsHub2[6].gameObject.SetActive(false);
                TargetsHub2[7].gameObject.SetActive(false);
                TargetsHub2[8].gameObject.SetActive(false);
                TargetsHub2[9].gameObject.SetActive(false);
                TargetsHub2[10].gameObject.SetActive(false);
                TargetsHub2[11].gameObject.SetActive(false);
                TargetsHub2[12].gameObject.SetActive(true);
                TargetsHub2[13].gameObject.SetActive(false);
            }
            else if (pLocation[playerTurn - 1] == 13)
            {
                TargetsHub2[1].gameObject.SetActive(false);
                TargetsHub2[2].gameObject.SetActive(false);
                TargetsHub2[3].gameObject.SetActive(false);
                TargetsHub2[4].gameObject.SetActive(false);
                TargetsHub2[5].gameObject.SetActive(false);
                TargetsHub2[6].gameObject.SetActive(false);
                TargetsHub2[7].gameObject.SetActive(false);
                TargetsHub2[8].gameObject.SetActive(false);
                TargetsHub2[9].gameObject.SetActive(false);
                TargetsHub2[10].gameObject.SetActive(false);
                TargetsHub2[11].gameObject.SetActive(false);
                TargetsHub2[12].gameObject.SetActive(false);
                TargetsHub2[13].gameObject.SetActive(true);
            }
        }

        switch (playerTurn)
        {
            case 1:

                playerBGs[0].gameObject.SetActive(true);
                playerBGs[1].gameObject.SetActive(false);
                playerBGs[2].gameObject.SetActive(false);
                playerBGs[3].gameObject.SetActive(false);
                playerBGs[4].gameObject.SetActive(false);
                playerBGs[5].gameObject.SetActive(false);

                playerTickets[0].gameObject.SetActive(true);
                playerTickets[1].gameObject.SetActive(false);
                playerTickets[2].gameObject.SetActive(false);
                playerTickets[3].gameObject.SetActive(false);
                playerTickets[4].gameObject.SetActive(false);
                playerTickets[5].gameObject.SetActive(false);

                playerSkills[0].gameObject.SetActive(true);
                playerSkills[1].gameObject.SetActive(false);
                playerSkills[2].gameObject.SetActive(false);
                playerSkills[3].gameObject.SetActive(false);
                playerSkills[4].gameObject.SetActive(false);
                playerSkills[5].gameObject.SetActive(false);

                float fillValue = pHealth[0];
                slider.value = fillValue;
                yield return new WaitForSeconds(1);

                break;

            case 2:

                playerBGs[0].gameObject.SetActive(false);
                playerBGs[1].gameObject.SetActive(true);
                playerBGs[2].gameObject.SetActive(false);
                playerBGs[3].gameObject.SetActive(false);
                playerBGs[4].gameObject.SetActive(false);
                playerBGs[5].gameObject.SetActive(false);

                playerTickets[0].gameObject.SetActive(false);
                playerTickets[1].gameObject.SetActive(true);
                playerTickets[2].gameObject.SetActive(false);
                playerTickets[3].gameObject.SetActive(false);
                playerTickets[4].gameObject.SetActive(false);
                playerTickets[5].gameObject.SetActive(false);

                playerSkills[0].gameObject.SetActive(false);
                playerSkills[1].gameObject.SetActive(true);
                playerSkills[2].gameObject.SetActive(false);
                playerSkills[3].gameObject.SetActive(false);
                playerSkills[4].gameObject.SetActive(false);
                playerSkills[5].gameObject.SetActive(false);


                fillValue = pHealth[1];
                slider.value = fillValue;

                yield return new WaitForSeconds(1);
                break;

            case 3:

                playerBGs[0].gameObject.SetActive(false);
                playerBGs[1].gameObject.SetActive(false);
                playerBGs[2].gameObject.SetActive(true);
                playerBGs[3].gameObject.SetActive(false);
                playerBGs[4].gameObject.SetActive(false);
                playerBGs[5].gameObject.SetActive(false);

                playerTickets[0].gameObject.SetActive(false);
                playerTickets[1].gameObject.SetActive(false);
                playerTickets[2].gameObject.SetActive(true);
                playerTickets[3].gameObject.SetActive(false);
                playerTickets[4].gameObject.SetActive(false);
                playerTickets[5].gameObject.SetActive(false);

                playerSkills[0].gameObject.SetActive(false);
                playerSkills[1].gameObject.SetActive(false);
                playerSkills[2].gameObject.SetActive(true);
                playerSkills[3].gameObject.SetActive(false);
                playerSkills[4].gameObject.SetActive(false);
                playerSkills[5].gameObject.SetActive(false);


                fillValue = pHealth[2];
                slider.value = fillValue;

                yield return new WaitForSeconds(1);

                break;

            case 4:

                playerBGs[0].gameObject.SetActive(false);
                playerBGs[1].gameObject.SetActive(false);
                playerBGs[2].gameObject.SetActive(false);
                playerBGs[3].gameObject.SetActive(true);
                playerBGs[4].gameObject.SetActive(false);
                playerBGs[5].gameObject.SetActive(false);

                playerTickets[0].gameObject.SetActive(false);
                playerTickets[1].gameObject.SetActive(false);
                playerTickets[2].gameObject.SetActive(false);
                playerTickets[3].gameObject.SetActive(true);
                playerTickets[4].gameObject.SetActive(false);
                playerTickets[5].gameObject.SetActive(false);

                playerSkills[0].gameObject.SetActive(false);
                playerSkills[1].gameObject.SetActive(false);
                playerSkills[2].gameObject.SetActive(false);
                playerSkills[3].gameObject.SetActive(true);
                playerSkills[4].gameObject.SetActive(false);
                playerSkills[5].gameObject.SetActive(false);


                fillValue = pHealth[3];
                slider.value = fillValue;

                yield return new WaitForSeconds(1);

                break;

            case 5:

                playerBGs[0].gameObject.SetActive(false);
                playerBGs[1].gameObject.SetActive(false);
                playerBGs[2].gameObject.SetActive(false);
                playerBGs[3].gameObject.SetActive(false);
                playerBGs[4].gameObject.SetActive(true);
                playerBGs[5].gameObject.SetActive(false);

                playerTickets[0].gameObject.SetActive(false);
                playerTickets[1].gameObject.SetActive(false);
                playerTickets[2].gameObject.SetActive(false);
                playerTickets[3].gameObject.SetActive(false);
                playerTickets[4].gameObject.SetActive(true);
                playerTickets[5].gameObject.SetActive(false);

                playerSkills[0].gameObject.SetActive(false);
                playerSkills[1].gameObject.SetActive(false);
                playerSkills[2].gameObject.SetActive(false);
                playerSkills[3].gameObject.SetActive(false);
                playerSkills[4].gameObject.SetActive(true);
                playerSkills[5].gameObject.SetActive(false);

                fillValue = pHealth[4];
                slider.value = fillValue;

                yield return new WaitForSeconds(1);

                break;

            case 6:

                playerBGs[0].gameObject.SetActive(false);
                playerBGs[1].gameObject.SetActive(false);
                playerBGs[2].gameObject.SetActive(false);
                playerBGs[3].gameObject.SetActive(false);
                playerBGs[4].gameObject.SetActive(false);
                playerBGs[5].gameObject.SetActive(true);

                playerTickets[0].gameObject.SetActive(false);
                playerTickets[1].gameObject.SetActive(false);
                playerTickets[2].gameObject.SetActive(false);
                playerTickets[3].gameObject.SetActive(false);
                playerTickets[4].gameObject.SetActive(false);
                playerTickets[5].gameObject.SetActive(true);

                playerSkills[0].gameObject.SetActive(false);
                playerSkills[1].gameObject.SetActive(false);
                playerSkills[2].gameObject.SetActive(false);
                playerSkills[3].gameObject.SetActive(false);
                playerSkills[4].gameObject.SetActive(false);
                playerSkills[5].gameObject.SetActive(true);

                fillValue = pHealth[5];
                slider.value = fillValue;

                yield return new WaitForSeconds(1);

                break;

            default:
                //Console.WriteLine("Default case");
                break;

                yield return new WaitForSeconds(1);

        }
    }



    public void confrontEnemies()
    {
        Debug.Log("Enemy count: " + enemies.Count);
        hubLocation = GlobalController.Instance.hubLocation;
        pLocation = GlobalController.Instance.pLocation;

        foreach (Enemy e in enemies)
        {
            Debug.Log("Enemy: " + e.hubNum + " , " + e.locationNum + " - Player: " + hubLocation[playerTurn - 1] + " , " + pLocation[playerTurn - 1]);
            if (hubLocation[playerTurn - 1] == e.hubNum && pLocation[playerTurn - 1] == e.locationNum)
            {
                Debug.Log("MATCH. PLayer health: " + pHealth[playerTurn - 1]);
                Debug.Log("Enemy damage: " + e.damage);

                pHealth[playerTurn - 1] = pHealth[playerTurn - 1] - e.damage;
                infoPopup.gameObject.SetActive(true);
                Popupinfo.text = "You confronted and defeated an enemy. You lost " + e.damage.ToString() + " health. Gained 1 Enemy trophy point!";


                trophyOne[playerTurn - 1]++;

                Debug.Log("UPDATE. PLayer health: " + pHealth[playerTurn - 1]);
                if (pHealth[playerTurn - 1] <= 0)
                {
                    pHealth[playerTurn - 1] = maxHealth;
                    trophyOne[playerTurn - 1]--;
                    trophyTwo[playerTurn - 1]--;
                    trophyThree[playerTurn - 1]--;
                    trophyFour[playerTurn - 1]--;

                    infoPopup.gameObject.SetActive(true);
                    Popupinfo.text = "An enemy defeated you. You've lost 1 of each trophy point.";
                }

                enemies.Remove(e);
                return;
            }
        }
        // newHub = GlobalController.Instance.newHub;
        // newLocation = GlobalController.Instance.newLocation;
        // pLocation = GlobalController.Instance.pLocation;
        // hubLocation = GlobalController.Instance.hubLocation;
        //
        // Debug.Log("confronting enemies. Total number: " + enemies.Count);
        //   foreach (Enemy e in enemies)
        //   {
        //     hubLocation = GlobalController.Instance.hubLocation;
        //     pLocation = GlobalController.Instance.pLocation;
        //     newHub = GlobalController.Instance.newHub;
        //     newLocation = GlobalController.Instance.newHub;
        //
        //     Debug.Log("enemy at: " + e.hubNum + ", " + e.locationNum + " player at " + newHub[playerTurn-1] + ", " + newLocation[playerTurn - 1]);
        //       if (hubLocation[playerTurn - 1] == e.hubNum && pLocation[playerTurn-1] == e.locationNum)
        //       {
        //
        //               Debug.Log("enemy found");
        //               if (e.damage  >= pHealth[playerTurn - 1])
        //               {
        //                 Debug.Log("player health : " + pHealth[playerTurn - 1]);
        //                 Debug.Log("player " + playerTurn + " took " + e.damage + " froom an enemy");
        //                 Debug.Log("player dies");
        //
        //                 pHealth[playerTurn - 1] = maxHealth;
        //                 pLocation[playerTurn - 1] = 1;
        //                 newLocation[playerTurn - 1] = 1;
        //                 hubLocation[playerTurn - 1] = 1;
        //                 newHub[playerTurn - 1] = 1;
        //                 counters[playerTurn - 1] = 0;
        //                 trophyTwo[playerTurn - 1]--;
        //                 trophyThree[playerTurn - 1]--;
        //                 trophyFour[playerTurn - 1]--;
        //                 Debug.Log("PLAYER LOCATION DEATH: " + pLocation[playerTurn - 1] + ", " + hubLocation[playerTurn - 1]);
        //                 SavePlayer();
        //                 return;
        //               }
        //               else
        //               {
        //                 Debug.Log("player " + playerTurn + " took " + e.damage + " froom an enemy");
        //                 pHealth[playerTurn - 1] = pHealth[playerTurn - 1] - e.damage;
        //                 Debug.Log("new player health: " + pHealth[playerTurn - 1]);
        //                 trophyOne[playerTurn - 1]++;
        //                 Debug.Log(trophyOne[playerTurn - 1]);
        //                 Debug.Log("PLAYER LOCATION WIN:  " + pLocation[playerTurn - 1] + ", " + hubLocation[playerTurn - 1]);
        //                 enemies.Remove(e);
        //
        //                 SavePlayer();
        //                 Debug.Log("PLAYER LOCATION WIN: " + pLocation[playerTurn - 1] + ", " + hubLocation[playerTurn - 1]);
        //                 return;
        //               }
        //
        //
        //       }
        //   }
    }

    public Mission[] generateMissions()
    {

        int count = 0;
        foreach (Location l in locationsScript.locations)
        {
            count++;
        }

        Mission[] m = new Mission[count];

        int i = 0;

        foreach (Location l in locationsScript.locations)
        {
            if (l.isAirport == 0)
            {
                m[i] = new Mission(l.hubNum, l.locationNum, Random.Range(0, 7), l.hubNum);
                i++;
            }
        }

        return m;
    }

    public void SetPopupInactive()
    {
        infoPopup.gameObject.SetActive(false);
    }


}

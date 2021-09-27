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
    damage = Random.Range(5, 50);
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

    public Mission(int h, int l, int s)
    {
      hubNum = h;
      locationNum = l;
      skillNum = s;
      cooldown = 0;

      pointsReq = ML_Algo.ML() + 1;
      victoryPoints = ML_Algo.ML() + 1;

      for (int i = 0; i < 6; i++)
      {
        completedBy[i] = false;
      }
    }
}

public class GameController : MonoBehaviour
{
    //Skillsp1Script.GetComponent<Skillsp1>();
    public List<string> log = new List<string>();
    public List<Enemy> enemies = new List<Enemy>();

    public static string[] skillNames = new string[] {"Strength", "Stealth", "Currency", "Intelligence", "Munitions", "Electronics", "Vehicle Piloting", "Code Breaking"};
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

    public TMP_Text p1ScoreText;
    public TMP_Text p2ScoreText;
    public TMP_Text p3ScoreText;
    public TMP_Text p4ScoreText;
    public TMP_Text p5ScoreText;
    public TMP_Text p6ScoreText;

    public int p1VPs = 0;
    public int p2VPs = 0;
    public int p3VPs = 0;
    public int p4VPs = 0;
    public int p5VPs = 0;
    public int p6VPs = 0;
    static public int playerTurn = 1;
    public int maxPlayers;
    public int[] pLocation = new int[6];
    public int[] hubLocation = new int[6];
    public int p1Health;
    public int p2Health;
    public int p3Health;
    public int p4Health;
    public int p5Health;
    public int p6Health;
    public int maxHealth = 100;

    //Player GameObjects to set true and false

    public GameObject p1skills;
    public GameObject p2skills;
    public GameObject p3skills;
    public GameObject p4skills;
    public GameObject p5skills;
    public GameObject p6skills;

    public GameObject p1tickets;
    public GameObject p2tickets;
    public GameObject p3tickets;
    public GameObject p4tickets;
    public GameObject p5tickets;
    public GameObject p6tickets;

    public GameObject BGp1;
    public GameObject BGp2;
    public GameObject BGp3;
    public GameObject BGp4;
    public GameObject BGp5;
    public GameObject BGp6;

    public GameObject completeMissionBtn;

    //public GameObject movesLeftTag;
    public Text movesLeft;

    public GameObject SkillObj;
    public GameObject ObjectObj;

    public Text ItemTxt;
    public Text AmountTxt;
    public Text TypeTxt;
    public Text TurnTxt;

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
    static public int playerMoves = 7;


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
        movesLeft.text = playerMoves.ToString();
    }

    void Awake()
    {

        p1CurrentObject = getObject();
        Console.WriteLine("PLAYER 1 GOT " + p1CurrentObject);
        p2CurrentObject = getObject();
        Console.WriteLine("PLAYER 2 GOT " + p2CurrentObject);
        p3CurrentObject = getObject();
        Console.WriteLine("PLAYER 3 GOT " + p3CurrentObject);
        p4CurrentObject = getObject();
        Console.WriteLine("PLAYER 4 GOT " + p4CurrentObject);
        p5CurrentObject = getObject();
        Console.WriteLine("PLAYER 5 GOT " + p5CurrentObject);
        p6CurrentObject = getObject();
        Console.WriteLine("PLAYER 6 GOT " + p6CurrentObject);

        locationsScript = LocationsObj.GetComponent<ReadLocations>();
        locationPathsScript = LocationPathsObj.GetComponent<ReadLocationPaths>();

    }

    void Start()
    {



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

        for (int i = 0; i < 4; i++)
        {
            ticketTextsp1[i].text = 0.ToString();
            ticketTextsp2[i].text = 0.ToString();
            ticketTextsp3[i].text = 0.ToString();
            ticketTextsp4[i].text = 0.ToString();
            ticketTextsp5[i].text = 0.ToString();
            ticketTextsp6[i].text = 0.ToString();
        }


        CheckPlayerTurn();

        //playerMoves = GlobalController.Instance.playerMoves;
        //turn = GlobalController.Instance.turn;

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

        missions = GlobalController.Instance.missions;
        Debug.Log(missions == null);
        if (missions != null)
        {
         Debug.Log("length" + missions.Length);
         for (int i = 0; i < missions.Length; i++)
         {
           //Outputting missions
           //Debug.Log("mission: " + (i+1) + " at " + missions[i].hubNum + ", " + missions[i].locationNum);
         }
        }
        //Debug.Log("missions count: " + missions.Length);
        if (missions == null)
        {
         Debug.Log("inside mission function");
         missions = generateMissions();
         GlobalController.Instance.missions = missions;
        }


        //for (int i = 0; i < missions.Length; i++)
        //{
        //  //Outputting missions
        //  //Debug.Log("mission: " + (i+1) + " at " + missions[i].hubNum + ", " + missions[i].locationNum);
        //}

        p1Health = maxHealth;
        p2Health = maxHealth;
        p3Health = maxHealth;
        p4Health = maxHealth;
        p5Health = maxHealth;
        p6Health = maxHealth;

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
        CheckPlayerTurn();

        if (p1VPs == 6)
        {
            PlayerOneWin();
        }

        if (p2VPs == 6)
        {
            PlayerTwoWin();
        }

        if (p3VPs == 6)
        {
            PlayerTwoWin();
        }

        if (p4VPs == 6)
        {
            PlayerTwoWin();
        }

        if (p5VPs == 6)
        {
            PlayerTwoWin();
        }

        if (p6VPs == 6)
        {
            PlayerTwoWin();
        }

        enemies = GlobalController.Instance.enemies;
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

        if (hubLocation[playerTurn - 1] == 1)
        {
            Hub1.gameObject.SetActive(true);
            Hub2.gameObject.SetActive(false);
            Hub3.gameObject.SetActive(false);
        }

        if (hubLocation[playerTurn - 1] == 2)
        {
            Hub1.gameObject.SetActive(false);
            Hub2.gameObject.SetActive(true);
            Hub3.gameObject.SetActive(false);
        }

        if (hubLocation[playerTurn - 1] == 3)
        {
            Hub1.gameObject.SetActive(false);
            Hub2.gameObject.SetActive(false);
            Hub3.gameObject.SetActive(true);
        }
    }

    void playerGmo()
    {
        StartCoroutine(ExampleCoroutine());
    }

    public void CheckPlayerTurn()
    {
        if (playerMoves == 0)
        {
            if (playerTurn == maxPlayers)
            {
                for (int i = 0; i < 6; i++)
                {
                  travelled[i] = 0;
                }
                playerTurn = 1;
                confrontEnemies();
                moveEnemies(enemies);
                spawnEnemies(locationsScript.hostileLocations);
                foreach(Mission m in missions)
                {
                  if (m.cooldown != 0)
                  {
                    m.cooldown--;
                  }
                }
            }
            else
            {

                playerTurn++;
                foreach(Mission m in missions)
                {
                  if (m.cooldown != 0)
                  {
                    m.cooldown--;
                  }
                }
                SkillObj.gameObject.SetActive(false);
                ObjectObj.gameObject.SetActive(false);
                AmountTxt.text = "";
                ItemTxt.text = "";
                TypeTxt.text = "";
                completeMissionBtn.SetActive(false);
                confrontEnemies();
                //check enemeis
            }

            playerMoves = 7;
        }
        playerGmo();
        UpdateUIStats();

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
                int experienceGained = ML_Algo.ML() + 1;
                //Actions.reduceActions();
                player1Values[skillToLevel] += experienceGained;
                skillTextsp1[skillToLevel].text = player1Values[skillToLevel].ToString();

                if (player1Values[skillToLevel] > 4)
                {
                    p1ScoreText.text = "Player 1 Victory Points: " + p1VPs.ToString();
                }

                break;
            case 2:
                skillToLevel = Random.Range(0, 8);
                experienceGained = ML_Algo.ML();
                //Actions.reduceActions();

                player2Values[skillToLevel] += experienceGained;
                skillTextsp2[skillToLevel].text = player1Values[skillToLevel].ToString();

                if (player2Values[skillToLevel] > 4)
                {
                    p2ScoreText.text = "Player 2 Victory Points: " + p2VPs.ToString();
                }

                break;
            case 3:
                skillToLevel = Random.Range(0, 8);
                experienceGained = ML_Algo.ML();
                //Actions.reduceActions();
                player3Values[skillToLevel] += experienceGained;
                skillTextsp3[skillToLevel].text = player3Values[skillToLevel].ToString();

                if (player3Values[skillToLevel] > 4)
                {
                    p3ScoreText.text = "Player 3 Victory Points: " + p3VPs.ToString();
                }

                break;
            case 4:
                skillToLevel = Random.Range(0, 8);
                experienceGained = ML_Algo.ML();
                //Actions.reduceActions();
                player4Values[skillToLevel] += experienceGained;
                skillTextsp4[skillToLevel].text = player4Values[skillToLevel].ToString();

                if (player4Values[skillToLevel] > 4)
                {

                    p4ScoreText.text = "Player 4 Victory Points: " + p4VPs.ToString();
                }

                break;
            case 5:
                skillToLevel = Random.Range(0, 8);
                experienceGained = ML_Algo.ML();
                //Actions.reduceActions();
                player5Values[skillToLevel] += experienceGained;
                skillTextsp5[skillToLevel].text = player5Values[skillToLevel].ToString();

                if (player5Values[skillToLevel] > 4)
                {
                    p5ScoreText.text = "Player 5 Victory Points: " + p5VPs.ToString();
                }

                break;
            case 6:
                skillToLevel = Random.Range(0, 8);
                experienceGained = ML_Algo.ML();
                //Actions.reduceActions();
                player6Values[skillToLevel] += experienceGained;
                skillTextsp6[skillToLevel].text = player6Values[skillToLevel].ToString();

                if (player6Values[skillToLevel] > 4)
                {
                    p6ScoreText.text = "Player 6 Victory Points: " + p6VPs.ToString();
                }

                break;
            default:
                break;
        }

        Debug.Log("Skills");
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
        Debug.Log("Player " + playerTurn.ToString() + " gained a ticket.");
        log.Add("Player " + playerTurn.ToString() + " gained a ticket.");
        TurnTxt.text = "Player " + playerTurn.ToString() + " gained a ticket.";

        playerMoves--;
        Debug.Log("Tickets");
    }

    public void ObjectClicked()
    {
        SkillObj.gameObject.SetActive(false);
        ObjectObj.gameObject.SetActive(true);
        CheckPlayerTurn();

        int[] objectInfo = new int[2];

        switch (playerTurn)
        {
            case 1:
                objectInfo = getObjectStats(p1CurrentObject);
                player1Values[objectInfo[0]] += objectInfo[1];
                skillTextsp1[objectInfo[0]].text = player1Values[objectInfo[0]].ToString();

                if (player1Values[objectInfo[0]] > 4)
                {

                }
                p1CurrentObject = getObject();
                break;
            case 2:
                objectInfo = getObjectStats(p2CurrentObject);

                player2Values[objectInfo[0]] += objectInfo[1];
                skillTextsp2[objectInfo[0]].text = player2Values[objectInfo[0]].ToString();

                if (player2Values[objectInfo[0]] > 4)
                {

                }
                p2CurrentObject = getObject();
                break;
            case 3:
                objectInfo = getObjectStats(p3CurrentObject);

                player3Values[objectInfo[0]] += objectInfo[1];
                skillTextsp3[objectInfo[0]].text = player3Values[objectInfo[0]].ToString();

                if (player3Values[objectInfo[0]] > 4)
                {

                }
                p3CurrentObject = getObject();
                break;
            case 4:
                objectInfo = getObjectStats(p4CurrentObject);

                player4Values[objectInfo[0]] += objectInfo[1];
                skillTextsp4[objectInfo[0]].text = player4Values[objectInfo[0]].ToString();

                if (player4Values[objectInfo[0]] > 4)
                {

                }
                p4CurrentObject = getObject();
                break;
            case 5:
                objectInfo = getObjectStats(p5CurrentObject);

                player5Values[objectInfo[0]] += objectInfo[1];
                skillTextsp5[objectInfo[0]].text = player5Values[objectInfo[0]].ToString();

                if (player5Values[objectInfo[0]] > 4)
                {

                }
                p5CurrentObject = getObject();
                break;
            case 6:
                objectInfo = getObjectStats(p6CurrentObject);

                player6Values[objectInfo[0]] += objectInfo[1];
                skillTextsp6[objectInfo[0]].text = player6Values[objectInfo[0]].ToString();

                if (player6Values[objectInfo[0]] > 4)
                {

                }
                break;
                p6CurrentObject = getObject();
            default:
                break;
        }

        playerMoves--;
        log.Add("Player " + playerTurn.ToString() + " acquired an object.");
        Debug.Log("Player " + playerTurn.ToString() + " acquired an object.");
        TurnTxt.text = "Player " + playerTurn.ToString() + " acquired an object.";

        Debug.Log("Objects");
    }

    public void MissionsClicked()
    {
        SkillObj.gameObject.SetActive(true);
        ObjectObj.gameObject.SetActive(false);
        TypeTxt.text = "";
        completeMissionBtn.gameObject.SetActive(true);


        Debug.Log("mission count: " + missions.Length);
        for(int i = 0; i < 9; i++)
        {
          Debug.Log(missions[i].hubNum + ", " + missions[i].locationNum);
          Debug.Log("player location: " + hubLocation[playerTurn - 1] + ", " + pLocation[playerTurn - 1]);


            if (hubLocation[playerTurn - 1] == missions[i].hubNum)
            {
                if (pLocation[playerTurn - 1] == missions[i].locationNum)
                {
                    if (missions[i].completedBy[playerTurn - 1] == false && missions[i].cooldown == 0)
                    {
                    ItemTxt.text = skillNames[missions[i].skillNum];
                    //TypeTxt.text = missions[i].pointsReq.ToString();
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

        //ItemTxt.text = ("No Mission available at this Location");
        //Debug.Log("no mission present");

        log.Add("Player " + playerTurn.ToString() + " clicked mission button.");
        TurnTxt.text = "Player " + playerTurn.ToString() + " clicked mission button.";
        //Debug.Log("Player " + playerTurn.ToString() + " clicked a mission.");
    }

    public void CompleteMissions()
    {

        switch (playerTurn)
        {
          case 1:
          Debug.Log("player has: " + player1Values[missions[currentMissionIndex].skillNum] + " points. Skillnum: " + missions[currentMissionIndex].skillNum);
          if (player1Values[missions[currentMissionIndex].skillNum] >= missions[currentMissionIndex].pointsReq)
          {
            p1VPs = p1VPs + missions[currentMissionIndex].victoryPoints;
            p1ScoreText.text = "Player 1 Victory Points: " + p1VPs.ToString();
            ItemTxt.text = "Completed mission! Awarded + " + missions[currentMissionIndex].victoryPoints + " victory points!";
            AmountTxt.text = "";
            TypeTxt.text = "";
            missions[currentMissionIndex].completedBy[0] = true;
            missions[currentMissionIndex].cooldown = 3;
          }
          break;

          case 2:
          if (player2Values[missions[currentMissionIndex].skillNum] >= missions[currentMissionIndex].pointsReq)
          {
            p2VPs = p2VPs + missions[currentMissionIndex].victoryPoints;
            p2ScoreText.text = "Player 2 Victory Points: " + p2VPs.ToString();

            ItemTxt.text = "Completed mission! Awarded " + missions[currentMissionIndex].victoryPoints + " VPs!";
            AmountTxt.text = "";
            TypeTxt.text = "";
            missions[currentMissionIndex].completedBy[1] = true;
            missions[currentMissionIndex].cooldown = 3;
          }


          break;

          case 3:
          if (player3Values[missions[currentMissionIndex].skillNum] >= missions[currentMissionIndex].pointsReq)
          {
            p3VPs = p3VPs + missions[currentMissionIndex].victoryPoints;
            p3ScoreText.text = "Player 3 Victory Points: " + p3VPs.ToString();

            ItemTxt.text = "Completed mission! Awarded + " + missions[currentMissionIndex].victoryPoints + " victory points!";
            AmountTxt.text = "";
            TypeTxt.text = "";
            missions[currentMissionIndex].completedBy[2] = true;
            missions[currentMissionIndex].cooldown = 3;
          }

          break;


        }


        completeMissionBtn.gameObject.SetActive(false);
    }

    public string getObject()
    {
        int randomNum = Random.Range(1, 5);
        switch (randomNum)
        {
            case 1:
                return "Glock";
                break;
            case 2:
                return "Rifle";
                break;
            case 3:
                return "Med Kit";
                break;
            case 4:
                return "Bribe Money";
                break;
            case 5:
                return "Dynamite";
                break;
            default:
                Console.WriteLine("ERROR");
                return "0";
                break;
        }
    }

    public int[] getObjectStats(string name)
    {
        int[] stats = new int[2];
        stats[0] = 0;
        stats[1] = 0;

        switch (name)
        {
            case "Glock":
                ItemTxt.text = "Glock";
                AmountTxt.text = "+2";
                TypeTxt.text = "Munitions";
                stats[0] = 4;//munitions
                stats[1] = 2;
                break;
            case "Rifle":
                ItemTxt.text = "Rifle";
                AmountTxt.text = "+5";
                TypeTxt.text = "Munitions";
                stats[0] = 4;//munitions
                stats[1] = 5;
                break;
            case "Med Kit":
                ItemTxt.text = "Med Kit";
                AmountTxt.text = "+3";
                TypeTxt.text = "Strength";
                stats[0] = 0;//strength
                stats[1] = 3;
                break;
            case "Bribe Money":
                ItemTxt.text = "Bribe Money";
                AmountTxt.text = "+3";
                TypeTxt.text = "Currency";
                stats[0] = 2;//currency
                stats[1] = 3;
                break;
            case "Cloak":
                ItemTxt.text = "Cloak";
                AmountTxt.text = "+4";
                TypeTxt.text = "Stealth";
                stats[0] = 4;//stealth
                stats[1] = 4;
                break;
            default:
                Console.WriteLine("ERROR");
                break;
        }

        return stats;
    }



    public void SavePlayer()
    {
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

        //GlobalController.Instance.playerMoves = playerMoves;
        //GlobalController.Instance.turn = turn;

    }

    public void spawnEnemies(List<Location> hostileLocations)
    {
      foreach(Location l in hostileLocations)
      {
        Enemy e = new Enemy(l.hubNum, l.locationNum);
        enemies.Add(e);
        Debug.Log("Added a new enemy at: " + l.hubNum + ", " + l.locationNum);
      }
    }

    public void moveEnemies(List<Enemy> enemies)
    {
      foreach(Enemy e in enemies)
      {
        Debug.Log("Enemy at: " + e.hubNum + ", " + e.locationNum);
        List<LocationPath> paths = getPaths(e.hubNum, e.locationNum);
        int randomPath = Random.Range(0,paths.Count);

        while (paths[randomPath].travelToNum == 1)
        {
        randomPath = Random.Range(0,paths.Count);
        }

        e.hubNum = paths[randomPath].hubToNum;
        e.locationNum = paths[randomPath].travelToNum;
        Debug.Log("Enemy moved to: " + e.hubNum + ", " + e.locationNum);
      }
    }

    public List<LocationPath> getPaths(int hubNum, int locationNum)
    {
      List<LocationPath> paths = new List<LocationPath>();
      foreach(LocationPath lp in locationPathsScript.locationPaths)
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



    IEnumerator ExampleCoroutine()
    {
        //yield on a new YieldInstruction that waits for 5 seconds.
        switch (playerTurn)
        {
            case 1:

                yield return new WaitForSeconds(1);

                //Console.WriteLine("Case 1");
                p1skills.gameObject.SetActive(true);
                p2skills.gameObject.SetActive(false);
                p3skills.gameObject.SetActive(false);
                p4skills.gameObject.SetActive(false);
                p5skills.gameObject.SetActive(false);
                p6skills.gameObject.SetActive(false);

                p1tickets.gameObject.SetActive(true);
                p2tickets.gameObject.SetActive(false);
                p3tickets.gameObject.SetActive(false);
                p4tickets.gameObject.SetActive(false);
                p5tickets.gameObject.SetActive(false);
                p6tickets.gameObject.SetActive(false);

                BGp1.gameObject.SetActive(true);
                BGp2.gameObject.SetActive(false);
                BGp3.gameObject.SetActive(false);
                BGp4.gameObject.SetActive(false);
                BGp5.gameObject.SetActive(false);
                BGp6.gameObject.SetActive(false);

                p1ScoreText.gameObject.SetActive(true);
                p2ScoreText.gameObject.SetActive(false);
                p3ScoreText.gameObject.SetActive(false);
                p4ScoreText.gameObject.SetActive(false);
                p5ScoreText.gameObject.SetActive(false);
                p6ScoreText.gameObject.SetActive(false);

                float fillValue = p1Health;
                slider.value = fillValue;

                break;

            case 2:

                yield return new WaitForSeconds(1);

                p1ScoreText.gameObject.SetActive(false);
                p2ScoreText.gameObject.SetActive(true);
                p3ScoreText.gameObject.SetActive(false);
                p4ScoreText.gameObject.SetActive(false);
                p5ScoreText.gameObject.SetActive(false);
                p6ScoreText.gameObject.SetActive(false);
                //Console.WriteLine("Case 2");
                p1skills.gameObject.SetActive(false);
                p2skills.gameObject.SetActive(true);
                p3skills.gameObject.SetActive(false);
                p4skills.gameObject.SetActive(false);
                p5skills.gameObject.SetActive(false);
                p6skills.gameObject.SetActive(false);

                p1tickets.gameObject.SetActive(false);
                p2tickets.gameObject.SetActive(true);
                p3tickets.gameObject.SetActive(false);
                p4tickets.gameObject.SetActive(false);
                p5tickets.gameObject.SetActive(false);
                p6tickets.gameObject.SetActive(false);

                BGp1.gameObject.SetActive(false);
                BGp2.gameObject.SetActive(true);
                BGp3.gameObject.SetActive(false);
                BGp4.gameObject.SetActive(false);
                BGp5.gameObject.SetActive(false);
                BGp6.gameObject.SetActive(false);

                fillValue = p2Health;
                slider.value = fillValue;

                break;

            case 3:

                yield return new WaitForSeconds(1);

                p1ScoreText.gameObject.SetActive(false);
                p2ScoreText.gameObject.SetActive(false);
                p3ScoreText.gameObject.SetActive(true);
                p4ScoreText.gameObject.SetActive(false);
                p5ScoreText.gameObject.SetActive(false);
                p6ScoreText.gameObject.SetActive(false);
                //oOoo
                p1skills.gameObject.SetActive(false);
                p2skills.gameObject.SetActive(false);
                p3skills.gameObject.SetActive(true);
                p4skills.gameObject.SetActive(false);
                p5skills.gameObject.SetActive(false);
                p6skills.gameObject.SetActive(false);

                p1tickets.gameObject.SetActive(false);
                p2tickets.gameObject.SetActive(false);
                p3tickets.gameObject.SetActive(true);
                p4tickets.gameObject.SetActive(false);
                p5tickets.gameObject.SetActive(false);
                p6tickets.gameObject.SetActive(false);

                BGp1.gameObject.SetActive(false);
                BGp2.gameObject.SetActive(false);
                BGp3.gameObject.SetActive(true);
                BGp4.gameObject.SetActive(false);
                BGp5.gameObject.SetActive(false);
                BGp6.gameObject.SetActive(false);

                fillValue = p3Health;
                slider.value = fillValue;

                break;

            case 4:

                yield return new WaitForSeconds(1);

                p1ScoreText.gameObject.SetActive(false);
                p2ScoreText.gameObject.SetActive(false);
                p3ScoreText.gameObject.SetActive(false);
                p4ScoreText.gameObject.SetActive(true);
                p5ScoreText.gameObject.SetActive(false);
                p6ScoreText.gameObject.SetActive(false);

                p1skills.gameObject.SetActive(false);
                p2skills.gameObject.SetActive(false);
                p3skills.gameObject.SetActive(false);
                p4skills.gameObject.SetActive(true);
                p5skills.gameObject.SetActive(false);
                p6skills.gameObject.SetActive(false);

                p1tickets.gameObject.SetActive(false);
                p2tickets.gameObject.SetActive(false);
                p3tickets.gameObject.SetActive(false);
                p4tickets.gameObject.SetActive(true);
                p5tickets.gameObject.SetActive(false);
                p6tickets.gameObject.SetActive(false);

                BGp1.gameObject.SetActive(false);
                BGp2.gameObject.SetActive(false);
                BGp3.gameObject.SetActive(false);
                BGp4.gameObject.SetActive(true);
                BGp5.gameObject.SetActive(false);
                BGp6.gameObject.SetActive(false);

                fillValue = p4Health;
                slider.value = fillValue;

                break;

            case 5:

                yield return new WaitForSeconds(1);

                p1ScoreText.gameObject.SetActive(false);
                p2ScoreText.gameObject.SetActive(false);
                p3ScoreText.gameObject.SetActive(false);
                p4ScoreText.gameObject.SetActive(false);
                p5ScoreText.gameObject.SetActive(true);
                p6ScoreText.gameObject.SetActive(false);

                p1skills.gameObject.SetActive(false);
                p2skills.gameObject.SetActive(false);
                p3skills.gameObject.SetActive(false);
                p4skills.gameObject.SetActive(false);
                p5skills.gameObject.SetActive(true);
                p6skills.gameObject.SetActive(false);

                p1tickets.gameObject.SetActive(false);
                p2tickets.gameObject.SetActive(false);
                p3tickets.gameObject.SetActive(false);
                p4tickets.gameObject.SetActive(false);
                p5tickets.gameObject.SetActive(true);
                p6tickets.gameObject.SetActive(false);

                BGp1.gameObject.SetActive(false);
                BGp2.gameObject.SetActive(false);
                BGp3.gameObject.SetActive(false);
                BGp4.gameObject.SetActive(false);
                BGp5.gameObject.SetActive(true);
                BGp6.gameObject.SetActive(false);

                fillValue = p5Health;
                slider.value = fillValue;

                break;

            case 6:

                yield return new WaitForSeconds(1);

                p1ScoreText.gameObject.SetActive(false);
                p2ScoreText.gameObject.SetActive(false);
                p3ScoreText.gameObject.SetActive(false);
                p4ScoreText.gameObject.SetActive(false);
                p5ScoreText.gameObject.SetActive(false);
                p6ScoreText.gameObject.SetActive(true);

                p1skills.gameObject.SetActive(false);
                p2skills.gameObject.SetActive(false);
                p3skills.gameObject.SetActive(false);
                p4skills.gameObject.SetActive(false);
                p5skills.gameObject.SetActive(false);
                p6skills.gameObject.SetActive(true);

                p1tickets.gameObject.SetActive(false);
                p2tickets.gameObject.SetActive(false);
                p3tickets.gameObject.SetActive(false);
                p4tickets.gameObject.SetActive(false);
                p5tickets.gameObject.SetActive(false);
                p6tickets.gameObject.SetActive(true);

                BGp1.gameObject.SetActive(false);
                BGp2.gameObject.SetActive(false);
                BGp3.gameObject.SetActive(false);
                BGp4.gameObject.SetActive(false);
                BGp5.gameObject.SetActive(false);
                BGp6.gameObject.SetActive(true);

                fillValue = p6Health;
                slider.value = fillValue;

                break;

            default:
                //Console.WriteLine("Default case");
                break;
        }

    }

    public void confrontEnemies()
    {
      Debug.Log(" e function called");
      foreach(Enemy e in enemies)
      {
        Debug.Log("player: " + hubLocation[playerTurn - 1] + ", " + pLocation[playerTurn - 1] + " - enemy: " + e.hubNum + ", " + e.locationNum);
        if (hubLocation[playerTurn - 1] == e.hubNum)
        {
          Debug.Log("got to hub of enemy");
          if (pLocation[playerTurn - 1] == e.locationNum)
          {
            //enemy found
            Debug.Log("confronting enemy");
            switch (playerTurn)
            {
              case 1:
                if (e.damage >= p1Health)
                {
                  Debug.Log("player dies");
                  pLocation[playerTurn - 1] = 1;
                  hubLocation[playerTurn - 1] = 1;
                  if (p1VPs > 2) {
                  p1VPs = p1VPs - 2;
                  }
                  else {
                    p1VPs = 0;
                  }
                }
                else
                {
                  p1Health = p1Health - e.damage;
                  enemies.Remove(e);
                  return;
                }
              break;

              case 2:

              if (e.damage >= p1Health)
              {
                pLocation[playerTurn - 1] = 1;
                hubLocation[playerTurn - 1] = 1;
                if (p2VPs > 2) {
                p2VPs = p2VPs - 2;
                }
                else {
                  p2VPs = 0;
                }
                Debug.Log("player dies");
              }
              else
              {
                p2Health = p2Health - e.damage;
                enemies.Remove(e);
                return;
              }
              break;

              case 3:

              if (e.damage >= p1Health)
              {
                Debug.Log("player dies");
                pLocation[playerTurn - 1] = 1;
                hubLocation[playerTurn - 1] = 1;
                if (p3VPs > 2) {
                p1VPs = p3VPs - 2;
                }
                else {
                  p3VPs = 0;
                }
              }
              else
              {
                p3Health = p3Health - e.damage;
                enemies.Remove(e);
                return;
              }
              break;
            }
          }
        }
      }
    }

    public Mission[] generateMissions()
    {

      Mission[] m = new Mission[9];
      Debug.Log("inside");
      List<Location> potentialLocationsHub1 = new List<Location>();
      List<Location> potentialLocationsHub2 = new List<Location>();
      List<Location> potentialLocationsHub3 = new List<Location>();

      foreach(Location l in locationsScript.locations)
      {
        if (l.isSpawner == 0 && l.isAirport == 0)
        {
          if (l.hubNum == 1)
          {
            potentialLocationsHub1.Add(l);
          }
          if (l.hubNum == 2)
          {
            potentialLocationsHub2.Add(l);
          }
          if (l.hubNum == 3)
          {
            potentialLocationsHub3.Add(l);
          }
        }
      }

      IListExtensions.Shuffle(potentialLocationsHub1);
      IListExtensions.Shuffle(potentialLocationsHub2);
      IListExtensions.Shuffle(potentialLocationsHub3);

      int[] skillsHub1 = new int[7];
      int[] skillsHub2 = new int[7];
      int[] skillsHub3 = new int[7];

      for (int i = 0; i < 7; i++)
      {
        skillsHub1[i] = i + 1;
        skillsHub2[i] = i + 1;
        skillsHub3[i] = i + 1;
      }

      IListExtensions.Shuffle(skillsHub1);

      for (int i = 0; i < 3; i++)
      {
        Debug.Log("inside for in function");
        Mission m1 = new Mission(1, potentialLocationsHub1[i].locationNum, skillsHub1[i]);
        Mission m2 = new Mission(2, potentialLocationsHub2[i].locationNum, skillsHub2[i]);
        Mission m3 = new Mission(3, potentialLocationsHub3[i].locationNum, skillsHub3[i]);

        m[i] = m1;
        m[i+3] = m2;
        m[i+6] = m3;
      }
      return m;
    }
}

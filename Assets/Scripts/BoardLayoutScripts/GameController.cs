using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{    
    //Skillsp1Script.GetComponent<Skillsp1>();

    TMP_Text p1ScoreText;
    TMP_Text p2ScoreText;
    TMP_Text p3ScoreText;

    public int p1VPs = 0;
    public int p2VPs = 0;
    public int p3VPs = 0;
    public int p4VPs = 0;
    public int p5VPs = 0;
    public int p6VPs = 0;
    public int playerTurn = 1;
    public int maxPlayers = 6;

    //Player GameObjects to set true and false
    //[SerializeField]
    GameObject p1skills;
    GameObject p2skills;
    GameObject p3skills;
    GameObject p4skills;
    GameObject p5skills;
    GameObject p6skills;

    GameObject p1tickets;
    GameObject p2tickets;
    GameObject p3tickets;
    GameObject p4tickets;
    GameObject p5tickets;
    GameObject p6tickets;

    GameObject BGp1;
    GameObject BGp2;
    GameObject BGp3;
    GameObject BGp4;
    GameObject BGp5;
    GameObject BGp6;

    GameObject Skillsp1;
    GameObject Skillsp2;
    GameObject Skillsp3;
    GameObject Skillsp4;
    GameObject Skillsp5;
    GameObject Skillsp6;

    GameObject Ticketsp1;
    GameObject Ticketsp2;
    GameObject Ticketsp3;
    GameObject Ticketsp4;
    GameObject Ticketsp5;
    GameObject Ticketsp6;

    GameObject movesLeftTag;

    GameObject p1VPsTag;
    GameObject p2VPsTag;
    GameObject p3VPsTag;
    GameObject p4VPsTag;
    GameObject p5VPsTag;
    GameObject p6VPsTag;

    //Player 1 Stats
    TMP_Text[] skillTextsp1 = new TMP_Text[8];
    public int[] player1Values = new int[8];
    TMP_Text[] ticketTextsp1 = new TMP_Text[4];
    public int[] player1Tickets = new int[4];

    //Player2 Stats
    TMP_Text[] skillTextsp2 = new TMP_Text[8];
    public int[] player2Values = new int[8];
    TMP_Text[] ticketTextsp2 = new TMP_Text[4];
    public int[] player2Tickets = new int[4];

    //Player3 Stats
    TMP_Text[] skillTextsp3 = new TMP_Text[8];
    public int[] player3Values = new int[8];
    TMP_Text[] ticketTextsp3 = new TMP_Text[4];
    public int[] player3Tickets = new int[4];

    //Player4 Stats
    TMP_Text[] skillTextsp4 = new TMP_Text[8];
    public int[] player4Values = new int[8];
    TMP_Text[] ticketTextsp4 = new TMP_Text[4];
    public int[] player4Tickets = new int[4];

    //Player5 Stats
    TMP_Text[] skillTextsp5 = new TMP_Text[8];
    public int[] player5Values = new int[8];
    TMP_Text[] ticketTextsp5 = new TMP_Text[4];
    public int[] player5Tickets = new int[4];

    //Player6 Stats
    TMP_Text[] skillTextsp6 = new TMP_Text[8];
    public int[] player6Values = new int[8];
    TMP_Text[] ticketTextsp6 = new TMP_Text[4];
    public int[] player6Tickets = new int[4];

    //Moves left
    static public int playerMoves = 3;

    Text movesLeft;

    //false = Player 1 Turn | true = Player 2 Turn
    static public bool turn = false;
        
    void UpdateUIStats()
    {
        movesLeft.text = playerMoves.ToString();

    }

    void Awake()
    {
        p1skills = GameObject.Find("P1Skills");
        p2skills = GameObject.Find("P2Skills");
        p3skills = GameObject.Find("P3Skills");
        p4skills = GameObject.Find("P4Skills");
        p5skills = GameObject.Find("P5Skills");
        p6skills = GameObject.Find("P6Skills");

        p1tickets = GameObject.Find("TicketsP1");
        p2tickets = GameObject.Find("TicketsP2");
        p3tickets = GameObject.Find("TicketsP3");
        p4tickets = GameObject.Find("TicketsP4");
        p5tickets = GameObject.Find("TicketsP5");
        p6tickets = GameObject.Find("TicketsP6");

        BGp1 = GameObject.Find("img Background p1");
        BGp2 = GameObject.Find("img Background p2");
        BGp3 = GameObject.Find("img Background p3");
        BGp4 = GameObject.Find("img Background p4");
        BGp5 = GameObject.Find("img Background p5");
        BGp6 = GameObject.Find("img Background p6");

        Skillsp1 = GameObject.Find("P1Skills");
        Skillsp2 = GameObject.Find("P2Skills");
        Skillsp3 = GameObject.Find("P3Skills");
        Skillsp4 = GameObject.Find("P4Skills");
        Skillsp5 = GameObject.Find("P5Skills");
        Skillsp6 = GameObject.Find("P6Skills");

        Ticketsp1 = GameObject.Find("TicketsP1");
        Ticketsp2 = GameObject.Find("TicketsP2");
        Ticketsp3 = GameObject.Find("TicketsP3");
        Ticketsp4 = GameObject.Find("TicketsP4");
        Ticketsp5 = GameObject.Find("TicketsP5");
        Ticketsp6 = GameObject.Find("TicketsP6");

        movesLeftTag = GameObject.Find("MovesLeft");

        p1VPsTag = GameObject.Find("ScoreP1");
        p2VPsTag = GameObject.Find("ScoreP2");
        p3VPsTag = GameObject.Find("ScoreP3");
        p4VPsTag = GameObject.Find("ScoreP4");
        p5VPsTag = GameObject.Find("ScoreP5");
        p6VPsTag = GameObject.Find("ScoreP6");


        movesLeft = movesLeftTag.transform.GetComponent<Text>();
        p1ScoreText = p1VPsTag.transform.GetComponent<TMP_Text>();
        p2ScoreText = p2VPsTag.transform.GetComponent<TMP_Text>();
        p3ScoreText = p3VPsTag.transform.GetComponent<TMP_Text>();
        p4ScoreText = p4VPsTag.transform.GetComponent<TMP_Text>();
        p5ScoreText = p5VPsTag.transform.GetComponent<TMP_Text>();
        p6ScoreText = p6VPsTag.transform.GetComponent<TMP_Text>();

        for (int i = 0; i < 8; i++)
        {
            skillTextsp1[i] = Skillsp1.transform.GetChild(i).GetComponent<TMP_Text>();
            skillTextsp2[i] = Skillsp2.transform.GetChild(i).GetComponent<TMP_Text>();
            skillTextsp3[i] = Skillsp3.transform.GetChild(i).GetComponent<TMP_Text>();
            skillTextsp4[i] = Skillsp4.transform.GetChild(i).GetComponent<TMP_Text>();
            skillTextsp5[i] = Skillsp5.transform.GetChild(i).GetComponent<TMP_Text>();
            skillTextsp6[i] = Skillsp6.transform.GetChild(i).GetComponent<TMP_Text>();
        }

        for (int i = 0; i < 4; i++)
        {
            ticketTextsp1[i] = Ticketsp1.transform.GetChild(i).GetComponent<TMP_Text>();
            ticketTextsp2[i] = Ticketsp2.transform.GetChild(i).GetComponent<TMP_Text>();
            ticketTextsp3[i] = Ticketsp3.transform.GetChild(i).GetComponent<TMP_Text>();
            ticketTextsp4[i] = Ticketsp4.transform.GetChild(i).GetComponent<TMP_Text>();
            ticketTextsp5[i] = Ticketsp5.transform.GetChild(i).GetComponent<TMP_Text>();
            ticketTextsp6[i] = Ticketsp6.transform.GetChild(i).GetComponent<TMP_Text>();
        }
    }

    void Start()
    {
        CheckPlayerTurn();
        //playerMoves = GlobalController.Instance.playerMoves;
        //turn = GlobalController.Instance.turn;

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
        //Gameplay variables to load



    }

    void playerGmo()
    {

        //if (true)
        //{            
        //    turn = true;            
        //    p1skills.gameObject.SetActive(false);
        //    p2skills.gameObject.SetActive(true);
        //    p1tickets.gameObject.SetActive(false);
        //    p2tickets.gameObject.SetActive(true);
        //    BGp1.gameObject.SetActive(false);
        //    BGp2.gameObject.SetActive(true);

        //}
        //else
        //{            
        //    turn = false;
        //    p1skills.gameObject.SetActive(true);
        //    p2skills.gameObject.SetActive(false);
        //    p1tickets.gameObject.SetActive(true);
        //    p2tickets.gameObject.SetActive(false);
        //    BGp1.gameObject.SetActive(true);
        //    BGp2.gameObject.SetActive(false);

        //}

        switch (playerTurn)
        {
            case 1:
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

                break;

            case 2:
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

                break;

            case 3:
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

                break;

            case 4:

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

                break;

            case 5:
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

                break;

            case 6:

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

                break;

            default:
                //Console.WriteLine("Default case");
                break;
        }
    }

    void CheckPlayerTurn()
    {
        if (playerMoves == 0)
        {
            if (playerTurn == maxPlayers)
            {
                playerTurn = 1;
            }
            else
            {
                playerTurn++;
            }

            playerMoves = 3;
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
                int experienceGained = ML_Algo.ML();
                //Actions.reduceActions();
                player1Values[skillToLevel] += experienceGained;
                skillTextsp1[skillToLevel].text = player1Values[skillToLevel].ToString();

                if (player1Values[skillToLevel] > 4)
                {
                    p1VPs++;
                    p1ScoreText.text = "Player 1 Victory Points: " + p1VPs.ToString();
                }
                
                break;
            case 2:
                int skillToLevel = Random.Range(0, 8);
                int experienceGained = ML_Algo.ML();
                Actions.reduceActions();

                player2Values[skillToLevel] += experienceGained;
                skillTextsp2[skillToLevel].text = player1Values[skillToLevel].ToString();

                if (player2Values[skillToLevel] > 4)
                {
                    p2VPs++;
                    p2ScoreText.text = "Player 2 Victory Points: " + p2VPs.ToString();
                }
                
                break;
            case 3:
                int skillToLevel = Random.Range(0, 8);
                int experienceGained = ML_Algo.ML();
                //Actions.reduceActions();
                player3Values[skillToLevel] += experienceGained;
                skillTextsp3[skillToLevel].text = player3Values[skillToLevel].ToString();

                if (player3Values[skillToLevel] > 4)
                {
                    p3VPs++;
                    p3ScoreText.text = "Player 3 Victory Points: " + p3VPs.ToString();
                }
                
                break;
            case 4:
                int skillToLevel = Random.Range(0, 8);
                int experienceGained = ML_Algo.ML();
                //Actions.reduceActions();
                player4Values[skillToLevel] += experienceGained;
                skillTextsp4[skillToLevel].text = player4Values[skillToLevel].ToString();

                if (player4Values[skillToLevel] > 4)
                {
                    p4VPs++;
                    p4ScoreText.text = "Player 4 Victory Points: " + p4VPs.ToString();
                }

                break;
            case 5:
                int skillToLevel = Random.Range(0, 8);
                int experienceGained = ML_Algo.ML();
                //Actions.reduceActions();
                player5Values[skillToLevel] += experienceGained;
                skillTextsp5[skillToLevel].text = player5Values[skillToLevel].ToString();

                if (player5Values[skillToLevel] > 4)
                {
                    p5VPs++;
                    p5ScoreText.text = "Player 5 Victory Points: " + p5VPs.ToString();
                }

                break;
            case 6:
                int skillToLevel = Random.Range(0, 8);
                int experienceGained = ML_Algo.ML();
                //Actions.reduceActions();
                player6Values[skillToLevel] += experienceGained;
                skillTextsp6[skillToLevel].text = player6Values[skillToLevel].ToString();

                if (player6Values[skillToLevel] > 4)
                {
                    p6VPs++;
                    p6ScoreText.text = "Player 6 Victory Points: " + p6VPs.ToString();
                }

                break;
            default:
                break;
        }

        Debug.Log("Skills");
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
                    if (player1Tickets[3] >= 3)
                    {
                        p1VPs++;
                        p1ScoreText.text = "Player 1 Victory Points: " + p2VPs.ToString();
                    }
                }
                else if (ticketGained == 2)
                {
                    player1Tickets[2]++;
                    ticketTextsp1[2].text = player1Tickets[2].ToString();
                    if (player1Tickets[2] >= 3)
                    {
                        p1VPs++;
                        p1ScoreText.text = "Player 1 Victory Points: " + p1VPs.ToString();
                    }
                }
                else if (ticketGained == 3)
                {
                    player1Tickets[0]++;
                    ticketTextsp1[0].text = player1Tickets[0].ToString();
                    if (player1Tickets[0] >= 3)
                    {
                        p1VPs++;
                        p1ScoreText.text = "Player 1 Victory Points: " + p1VPs.ToString();
                    }
                }
                else
                {
                    player1Tickets[1]++;
                    ticketTextsp1[1].text = player1Tickets[1].ToString();
                    if (player1Tickets[1] >= 3)
                    {
                        p1VPs++;
                        p1ScoreText.text = "Player 1 Victory Points: " + p1VPs.ToString();
                    }
                }

                Actions.reduceActions();
                break;
            case 2:
                //TICKETS
                int ticketGained = 0;
                while (ticketGained == 0)
                {
                    ticketGained = ML_Algo.ML();
                }

                if (ticketGained == 1)
                {
                    player2Tickets[3]++;
                    ticketTextsp2[3].text = player2Tickets[3].ToString();
                    if (player2Tickets[3] >= 3)
                    {
                        p2VPs++;
                        p2ScoreText.text = "Player 2 Victory Points: " + p2VPs.ToString();
                    }
                }
                else if (ticketGained == 2)
                {
                    player2Tickets[2]++;
                    ticketTextsp2[2].text = player2Tickets[2].ToString();
                    if (player2Tickets[2] >= 3)
                    {
                        p2VPs++;
                        p2ScoreText.text = "Player 2 Victory Points: " + p2VPs.ToString();
                    }
                }
                else if (ticketGained == 3)
                {
                    player2Tickets[0]++;
                    ticketTextsp2[0].text = player2Tickets[0].ToString();
                    if (player2Tickets[0] >= 3)
                    {
                        p2VPs++;
                        p2ScoreText.text = "Player 2 Victory Points: " + p2VPs.ToString();
                    }
                }
                else
                {
                    player2Tickets[1]++;
                    ticketTextsp2[1].text = player2Tickets[1].ToString();
                    if (player2Tickets[1] >= 3)
                    {
                        p2VPs++;
                        p2ScoreText.text = "Player 2 Victory Points: " + p2VPs.ToString();
                    }
                }

                Actions.reduceActions();
                break;
            case 3:
                //TICKETS
                int ticketGained = 0;
                while (ticketGained == 0)
                {
                    ticketGained = ML_Algo.ML();
                }

                if (ticketGained == 1)
                {
                    player3Tickets[3]++;
                    ticketTextsp3[3].text = player3Tickets[3].ToString();
                    if (player3Tickets[3] >= 3)
                    {
                        p3VPs++;
                        p3ScoreText.text = "Player 3 Victory Points: " + p3VPs.ToString();
                    }
                }
                else if (ticketGained == 2)
                {
                    player3Tickets[2]++;
                    ticketTextsp3[2].text = player3Tickets[2].ToString();
                    if (player3Tickets[2] >= 3)
                    {
                        p3VPs++;
                        p3ScoreText.text = "Player 3 Victory Points: " + p3VPs.ToString();
                    }
                }
                else if (ticketGained == 3)
                {
                    player3Tickets[0]++;
                    ticketTextsp3[0].text = player3Tickets[0].ToString();
                    if (player3Tickets[0] >= 3)
                    {
                        p3VPs++;
                        p3ScoreText.text = "Player 3 Victory Points: " + p3VPs.ToString();
                    }
                }
                else
                {
                    player3Tickets[1]++;
                    ticketTextsp3[1].text = player3Tickets[1].ToString();
                    if (player3Tickets[1] >= 3)
                    {
                        p3VPs++;
                        p3ScoreText.text = "Player 3 Victory Points: " + p3VPs.ToString();
                    }
                }

                Actions.reduceActions();
                break;
            case 4:
                //TICKETS
                int ticketGained = 0;
                while (ticketGained == 0)
                {
                    ticketGained = ML_Algo.ML();
                }

                if (ticketGained == 1)
                {
                    player4Tickets[3]++;
                    ticketTextsp4[3].text = player4Tickets[3].ToString();
                    if (player4Tickets[3] >= 3)
                    {
                        p4VPs++;
                        p4ScoreText.text = "Player 4 Victory Points: " + p4VPs.ToString();
                    }
                }
                else if (ticketGained == 2)
                {
                    player4Tickets[2]++;
                    ticketTextsp4[2].text = player4Tickets[2].ToString();
                    if (player4Tickets[2] >= 3)
                    {
                        p5VPs++;
                        p4ScoreText.text = "Player 4 Victory Points: " + p4VPs.ToString();
                    }
                }
                else if (ticketGained == 3)
                {
                    player4Tickets[0]++;
                    ticketTextsp4[0].text = player4Tickets[0].ToString();
                    if (player4Tickets[0] >= 3)
                    {
                        p4VPs++;
                        p4ScoreText.text = "Player 4 Victory Points: " + p4VPs.ToString();
                    }
                }
                else
                {
                    player4Tickets[1]++;
                    ticketTextsp4[1].text = player4Tickets[1].ToString();
                    if (player4Tickets[1] >= 3)
                    {
                        p4VPs++;
                        p4ScoreText.text = "Player 4 Victory Points: " + p4VPs.ToString();
                    }
                }

                Actions.reduceActions();
                break;
            case 5:
                //TICKETS
                int ticketGained = 0;
                while (ticketGained == 0)
                {
                    ticketGained = ML_Algo.ML();
                }

                if (ticketGained == 1)
                {
                    player5Tickets[3]++;
                    ticketTextsp5[3].text = player5Tickets[3].ToString();
                    if (player5Tickets[3] >= 3)
                    {
                        p5VPs++;
                        p5ScoreText.text = "Player 5 Victory Points: " + p5VPs.ToString();
                    }
                }
                else if (ticketGained == 2)
                {
                    player5Tickets[2]++;
                    ticketTextsp5[2].text = player5Tickets[2].ToString();
                    if (player5Tickets[2] >= 3)
                    {
                        p5VPs++;
                        p5ScoreText.text = "Player 5 Victory Points: " + p5VPs.ToString();
                    }
                }
                else if (ticketGained == 3)
                {
                    player5Tickets[0]++;
                    ticketTextsp5[0].text = player5Tickets[0].ToString();
                    if (player5Tickets[0] >= 3)
                    {
                        p5VPs++;
                        p5ScoreText.text = "Player 5 Victory Points: " + p5VPs.ToString();
                    }
                }
                else
                {
                    player5Tickets[1]++;
                    ticketTextsp5[1].text = player5Tickets[1].ToString();
                    if (player5Tickets[1] >= 3)
                    {
                        p5VPs++;
                        p5ScoreText.text = "Player 5 Victory Points: " + p5VPs.ToString();
                    }
                }

                Actions.reduceActions();
                break;
            case 6:
                //TICKETS
                int ticketGained = 0;
                while (ticketGained == 0)
                {
                    ticketGained = ML_Algo.ML();
                }

                if (ticketGained == 1)
                {
                    player6Tickets[3]++;
                    ticketTextsp6[3].text = player6Tickets[3].ToString();
                    if (player6Tickets[3] >= 3)
                    {
                        p6VPs++;
                        p6ScoreText.text = "Player 6 Victory Points: " + p6VPs.ToString();
                    }
                }
                else if (ticketGained == 2)
                {
                    player6Tickets[2]++;
                    ticketTextsp6[2].text = player6Tickets[2].ToString();
                    if (player6Tickets[2] >= 3)
                    {
                        p6VPs++;
                        p6ScoreText.text = "Player 6 Victory Points: " + p6VPs.ToString();
                    }
                }
                else if (ticketGained == 3)
                {
                    player6Tickets[0]++;
                    ticketTextsp6[0].text = player6Tickets[0].ToString();
                    if (player6Tickets[0] >= 3)
                    {
                        p6VPs++;
                        p6ScoreText.text = "Player 6 Victory Points: " + p6VPs.ToString();
                    }
                }
                else
                {
                    player6Tickets[1]++;
                    ticketTextsp6[1].text = player6Tickets[1].ToString();
                    if (player6Tickets[1] >= 3)
                    {
                        p6VPs++;
                        p6ScoreText.text = "Player 6 Victory Points: " + p6VPs.ToString();
                    }
                }

                Actions.reduceActions();
                break;
            default:
                break;


        }


        playerMoves--;
        Debug.Log("Tickets");
    }

    public void ObjectClicked()
    {
        playerMoves--;
        Debug.Log("Objects");
    }

    public void MissionsClicked()
    {
        playerMoves--;
        Debug.Log("Missions");
    }


    public void SavePlayer()
    {
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

        //GlobalController.Instance.playerMoves = playerMoves;
        //GlobalController.Instance.turn = turn;

    }

}

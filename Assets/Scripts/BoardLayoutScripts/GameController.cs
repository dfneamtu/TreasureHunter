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

    public int p1VPs = 0;
    public int p2VPs = 0;
    public int p3VPs = 0;
    public int playerTurn = 1;

    //Player GameObjects to set true and false
    //[SerializeField]
    GameObject p1skills;
    GameObject p2skills;
    GameObject p3skills;
    GameObject p1tickets;
    GameObject p2tickets;
    GameObject p3tickets;
    GameObject BGp1;
    GameObject BGp2;
    GameObject BGp3;
    GameObject Skillsp1;
    GameObject Skillsp2;
    GameObject Skillsp3;
    GameObject Ticketsp1;
    GameObject Ticketsp2;
    GameObject Ticketsp3;
    GameObject movesLeftTag;
    GameObject p1VPsTag;
    GameObject p2VPsTag;
    GameObject p3VPsTag;

    //Player 1 Stats
    TMP_Text[] skillTextsp1 = new TMP_Text[8];
    static public int[] player1Values = new int[8];
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
        p1tickets = GameObject.Find("TicketsP1");
        p2tickets = GameObject.Find("TicketsP2");
        p3tickets = GameObject.Find("TicketsP3");
        BGp1 = GameObject.Find("img Background p1");
        BGp2 = GameObject.Find("img Background p2");
        BGp3 = GameObject.Find("img Background p3");
        Skillsp1 = GameObject.Find("P1Skills");
        Skillsp2 = GameObject.Find("P2Skills");
        Skillsp3 = GameObject.Find("P3Skills");
        Ticketsp1 = GameObject.Find("TicketsP1");
        Ticketsp2 = GameObject.Find("TicketsP2");
        Ticketsp3 = GameObject.Find("TicketsP3");
        movesLeftTag = GameObject.Find("MovesLeft");
        p1VPsTag = GameObject.Find("ScoreP1");
        p2VPsTag = GameObject.Find("ScoreP2");
        p3VPsTag = GameObject.Find("ScoreP3");

        movesLeft = movesLeftTag.transform.GetComponent<Text>();
        p1ScoreText = p1VPsTag.transform.GetComponent<TMP_Text>();
        p2ScoreText = p2VPsTag.transform.GetComponent<TMP_Text>();
        p3ScoreText = p3VPsTag.transform.GetComponent<TMP_Text>();

        for (int i = 0; i < 8; i++)
        {
            skillTextsp1[i] = Skillsp1.transform.GetChild(i).GetComponent<TMP_Text>();
            skillTextsp2[i] = Skillsp2.transform.GetChild(i).GetComponent<TMP_Text>();
            skillTextsp3[i] = Skillsp3.transform.GetChild(i).GetComponent<TMP_Text>();
        }

        for (int i = 0; i < 4; i++)
        {
            ticketTextsp1[i] = Ticketsp1.transform.GetChild(i).GetComponent<TMP_Text>();
            ticketTextsp2[i] = Ticketsp2.transform.GetChild(i).GetComponent<TMP_Text>();
            ticketTextsp3[i] = Ticketsp3.transform.GetChild(i).GetComponent<TMP_Text>();
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
        }

        for (int i = 0; i < 4; i++)
        {
            ticketTextsp1[i].text = player1Tickets[i].ToString();
            ticketTextsp2[i].text = player2Tickets[i].ToString();
            ticketTextsp3[i].text = player3Tickets[i].ToString();
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
        //Player 1 info to load
        player1Values = GlobalController.Instance.player1Values;
        player1Tickets = GlobalController.Instance.player1Tickets;

        //Player 2 info to load
        player2Values = GlobalController.Instance.player2Values;
        player2Tickets = GlobalController.Instance.player2Tickets;

        //Player 3 info to load
        player3Values = GlobalController.Instance.player3Values;
        player3Tickets = GlobalController.Instance.player3Tickets;

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
                p1skills.gameObject.SetActive(false);
                p3skills.gameObject.SetActive(true);
                p1tickets.gameObject.SetActive(false);
                p3tickets.gameObject.SetActive(true);
                BGp1.gameObject.SetActive(false);
                BGp3.gameObject.SetActive(true);
                break;

            case 2:
                //Console.WriteLine("Case 2");
                p2skills.gameObject.SetActive(true);
                p3skills.gameObject.SetActive(false);
                p2tickets.gameObject.SetActive(true);
                p3tickets.gameObject.SetActive(false);
                BGp2.gameObject.SetActive(true);
                BGp3.gameObject.SetActive(false);
                break;

            case 3:
                //oOoo
                p3skills.gameObject.SetActive(true);
                p2skills.gameObject.SetActive(false);
                p3tickets.gameObject.SetActive(true);
                p2tickets.gameObject.SetActive(false);
                BGp3.gameObject.SetActive(true);
                BGp2.gameObject.SetActive(false);
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
            if (playerTurn == 3)
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

        if (playerTurn == 1)
        {
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

        }
        else if (playerTurn == 2)
        {
            //SKILLS

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
        }
        else if (playerTurn == 3)
        {

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
        }

        Debug.Log("Skills");
        playerMoves--;

    }

    public void TicketClicked()
    {
        CheckPlayerTurn();

        if (playerTurn == 1)
        {
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
        }
        else if (playerTurn == 2)
        {
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
        }
        else if (playerTurn == 3)
        {
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

        //GlobalController.Instance.playerMoves = playerMoves;
        //GlobalController.Instance.turn = turn;

    }

}

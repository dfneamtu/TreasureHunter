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
    public TMP_Text[] skillTextsp1 = new TMP_Text[8];
    public TMP_Text[] skillTextsp2 = new TMP_Text[8];
    public int[] player1Values = new int[8];
    public int[] player2Values = new int[8];

    public TMP_Text[] ticketTextsp1 = new TMP_Text[4];
    public TMP_Text[] ticketTextsp2 = new TMP_Text[4];

    public TMP_Text p1ScoreText;
    public TMP_Text p2ScoreText;

    public int p1VPs = 0;
    public int p2VPs = 0;

    //Player GameObjects to set true and false
    public GameObject p1skills;
    public GameObject p2skills;
    public GameObject p1tickets;
    public GameObject p2tickets;
    public GameObject BGp1;
    public GameObject BGp2;

    //Player 1 Stats
    int player1Skills = 0;
    int player1Tickets = 0;

    //Player 1 Tickets
    public int p1BoatTickets = 0;
    public int p1PlaneTickets = 0;
    public int p1RoadTickets = 0;
    public int p1TrainTickets = 0;

    //Player2 Stats
    int player2Skills = 0;

    int player2Tickets = 0;

    //Player 2 Tickets
    public int p2BoatTickets = 0;
    public int p2PlaneTickets = 0;
    public int p2RoadTickets = 0;
    public int p2TrainTickets = 0;

    //Moves left
    public int playerMoves = 3;

    public Text movesLeft;

    //false = Player 1 Turn | true = Player 2 Turn
    public bool turn = false;

    //public int turn = 1;

    void UpdateUIStats()
    {
        movesLeft.text = playerMoves.ToString();
    }

    void Awake()
    {
        p1skills = GameObject.Find("P1Skills");
        p2skills = GameObject.Find("P2Skills");
        p1tickets = GameObject.Find("TicketsP1");
        p2tickets = GameObject.Find("TicketsP2");
        BGp1 = GameObject.Find("img Background p1");
        BGp2 = GameObject.Find("img Background p2");
    }

    void Start()
    {

        for (int i = 0; i < 8; i++)
        {
            skillTextsp1[i].text = 0.ToString();
            skillTextsp2[i].text = 0.ToString();
            player1Values[i] = 0;
            player2Values[i] = 0;

        }

        for (int i = 0; i < 4; i++)
        {
            ticketTextsp1[i].text = 0.ToString();
            ticketTextsp2[i].text = 0.ToString();
        }

        CheckPlayerTurn();
    }

    private void Update()
    {
        CheckPlayerTurn();

        if (p1VPs == 6)
        {
            PlayerOneWin();
        }

        if (p2VPs == 6)
        {
            PlayerTwoWin();
        }


        ////Player 1 info to load
        //player1Values = GlobalController.Instance.player1Values;
        //p1BoatTickets = GlobalController.Instance.p1BoatTickets;
        //p1PlaneTickets = GlobalController.Instance.p1PlaneTickets;
        //p1RoadTickets = GlobalController.Instance.p1RoadTickets;
        //p1TrainTickets = GlobalController.Instance.p1TrainTickets;

        ////Player 2 info to load
        //player2Values = GlobalController.Instance.player2Values;
        //p2BoatTickets = GlobalController.Instance.p2BoatTickets;
        //p2PlaneTickets = GlobalController.Instance.p2PlaneTickets;
        //p2RoadTickets = GlobalController.Instance.p2RoadTickets;
        //p2TrainTickets = GlobalController.Instance.p2TrainTickets;


        //Gameplay variables to load
        //playerMoves = GlobalController.Instance.playerMoves;
        //turn = GlobalController.Instance.turn;

        ////UI components to load
        //skillTextsp1 = GlobalController.Instance.skillTextsp1;
        //skillTextsp2 = GlobalController.Instance.skillTextsp2;

        //ticketTextsp1 = GlobalController.Instance.ticketTextsp1;
        //ticketTextsp2 = GlobalController.Instance.ticketTextsp2;

        //p1skills = GlobalController.Instance.p1skills;
        //p2skills = GlobalController.Instance.p2skills;
        //p1tickets = GlobalController.Instance.p1tickets;
        //p2tickets = GlobalController.Instance.p2tickets;
        //BGp1 = GlobalController.Instance.BGp1;
        //BGp2 = GlobalController.Instance.BGp2;

        //movesLeft = GlobalController.Instance.movesLeft;
        //mainCamera = GlobalController.Instance.mainCamera;

        //p1skills = GameObject.Find("P1Skills");
        //p2skills = GameObject.Find("P2Skills");
        //p1tickets = GameObject.Find("TicketsP1");
        //p2tickets = GameObject.Find("TicketsP2");
        //BGp1 = GameObject.Find("img Background p1");
        //BGp2 = GameObject.Find("img Background p2");
    }

    void playerGmo()
    {
        if (turn)
        {
            turn = true;            
            p1skills.gameObject.SetActive(false);
            p2skills.gameObject.SetActive(true);
            p1tickets.gameObject.SetActive(false);
            p2tickets.gameObject.SetActive(true);
            BGp1.gameObject.SetActive(false);
            BGp2.gameObject.SetActive(true);
        }
        else
        {
            turn = false;
            p1skills.gameObject.SetActive(true);
            p2skills.gameObject.SetActive(false);
            p1tickets.gameObject.SetActive(true);
            p2tickets.gameObject.SetActive(false);
            BGp1.gameObject.SetActive(true);
            BGp2.gameObject.SetActive(false);
        }
    }

    void CheckPlayerTurn()
    {
        if (playerMoves == 0)
        {

            turn = !turn;
            playerMoves = 3;
        }
        playerGmo();
        player1Tickets = 0;
        player2Tickets = 0;
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

        if (turn)
        {
            int skillToLevel = Random.Range(0, 8);
            int experienceGained = ML_Algo.ML();
            //Actions.reduceActions();
            player2Values[skillToLevel] += experienceGained;
            skillTextsp2[skillToLevel].text = player2Values[skillToLevel].ToString();

            if (player2Values[skillToLevel] > 4)
            {
                p2VPs++;
                p2ScoreText.text = "Player 2 Victory Points: " + p2VPs.ToString();
            }

        }
        else
        {
            //SKILLS

            int skillToLevel = Random.Range(0, 8);
            int experienceGained = ML_Algo.ML();
            Actions.reduceActions();

            player1Values[skillToLevel] += experienceGained;
            skillTextsp1[skillToLevel].text = player1Values[skillToLevel].ToString();

            if (player1Values[skillToLevel] > 4)
            {
                p1VPs++;
                p1ScoreText.text = "Player 1 Victory Points: " + p1VPs.ToString();
            }
        }

        Debug.Log("Skills");
        playerMoves--;

    }

    public void TicketClicked()
    {
        CheckPlayerTurn();

        if (turn)
        {
            //TICKETS
            int ticketGained = 0;
            while (ticketGained == 0)
            {
                ticketGained = ML_Algo.ML();
            }

            if (ticketGained == 1)
            {
                p2RoadTickets++;
                ticketTextsp2[3].text = p2RoadTickets.ToString();
                if (p2RoadTickets >= 3)
                {
                    p2VPs++;
                    p2ScoreText.text = "Player 2 Victory Points: " + p2VPs.ToString();
                }
            }
            else if (ticketGained == 2)
            {
                p2TrainTickets++;
                ticketTextsp2[2].text = p2TrainTickets.ToString();
                if (p2TrainTickets >= 3)
                {
                    p2VPs++;
                    p2ScoreText.text = "Player 2 Victory Points: " + p2VPs.ToString();
                }
            }
            else if (ticketGained == 3)
            {
                p2BoatTickets++;
                ticketTextsp2[0].text = p2BoatTickets.ToString();
                if (p2BoatTickets >= 3)
                {
                    p2VPs++;
                    p2ScoreText.text = "Player 2 Victory Points: " + p2VPs.ToString();
                }
            }
            else
            {
                p2PlaneTickets++;
                ticketTextsp2[1].text = p2PlaneTickets.ToString();
                if (p2PlaneTickets >= 3)
                {
                    p2VPs++;
                    p2ScoreText.text = "Player 2 Victory Points: " + p2VPs.ToString();
                }
            }

            Actions.reduceActions();
        } else
        {
            //TICKETS
            int ticketGained = 0;
            while (ticketGained == 0)
            {
                ticketGained = ML_Algo.ML();
            }

            if (ticketGained == 1)
            {
                p1RoadTickets++;
                ticketTextsp1[3].text = p1RoadTickets.ToString();
                if (p1RoadTickets >= 3)
                {
                    p1VPs++;
                    p1ScoreText.text = "Player 1 Victory Points: " + p1VPs.ToString();
                }
            }
            else if (ticketGained == 2)
            {
                p1TrainTickets++;
                ticketTextsp1[2].text = p1TrainTickets.ToString();
                if (p1TrainTickets >= 3)
                {
                    p1VPs++;
                    p1ScoreText.text = "Player 1 Victory Points: " + p1VPs.ToString();
                }
            }
            else if (ticketGained == 3)
            {
                p1BoatTickets++;
                ticketTextsp1[0].text = p1BoatTickets.ToString();
                if (p1BoatTickets >= 3)
                {
                    p1VPs++;
                    p1ScoreText.text = "Player 1 Victory Points: " + p1VPs.ToString();
                }
            }
            else
            {
                p1PlaneTickets++;
                ticketTextsp1[1].text = p1PlaneTickets.ToString();
                if (p1PlaneTickets >= 3)
                {
                    p1VPs++;
                    p1ScoreText.text = "Player 1 Victory Points: " + p1VPs.ToString();
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

    //public void SavePlayer()
    //{
    //    //Player 1 info to save
    //    GlobalController.Instance.player1Values = player1Values;
    //    GlobalController.Instance.p1BoatTickets = p1BoatTickets;
    //    GlobalController.Instance.p1PlaneTickets = p1PlaneTickets;
    //    GlobalController.Instance.p1RoadTickets = p1RoadTickets;
    //    GlobalController.Instance.p1TrainTickets = p1TrainTickets;

    //    //Player 2 info to save
    //    GlobalController.Instance.player2Values = player2Values;
    //    GlobalController.Instance.p2BoatTickets = p2BoatTickets;
    //    GlobalController.Instance.p2PlaneTickets = p2PlaneTickets;
    //    GlobalController.Instance.p2RoadTickets = p2RoadTickets;
    //    GlobalController.Instance.p2TrainTickets = p2TrainTickets;


    //    //GlobalController.Instance.playerMoves = playerMoves;
    //    //GlobalController.Instance.turn = turn;

    //    ////UI variables to save
    //    //GlobalController.Instance.skillTextsp1 = skillTextsp1;
    //    //GlobalController.Instance.skillTextsp2 = skillTextsp2;

    //    //GlobalController.Instance.ticketTextsp1 = ticketTextsp1;
    //    //GlobalController.Instance.ticketTextsp2 = ticketTextsp2;

    //    //GlobalController.Instance.p1skills = p1skills;
    //    //GlobalController.Instance.p2skills = p2skills;
    //    //GlobalController.Instance.p1tickets = p1tickets;
    //    //GlobalController.Instance.p2tickets = p2tickets;
    //    //GlobalController.Instance.BGp1 = BGp1;
    //    //GlobalController.Instance.BGp2 = BGp2;

    //    //GlobalController.Instance.movesLeft = movesLeft;
    //    //GlobalController.Instance.mainCamera = mainCamera;

    //}

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using TMPro;
using UnityEngine.SceneManagement;

public class playerLocation : MonoBehaviour
{

    public GameObject TargetCrosshairs1;
    public GameObject TargetCrosshairs2;
    public GameObject TargetCrosshairs3;
    public GameObject TargetCrosshairs4;
    public GameObject TargetCrosshairs5;
    public GameObject TargetCrosshairs6;
    public GameObject TargetCrosshairs7;
    public GameObject TargetCrosshairs8;
    public GameObject TargetCrosshairs9;
    public GameObject TargetCrosshairs10;

    public GameObject p1tickets;
    public GameObject p2tickets;
    public GameObject p3tickets;
    public GameObject p4tickets;
    public GameObject p5tickets;
    public GameObject p6tickets;

    public GameObject Ticketsp1;
    public GameObject Ticketsp2;
    public GameObject Ticketsp3;
    public GameObject Ticketsp4;
    public GameObject Ticketsp5;
    public GameObject Ticketsp6;

    public GameObject BGp1;
    public GameObject BGp2;
    public GameObject BGp3;
    public GameObject BGp4;
    public GameObject BGp5;
    public GameObject BGp6;

    //Player 1 Stats
    TMP_Text[] ticketTextsp1 = new TMP_Text[4];
    public int[] player1Tickets = new int[4];

    //Player2 Stats
    TMP_Text[] ticketTextsp2 = new TMP_Text[4];
    public int[] player2Tickets = new int[4];

    //Player3 Stats
    TMP_Text[] ticketTextsp3 = new TMP_Text[4];
    public int[] player3Tickets = new int[4];

    //Player4 Stats
    TMP_Text[] ticketTextsp4 = new TMP_Text[4];
    public int[] player4Tickets = new int[4];

    //Player5 Stats
    TMP_Text[] ticketTextsp5 = new TMP_Text[4];
    public int[] player5Tickets = new int[4];

    //Player6 Stats
    TMP_Text[] ticketTextsp6 = new TMP_Text[4];
    public int[] player6Tickets = new int[4];

    public Transform[] spawnPoint;

    public int playerTurnTickets;

    public int[] pLocation = new int[6];
    public int[] hubLocation = new int[6];

    void Awake()
    {
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

    private void Update()
    {

        for (int i = 0; i < 4; i++)
        {
            ticketTextsp1[i].text = player1Tickets[i].ToString();
            ticketTextsp2[i].text = player2Tickets[i].ToString();
            ticketTextsp3[i].text = player3Tickets[i].ToString();
            ticketTextsp4[i].text = player4Tickets[i].ToString();
            ticketTextsp5[i].text = player5Tickets[i].ToString();
            ticketTextsp6[i].text = player6Tickets[i].ToString();
        }

        //GameController.CheckPlayerTurn();

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

        playerGmo();
    }


    void Start()
    {
        playerTurnTickets = GameController.playerTurn;
    }

    void playerGmo()
    {
        switch (playerTurnTickets)
        {
            case 1:

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

    public void Location1()
    {

        switch (playerTurnTickets)
        {
            case 1:
                hubLocation[0] = 1;
                pLocation[0] = 1;
                break;
            case 2:
                hubLocation[1] = 1;
                pLocation[1] = 1;
                break;
            case 3:
                hubLocation[2] = 1;
                pLocation[2] = 1;
                break;
            case 4:
                hubLocation[3] = 1;
                pLocation[3] = 1;
                break;
            case 5:
                hubLocation[4] = 1;
                pLocation[4] = 1;
                break;
            case 6:
                hubLocation[5] = 1;
                pLocation[5] = 1;
                break;
            default:
                //Console.WriteLine("Default case");
                break;
        }        

        TargetCrosshairs1.gameObject.SetActive(true);
        TargetCrosshairs2.gameObject.SetActive(false);
        TargetCrosshairs3.gameObject.SetActive(false);
        TargetCrosshairs4.gameObject.SetActive(false);
        TargetCrosshairs5.gameObject.SetActive(false);
        TargetCrosshairs6.gameObject.SetActive(false);
        TargetCrosshairs7.gameObject.SetActive(false);
        TargetCrosshairs8.gameObject.SetActive(false);
        TargetCrosshairs9.gameObject.SetActive(false);
        TargetCrosshairs10.gameObject.SetActive(false);

        Debug.Log("1");
    }
    public void Location2()
    {


        switch (playerTurnTickets)
        {
            case 1:
                hubLocation[0] = 1;
                pLocation[0] = 2;
                break;
            case 2:
                hubLocation[1] = 1;
                pLocation[1] = 2;
                break;
            case 3:
                hubLocation[1] = 1;
                pLocation[2] = 2;
                break;
            case 4:
                hubLocation[1] = 1;
                pLocation[3] = 2;
                break;
            case 5:
                hubLocation[1] = 1;
                pLocation[4] = 2;
                break;
            case 6:
                hubLocation[1] = 1;
                pLocation[5] = 2;
                break;
            default:
                //Console.WriteLine("Default case");
                break;
        }

        TargetCrosshairs1.gameObject.SetActive(false);
        TargetCrosshairs2.gameObject.SetActive(true);
        TargetCrosshairs3.gameObject.SetActive(false);
        TargetCrosshairs4.gameObject.SetActive(false);
        TargetCrosshairs5.gameObject.SetActive(false);
        TargetCrosshairs6.gameObject.SetActive(false);
        TargetCrosshairs7.gameObject.SetActive(false);
        TargetCrosshairs8.gameObject.SetActive(false);
        TargetCrosshairs9.gameObject.SetActive(false);
        TargetCrosshairs10.gameObject.SetActive(false);

        Debug.Log("2");
    }
    public void Location3()
    {


        switch (playerTurnTickets)
        {
            case 1:
                hubLocation[0] = 1;
                pLocation[0] = 3;
                break;
            case 2:
                hubLocation[1] = 1;
                pLocation[1] = 3;
                break;
            case 3:
                hubLocation[2] = 1;
                pLocation[2] = 3;
                break;
            case 4:
                hubLocation[3] = 1;
                pLocation[3] = 3;
                break;
            case 5:
                hubLocation[4] = 1;
                pLocation[4] = 3;
                break;
            case 6:
                hubLocation[5] = 1;
                pLocation[5] = 3;
                break;
            default:
                //Console.WriteLine("Default case");
                break;
        }


        TargetCrosshairs1.gameObject.SetActive(false);
        TargetCrosshairs2.gameObject.SetActive(false);
        TargetCrosshairs3.gameObject.SetActive(true);
        TargetCrosshairs4.gameObject.SetActive(false);
        TargetCrosshairs5.gameObject.SetActive(false);
        TargetCrosshairs6.gameObject.SetActive(false);
        TargetCrosshairs7.gameObject.SetActive(false);
        TargetCrosshairs8.gameObject.SetActive(false);
        TargetCrosshairs9.gameObject.SetActive(false);
        TargetCrosshairs10.gameObject.SetActive(false);

        Debug.Log("3");
    }
    public void Location4()
    {


        switch (playerTurnTickets)
        {
            case 1:
                hubLocation[0] = 1;
                pLocation[0] = 4;
                break;
            case 2:
                hubLocation[1] = 1;
                pLocation[1] = 4;
                break;
            case 3:
                hubLocation[2] = 1;
                pLocation[2] = 4;
                break;
            case 4:
                hubLocation[3] = 1;
                pLocation[3] = 4;
                break;
            case 5:
                hubLocation[4] = 1;
                pLocation[4] = 4;
                break;
            case 6:
                hubLocation[5] = 1;
                pLocation[5] = 4;
                break;
            default:
                //Console.WriteLine("Default case");
                break;
        }

        TargetCrosshairs1.gameObject.SetActive(false);
        TargetCrosshairs2.gameObject.SetActive(false);
        TargetCrosshairs3.gameObject.SetActive(false);
        TargetCrosshairs4.gameObject.SetActive(true);
        TargetCrosshairs5.gameObject.SetActive(false);
        TargetCrosshairs6.gameObject.SetActive(false);
        TargetCrosshairs7.gameObject.SetActive(false);
        TargetCrosshairs8.gameObject.SetActive(false);
        TargetCrosshairs9.gameObject.SetActive(false);
        TargetCrosshairs10.gameObject.SetActive(false);
        Debug.Log("4");
    }
    public void Location5()
    {


        switch (playerTurnTickets)
        {
            case 1:
                hubLocation[0] = 1;
                pLocation[0] = 5;
                break;
            case 2:
                hubLocation[1] = 1;
                pLocation[1] = 5;
                break;
            case 3:
                hubLocation[2] = 1;
                pLocation[2] = 5;
                break;
            case 4:
                hubLocation[3] = 1;
                pLocation[3] = 5;
                break;
            case 5:
                hubLocation[4] = 1;
                pLocation[4] = 5;
                break;
            case 6:
                hubLocation[5] = 1;
                pLocation[5] = 5;
                break;
            default:
                //Console.WriteLine("Default case");
                break;
        }        

        TargetCrosshairs1.gameObject.SetActive(false);
        TargetCrosshairs2.gameObject.SetActive(false);
        TargetCrosshairs3.gameObject.SetActive(false);
        TargetCrosshairs4.gameObject.SetActive(false);
        TargetCrosshairs5.gameObject.SetActive(true);
        TargetCrosshairs6.gameObject.SetActive(false);
        TargetCrosshairs7.gameObject.SetActive(false);
        TargetCrosshairs8.gameObject.SetActive(false);
        TargetCrosshairs9.gameObject.SetActive(false);
        TargetCrosshairs10.gameObject.SetActive(false);
        Debug.Log("5");
    }
    public void Location6()
    {

        switch (playerTurnTickets)
        {
            case 1:
                hubLocation[0] = 1;
                pLocation[0] = 6;
                break;
            case 2:
                hubLocation[1] = 1;
                pLocation[1] = 6;
                break;
            case 3:
                hubLocation[2] = 1;
                pLocation[2] = 6;
                break;
            case 4:
                hubLocation[3] = 1;
                pLocation[3] = 6;
                break;
            case 5:
                hubLocation[4] = 1;
                pLocation[4] = 6;
                break;
            case 6:
                hubLocation[5] = 1;
                pLocation[5] = 6;
                break;
            default:
                //Console.WriteLine("Default case");
                break;
        }

        TargetCrosshairs1.gameObject.SetActive(false);
        TargetCrosshairs2.gameObject.SetActive(false);
        TargetCrosshairs3.gameObject.SetActive(false);
        TargetCrosshairs4.gameObject.SetActive(false);
        TargetCrosshairs5.gameObject.SetActive(false);
        TargetCrosshairs6.gameObject.SetActive(true);
        TargetCrosshairs7.gameObject.SetActive(false);
        TargetCrosshairs8.gameObject.SetActive(false);
        TargetCrosshairs9.gameObject.SetActive(false);
        TargetCrosshairs10.gameObject.SetActive(false);
        Debug.Log("6");
    }
    public void Location7()
    {


        switch (playerTurnTickets)
        {
            case 1:
                hubLocation[0] = 1;
                pLocation[0] = 7;
                break;
            case 2:
                hubLocation[1] = 1;
                pLocation[1] = 7;
                break;
            case 3:
                hubLocation[2] = 1;
                pLocation[2] = 7;
                break;
            case 4:
                hubLocation[3] = 1;
                pLocation[3] = 7;
                break;
            case 5:
                hubLocation[4] = 1;
                pLocation[4] = 7;
                break;
            case 6:
                hubLocation[5] = 1;
                pLocation[5] = 7;
                break;
            default:
                //Console.WriteLine("Default case");
                break;
        }        

        TargetCrosshairs1.gameObject.SetActive(false);
        TargetCrosshairs2.gameObject.SetActive(false);
        TargetCrosshairs3.gameObject.SetActive(false);
        TargetCrosshairs4.gameObject.SetActive(false);
        TargetCrosshairs5.gameObject.SetActive(false);
        TargetCrosshairs6.gameObject.SetActive(false);
        TargetCrosshairs7.gameObject.SetActive(true);
        TargetCrosshairs8.gameObject.SetActive(false);
        TargetCrosshairs9.gameObject.SetActive(false);
        TargetCrosshairs10.gameObject.SetActive(false); 
        Debug.Log("7");
    }
    public void Location8()
    {


        switch (playerTurnTickets)
        {
            case 1:
                hubLocation[0] = 1;
                pLocation[0] = 8;
                break;
            case 2:
                hubLocation[2] = 1;
                pLocation[1] = 8;
                break;
            case 3:
                hubLocation[3] = 1;
                pLocation[2] = 8;
                break;
            case 4:
                hubLocation[4] = 1;
                pLocation[3] = 8;
                break;
            case 5:
                hubLocation[5] = 1;
                pLocation[4] = 8;
                break;
            case 6:
                hubLocation[6] = 1;
                pLocation[5] = 8;
                break;
            default:
                //Console.WriteLine("Default case");
                break;
        }

        TargetCrosshairs1.gameObject.SetActive(false);
        TargetCrosshairs2.gameObject.SetActive(false);
        TargetCrosshairs3.gameObject.SetActive(false);
        TargetCrosshairs4.gameObject.SetActive(false);
        TargetCrosshairs5.gameObject.SetActive(false);
        TargetCrosshairs6.gameObject.SetActive(false);
        TargetCrosshairs7.gameObject.SetActive(false);
        TargetCrosshairs8.gameObject.SetActive(true);
        TargetCrosshairs9.gameObject.SetActive(false);
        TargetCrosshairs10.gameObject.SetActive(false);

        Debug.Log("8");
    }

    public void Location9()
    {


        switch (playerTurnTickets)
        {
            case 1:
                hubLocation[0] = 1;
                pLocation[0] = 9;
                break;
            case 2:
                hubLocation[1] = 1;
                pLocation[1] = 9;
                break;
            case 3:
                hubLocation[2] = 1;
                pLocation[2] = 9;
                break;
            case 4:
                hubLocation[3] = 1;
                pLocation[3] = 9;
                break;
            case 5:
                hubLocation[4] = 1;
                pLocation[4] = 9;
                break;
            case 6:
                hubLocation[5] = 1;
                pLocation[5] = 9;
                break;
            default:
                //Console.WriteLine("Default case");
                break;
        }
        TargetCrosshairs1.gameObject.SetActive(false);
        TargetCrosshairs2.gameObject.SetActive(false);
        TargetCrosshairs3.gameObject.SetActive(false);
        TargetCrosshairs4.gameObject.SetActive(false);
        TargetCrosshairs5.gameObject.SetActive(false);
        TargetCrosshairs6.gameObject.SetActive(false);
        TargetCrosshairs7.gameObject.SetActive(false);
        TargetCrosshairs8.gameObject.SetActive(false);
        TargetCrosshairs9.gameObject.SetActive(true);
        TargetCrosshairs10.gameObject.SetActive(false);

        Debug.Log("9");
    }

    public void Location10()
    {


        switch (playerTurnTickets)
        {
            case 1:
                hubLocation[0] = 1;
                pLocation[0] = 10;

                break;
            case 2:

                hubLocation[1] = 1;
                pLocation[1] = 10;
                break;
            case 3:
                hubLocation[2] = 1;
                pLocation[2] = 10;
                break;
            case 4:
                hubLocation[3] = 1;
                pLocation[3] = 10;
                break;
            case 5:
                hubLocation[4] = 1;
                pLocation[4] = 10;
                break;
            case 6:
                hubLocation[5] = 1;
                pLocation[5] = 10;
                break;
            default:
                //Console.WriteLine("Default case");
                break;
        }

        TargetCrosshairs1.gameObject.SetActive(false);
        TargetCrosshairs2.gameObject.SetActive(false);
        TargetCrosshairs3.gameObject.SetActive(false);
        TargetCrosshairs4.gameObject.SetActive(false);
        TargetCrosshairs5.gameObject.SetActive(false);
        TargetCrosshairs6.gameObject.SetActive(false);
        TargetCrosshairs7.gameObject.SetActive(false);
        TargetCrosshairs8.gameObject.SetActive(false);
        TargetCrosshairs9.gameObject.SetActive(false);
        TargetCrosshairs10.gameObject.SetActive(true);

        Debug.Log("10");
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

        GlobalController.Instance.hubLocation = hubLocation;
        GlobalController.Instance.pLocation = pLocation;
        //GlobalController.Instance.playerTurn = playerTurn;
        //GlobalController.Instance.playerMoves = playerMoves;
        //GlobalController.Instance.turn = turn;

    }
}

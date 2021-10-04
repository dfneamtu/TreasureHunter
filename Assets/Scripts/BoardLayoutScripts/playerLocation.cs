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

    public Sprite[] PlayerBGs;
    public SpriteRenderer playerbgs;

    public Sprite[] HubLocations;
    public SpriteRenderer spriteRenderer;

    public Text playerMoves;

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
    public int playerMovesLeft;

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

        playerMoves.text = (playerMovesLeft - 1).ToString();

        playerGmo();

        if (hubLocation[playerTurnTickets - 1] == 1)
        {
            spriteRenderer.sprite = HubLocations[0];
        }

        if (hubLocation[playerTurnTickets - 1] == 2)
        {
            spriteRenderer.sprite = HubLocations[1];
        }

        if (hubLocation[playerTurnTickets - 1] == 3)
        {
            spriteRenderer.sprite = HubLocations[2];
        }

    }


    void Start()
    {
        playerTurnTickets = GameController.playerTurn;
        playerMovesLeft = GameController.playerMoves;


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

                playerbgs.sprite = PlayerBGs[0];

                break;

            case 2:

                p1tickets.gameObject.SetActive(false);
                p2tickets.gameObject.SetActive(true);
                p3tickets.gameObject.SetActive(false);
                p4tickets.gameObject.SetActive(false);
                p5tickets.gameObject.SetActive(false);
                p6tickets.gameObject.SetActive(false);

                playerbgs.sprite = PlayerBGs[1];

                break;

            case 3:

                p1tickets.gameObject.SetActive(false);
                p2tickets.gameObject.SetActive(false);
                p3tickets.gameObject.SetActive(true);
                p4tickets.gameObject.SetActive(false);
                p5tickets.gameObject.SetActive(false);
                p6tickets.gameObject.SetActive(false);

                playerbgs.sprite = PlayerBGs[2];

                break;

            case 4:

                p1tickets.gameObject.SetActive(false);
                p2tickets.gameObject.SetActive(false);
                p3tickets.gameObject.SetActive(false);
                p4tickets.gameObject.SetActive(true);
                p5tickets.gameObject.SetActive(false);
                p6tickets.gameObject.SetActive(false);

                playerbgs.sprite = PlayerBGs[3];

                break;

            case 5:

                p1tickets.gameObject.SetActive(false);
                p2tickets.gameObject.SetActive(false);
                p3tickets.gameObject.SetActive(false);
                p4tickets.gameObject.SetActive(false);
                p5tickets.gameObject.SetActive(true);
                p6tickets.gameObject.SetActive(false);

                playerbgs.sprite = PlayerBGs[4];

                break;

            case 6:

                p1tickets.gameObject.SetActive(false);
                p2tickets.gameObject.SetActive(false);
                p3tickets.gameObject.SetActive(false);
                p4tickets.gameObject.SetActive(false);
                p5tickets.gameObject.SetActive(false);
                p6tickets.gameObject.SetActive(true);

                playerbgs.sprite = PlayerBGs[5];

                break;

            default:
                //Console.WriteLine("Default case");
                break;
        }
    }

    public void Location1()
    {
        hubLocation[playerTurnTickets - 1] = 1;
        pLocation[playerTurnTickets - 1] = 1;

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
        hubLocation[playerTurnTickets - 1] = 1;
        pLocation[playerTurnTickets - 1] = 2;

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
        hubLocation[playerTurnTickets - 1] = 1;
        pLocation[playerTurnTickets - 1] = 3;

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

        hubLocation[playerTurnTickets - 1] = 1;
        pLocation[playerTurnTickets - 1] = 4;

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
        hubLocation[playerTurnTickets - 1] = 1;
        pLocation[playerTurnTickets - 1] = 5;

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

        hubLocation[playerTurnTickets - 1] = 1;
        pLocation[playerTurnTickets - 1] = 6;

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

        hubLocation[playerTurnTickets - 1] = 1;
        pLocation[playerTurnTickets - 1] = 7;

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

        hubLocation[playerTurnTickets - 1] = 1;
        pLocation[playerTurnTickets - 1] = 8;

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
        hubLocation[playerTurnTickets - 1] = 1;
        pLocation[playerTurnTickets - 1] = 9;

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
        hubLocation[playerTurnTickets - 1] = 1;
        pLocation[playerTurnTickets - 1] = 10;

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

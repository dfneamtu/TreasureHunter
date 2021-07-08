using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using TMPro;
using UnityEngine.SceneManagement;

public class GlobalController : MonoBehaviour
{
    public static GlobalController Instance;

    //Player 1 Info
    public TMP_Text[] skillTextsp1 = new TMP_Text[8];
    public int[] player1Values = new int[8]; //Skills

    public TMP_Text[] ticketTextsp1 = new TMP_Text[4];
    public int p1BoatTickets = 0;
    public int p1PlaneTickets = 0;
    public int p1RoadTickets = 0;
    public int p1TrainTickets = 0;

    //Player 2 Info
    public TMP_Text[] skillTextsp2 = new TMP_Text[8];
    public int[] player2Values = new int[8]; //Skills

    public TMP_Text[] ticketTextsp2 = new TMP_Text[4];
    public int p2BoatTickets = 0;
    public int p2PlaneTickets = 0;
    public int p2RoadTickets = 0;
    public int p2TrainTickets = 0;

    //public int playerMoves = 3;
    //public bool turn = false;

    //public GameObject p1skills;
    //public GameObject p2skills;
    //public GameObject p1tickets;
    //public GameObject p2tickets;
    //public GameObject BGp1;
    //public GameObject BGp2;

    //public Text movesLeft;
    //public GameObject mainCamera;

    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}

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
    public int[] counters = new int[6];
    public List<int> turnOrder = new List<int>();

    public string[] playersItemTxt = new string[6];
    public string[] playersObjItemTxt = new string[6];
    public string[] playersAmountTxt = new string[6];
    public string[] playersObjAmountTxt = new string[6];
    public string[] playersTypeTxt = new string[6];

    public string[] playerObjects = new string[6];
    //Player 1 Info
    //public TMP_Text[] skillTextsp1 = new TMP_Text[8];
    public int[] player1Values = new int[8]; //Skills

    public int[] player1Tickets = new int[4];
    //public int playerTurn;
    //Player 2 Info
    //public TMP_Text[] skillTextsp2 = new TMP_Text[8];
    public int[] player2Values = new int[8]; //Skills

    public int[] player2Tickets = new int[4];

    //Player 3 Info
    //public TMP_Text[] skillTextsp2 = new TMP_Text[8];
    public int[] player3Values = new int[8]; //Skills

    public int[] player3Tickets = new int[4];

    //Player 4 Info
    //public TMP_Text[] skillTextsp2 = new TMP_Text[8];
    public int[] player4Values = new int[8]; //Skills

    public int[] player4Tickets = new int[4];
    //Player 5 Info
    //public TMP_Text[] skillTextsp2 = new TMP_Text[8];
    public int[] player5Values = new int[8]; //Skills

    public int[] player5Tickets = new int[4];
    //Player 6 Info
    //public TMP_Text[] skillTextsp2 = new TMP_Text[8];
    public int[] player6Values = new int[8]; //Skills

    public int[] player6Tickets = new int[4];

    public int[] hubLocation = new int[6];
    public int[] pLocation = new int[6];
    public int [] travelled = new int[6];

    public Text turnOrderTxt;
    public int turnIndex;

    //public List<Mission> missions = new List<Mission>();
    public Mission[] missions;
    public List<Enemy> enemies = new List<Enemy>();


    //public int playerTurn;
    //public int playerMoves;
    //public bool turn;

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

    public void Start()
    {
        for (int i = 0; i < 6; i++)
        {
            pLocation[i] = 1;
            hubLocation[i] = 1;
            counters[i] = 0;
        }
    }
}

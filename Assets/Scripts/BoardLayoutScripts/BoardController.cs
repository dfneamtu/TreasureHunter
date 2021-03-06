using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random=UnityEngine.Random;
using TMPro;
using UnityEngine.SceneManagement;

public class BoardController : MonoBehaviour
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

    //Size of the Map
    public int tileSizeX = 16, 
               tileSizeY = 16;

    //Map Array
    public int[,] tileMap;

    //Creates Board
    public BoardCreator boardCreator;

    //Player1 Position
    public int player1X, player1Y;
    public GameObject player1Pfb;

    //Player2 Position
    public int player2X, player2Y;
    public GameObject player2Pfb;

    //Player1 Stats
    GameObject player1;
    int player1Skills = 0;
    int player1Tickets = 0;

    //Player 1 Tickets
    public int p1BoatTickets = 0;
    public int p1PlaneTickets = 0;
    public int p1RoadTickets = 0;
    public int p1TrainTickets = 0;

    //Player2 Stats
    GameObject player2;
    int player2Skills = 0;

    int player2Tickets = 0;

    //Player 2 Tickets
    public int p2BoatTickets = 0;
    public int p2PlaneTickets = 0;
    public int p2RoadTickets = 0;
    public int p2TrainTickets = 0;

    Transform playerPosition;

    //Moves left
    public int playerMoves = 3;

    //Current Work in progress
    public GameObject highLightMovementPfb;
    List<GameObject> possibleList = new List<GameObject>();

    //false = Player 1 Turn | true = Player 2 Turn
    public bool turn = false;

    //Count of collectables
    int collectablesMax, collectablesQnty;

    public Text movesLeft;

    //Camera
    public GameObject mainCamera;
    CameraController mainCameraController;

    void UpdateUIStats()
    {
        movesLeft.text = playerMoves.ToString();
    }

    void Start()
    {
        //p1skills = GameObject.Find("P1Skills");
        //p2skills = GameObject.Find("P2Skills");
        //p1tickets = GameObject.Find("TicketsP1");
        //p2tickets = GameObject.Find("TicketsP2");
        //BGp1 = GameObject.Find("img Background p1");
        //BGp2 = GameObject.Find("img Background p2");

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

        mainCameraController = mainCamera.GetComponent<CameraController>();

        collectablesQnty = (tileSizeX * tileSizeY) - 2;
        collectablesMax = collectablesQnty;
        boardCreator = gameObject.GetComponent<BoardCreator>();
        tileMap = new int[tileSizeX, tileSizeY];
        PlayerAllocation();
        tileMap = boardCreator.CreateBoard(tileMap, player1.transform, player2.transform);
        Debug.Log(PrintMap(tileMap));
        CheckPlayerTurn();

    }

    private void Update()
    {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit raycastHit;
                if (Physics.Raycast(ray, out raycastHit))
                {
                    if (raycastHit.transform.CompareTag("PossiblePosition"))
                    {
                        Transform actualPosition = playerGmo().transform;
                        Transform intentPosition = raycastHit.transform;
                        CollectItem((int)intentPosition.position.z, (int)intentPosition.position.x);
                        BoardSetValue((int)raycastHit.transform.position.z, (int)intentPosition.position.x, tileMap[(int)actualPosition.position.z, (int)actualPosition.position.x]);
                        BoardSetValue((int)actualPosition.position.z, (int)actualPosition.position.x, 0);
                        playerGmo().transform.position = raycastHit.transform.position;
                        Ray collectableRay = new Ray(playerGmo().transform.position, Vector3.up);
                        RaycastHit collectableHit;
                        if (Physics.Raycast(collectableRay, out collectableHit))
                        {
                            if (collectableHit.transform.CompareTag("Button"))
                            {
                                Destroy(collectableHit.transform.parent.gameObject);
                                collectablesQnty--;
                            }
                        }
                        CheckCollectables();
                        playerMoves--;
                        UpdateUIStats();
                        CheckPlayerTurn();
                    }
                }
           }

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


    void PossibleMovements(int posX, int posY)
    {
        ClearPossibleMovesEffects();
        //Front Position Verification
        posX = posX + 1;
        
        if (posX< tileSizeX)
        {
            if ((tileMap[posX, posY] != 1 & tileMap[posX, posY] != 2))
            {
                possibleList.Add(Instantiate(highLightMovementPfb, new Vector3(posY, 0f, posX), Quaternion.identity));
            }            
        }

        //Back Position Verification
        posX = posX - 2;
        
        if (posX >= 0)
        {
            if ((tileMap[posX, posY] != 1 & tileMap[posX, posY] != 2))
            {
                possibleList.Add(Instantiate(highLightMovementPfb, new Vector3(posY, 0f, posX), Quaternion.identity));
            } 
        }

        //Right Position Verification
        posX = posX + 1;
        posY = posY + 1;
        
        if (posY < tileSizeY )
        {
            if (tileMap[posX, posY] != 1 & tileMap[posX, posY] != 2)
            {
                possibleList.Add(Instantiate(highLightMovementPfb, new Vector3(posY, 0f, posX), Quaternion.identity));
            }
        }
        //Left Position Verification
        posY = posY - 2;
        
        if (posY>= 0)
        {
            if ((tileMap[posX, posY] != 1 & tileMap[posX, posY] != 2))
            {
                possibleList.Add(Instantiate(highLightMovementPfb, new Vector3(posY, 0f, posX), Quaternion.identity));
            }   
        }
    }

    void CollectItem(int x, int y)
    {
        int ItemId = tileMap[x, y];
        if (ItemId == 3)
        {
            playerMoves++;

        }
        else
        {
            if (turn)
            {
            switch (ItemId)
                {

                    case 4:
                        //SKILLS

                        int skillToLevel = Random.Range(0, 8);
                        int experienceGained = ML_Algo.ML();
                        Actions.reduceActions();
                        player2Values[skillToLevel] += experienceGained;
                        skillTextsp2[skillToLevel].text = player2Values[skillToLevel].ToString();

                        if (player2Values[skillToLevel] > 4) 
                        {
                            p2VPs++;
                            p2ScoreText.text = "Player 2 Victory Points: " + p2VPs.ToString();
                        }

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
                        break;
                        

                        
                    case 6:
                        //OBJECTS



                        break;
                }
            } else
            {
            switch (ItemId)
                {
                    case 4:
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




                        break;
                    case 6:
                       //OBJECTS

                        break;
                }
            }
        }
    }

    void BoardSetValue(int x, int y, int value)
    {
        tileMap[x, y] = value;
    }

    string PrintMap(int[,] map)
    {

        string mapPrint = "\n";
        for (int x = 0; x < map.GetLength(0); x++)
        {
            for(int y = 0; y < map.GetLength(1); y++ )
            {
                mapPrint += ("[" + map[x,y] + "]");
            }
            mapPrint += ("\n");
        }
        return mapPrint;
    }

    void PlayerAllocation()
    {
        //Player1 Allocation
        player1 = Instantiate(player1Pfb, new Vector3(player1Y, 0f, player1X), Quaternion.identity);
        BoardSetValue(player1X, player1Y, 1);

        //Player2 Allocation
        player2 = Instantiate(player2Pfb, new Vector3(player2Y, 0f, player2X), Quaternion.Euler(0, 180f, 0));
        BoardSetValue(player2X, player2Y, 2);
        mainCameraController.FollowPlayer(playerGmo());
    }    

    GameObject playerGmo()
    {
        if (turn)
        {
            return player2;
        }
        else
        {
            return player1;
        }
    }

    void CheckPlayerTurn()
    {
        if(playerMoves == 0)
        {
            
            turn = !turn;
            playerMoves = 3;
        }

        player1Tickets = 0;
        player2Tickets = 0;
        playerPosition = playerGmo().transform;
        mainCameraController.FollowPlayer(playerGmo());
        PossibleMovements((int)playerPosition.position.z, (int)playerPosition.position.x);
        UpdateUIStats();

        if (turn == true)
        {
            p1skills.gameObject.SetActive(false);
            p2skills.gameObject.SetActive(true);
            p1tickets.gameObject.SetActive(false);
            p2tickets.gameObject.SetActive(true);
            BGp1.gameObject.SetActive(false);
            BGp2.gameObject.SetActive(true);
        }
        else if (turn == false)
        {
            p1skills.gameObject.SetActive(true);
            p2skills.gameObject.SetActive(false);
            p1tickets.gameObject.SetActive(true);
            p2tickets.gameObject.SetActive(false);
            BGp1.gameObject.SetActive(true);
            BGp2.gameObject.SetActive(false);
        }
    }

    void CheckCollectables()
    {
        
        if(collectablesQnty < collectablesMax*0.1)
        {
            tileMap = boardCreator.CollectablesAllocation(tileMap);
            collectablesQnty = collectablesMax;
        }
    }

    void ClearPossibleMovesEffects()
    {
        foreach (GameObject gameObject in possibleList)
        {
            Destroy(gameObject);
        }

        possibleList.Clear();
    }

    void PlayerOneWin()
    {
        SceneManager.LoadScene("PlayerOneWin");
    }

    void PlayerTwoWin()
    {
        SceneManager.LoadScene("PlayerTwoWins");
    }

    //public void SavePlayer()
    //{
    //    ////Player 1 info to save
    //    //GlobalController.Instance.player1Values = player1Values;
    //    //GlobalController.Instance.p1BoatTickets = p1BoatTickets;
    //    //GlobalController.Instance.p1PlaneTickets = p1PlaneTickets;
    //    //GlobalController.Instance.p1RoadTickets = p1RoadTickets;
    //    //GlobalController.Instance.p1TrainTickets = p1TrainTickets;

    //    ////Player 2 info to save
    //    //GlobalController.Instance.player2Values = player2Values;
    //    //GlobalController.Instance.p2BoatTickets = p2BoatTickets;
    //    //GlobalController.Instance.p2PlaneTickets = p2PlaneTickets;
    //    //GlobalController.Instance.p2RoadTickets = p2RoadTickets;
    //    //GlobalController.Instance.p2TrainTickets = p2TrainTickets;


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

    //public static GameObject FindObject(this GameObject parent, string name)
    //{
    //    Transform[] trs = parent.GetComponentsInChildren<Transform>(true);
    //    foreach (Transform t in trs)
    //    {
    //        if (t.name == name)
    //        {
    //            return t.gameObject;
    //        }
    //    }
    //    return null;
    //}
}
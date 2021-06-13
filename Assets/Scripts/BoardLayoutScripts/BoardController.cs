using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random=UnityEngine.Random;
using TMPro;

public class BoardController : MonoBehaviour
{

    public TMP_Text[] skillTextsp1 = new TMP_Text[8];
    public TMP_Text[] skillTextsp2 = new TMP_Text[8];
    public int[] player1Values = new int[8];
    public int[] player2Values = new int[8];

    public TMP_Text[] ticketTextsp1 = new TMP_Text[4];
    public TMP_Text[] ticketTextsp2 = new TMP_Text[4];

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
    // player 1's sklils 
    int player1Objects = 0;
    int player1Tickets = 0;

    //Player2 Stats
    GameObject player2;
    int player2Skills = 0;
    // player 2's skills
    int player2Objects = 0;
    int player2Tickets = 0;

    //Tickets
    public int boatTickets = 0;
    public int planeTickets = 0;
    public int roadTickets = 0;
    public int trainTickets = 0;

    Transform playerPosition;

    //Moves left
    int playerMoves = 3;

    //Current Work in progress
    public GameObject highLightMovementPfb;
    List<GameObject> possibleList = new List<GameObject>(); 

    //false = Player 1 Turn | true = Player 2 Turn
    bool turn = false;

    //Count of collectables
    int collectablesMax, collectablesQnty;

    //UI Variables
    //public Text p1Sk;
    //public Text p2Sk;
    //public Text p1Obj;
    //public Text p2Obj;
    //public Text p1Tick;
    //public Text p2Tick;
    public Text movesLeft;

    //Camera
    public GameObject mainCamera;
    CameraController mainCameraController;

    void UpdateUIStats()
    {
        //p1Sk.text   = player1Skills.ToString();
        //p2Sk.text   = player2Skills.ToString();
        //p1Obj.text = player1Objects.ToString();
        //p2Obj.text = player2Objects.ToString();
        //p1Tick.text  = player1Tickets.ToString();
        //p2Tick.text  = player2Tickets.ToString();
        movesLeft.text = playerMoves.ToString();
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
                //Will need to fix - Only refreshes after first movement and doesn't work on white but we can add a case 3 then it should work idk
                p1skills.gameObject.SetActive(false);
                p2skills.gameObject.SetActive(true);
                p1tickets.gameObject.SetActive(false);
                p2tickets.gameObject.SetActive(true);
                BGp1.gameObject.SetActive(false);
                BGp2.gameObject.SetActive(true);
                switch (ItemId)
                {
                    case 4:
                        //SKILLS

                        int skillToLevel = Random.Range(0, 8);
                        int experienceGained = ML_Algo.ML();
                        Actions.reduceActions();
                        player2Values[skillToLevel] += experienceGained;
                        skillTextsp2[skillToLevel].text = player2Values[skillToLevel].ToString();
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
                            roadTickets++;
                            ticketTextsp2[3].text = roadTickets.ToString();
                        }
                        else if (ticketGained == 2)
                        {
                            trainTickets++;
                            ticketTextsp2[2].text = trainTickets.ToString();
                        }
                        else if (ticketGained == 3)
                        {
                            boatTickets++;
                            ticketTextsp2[0].text = boatTickets.ToString();
                        }
                        else
                        {
                            planeTickets++;
                            ticketTextsp2[1].text = planeTickets.ToString();
                        }

                        Actions.reduceActions();
                        break;
                        

                        
                    case 6:
                        //OBJECTS



                        break;
                }
            } else
            {
                //Will need to fix - Only refreshes after first movement and doesn't work on white but we can add a case 3 then it should work idk
                p1skills.gameObject.SetActive(true);
                p2skills.gameObject.SetActive(false);
                p1tickets.gameObject.SetActive(true);
                p2tickets.gameObject.SetActive(false);
                BGp1.gameObject.SetActive(true);
                BGp2.gameObject.SetActive(false);
                switch (ItemId)
                {
                    case 4:
                        //SKILLS

                        int skillToLevel = Random.Range(0, 8);
                        int experienceGained = ML_Algo.ML();
                        Actions.reduceActions();
    
                        player1Values[skillToLevel] += experienceGained;
                        skillTextsp1[skillToLevel].text = player1Values[skillToLevel].ToString();
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
                            roadTickets++;
                            ticketTextsp1[3].text = roadTickets.ToString();
                        }
                        else if (ticketGained == 2)
                        {
                            trainTickets++;
                            ticketTextsp1[2].text = trainTickets.ToString();
                        }
                        else if (ticketGained == 3)
                        {
                            boatTickets++;
                            ticketTextsp1[0].text = boatTickets.ToString();
                        }
                        else
                        {
                            planeTickets++;
                            ticketTextsp1[1].text = planeTickets.ToString();
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


}
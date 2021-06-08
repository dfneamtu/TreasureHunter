using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardController : MonoBehaviour
{
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
    int player1Objects = 0;
    int player1Tickets = 0;

    //Player2 Stats
    GameObject player2;
    int player2Skills = 20;
    int player2Objects = 5;
    int player2Tickets = 0;

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
    public Text p1Sk;
    public Text p2Sk;
    public Text p1Obj;
    public Text p2Obj;
    public Text p1Tick;
    public Text p2Tick;
    public Text movesLeft;

    //Camera
    public GameObject mainCamera;
    CameraController mainCameraController;

    void UpdateUIStats()
    {
        p1Sk.text   = player1Skills.ToString();
        p2Sk.text   = player2Skills.ToString();
        p1Obj.text = player1Objects.ToString();
        p2Obj.text = player2Objects.ToString();
        p1Tick.text  = player1Tickets.ToString();
        p2Tick.text  = player2Tickets.ToString();
        movesLeft.text = playerMoves.ToString();
    }

    void Start()
    {
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
                switch (ItemId)
                {
                    case 4:
                        player2Objects++;
                        break;
                    case 5:
                        player2Skills++;
                        break;
                    case 6:
                        player2Tickets++;
                        break;
                }
            } else
            {
                switch (ItemId)
                {
                    case 4:
                        player1Objects++;
                        break;
                    case 5:
                        player1Skills++;
                        break;
                    case 6:
                        player1Tickets++;
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
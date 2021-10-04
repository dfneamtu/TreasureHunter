using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class MapController : MonoBehaviour
{
    public GameObject[] turnHighlighter;
    public GameObject[] playerPrefabs;
    public GameObject[] playerTokens;

    public int totalPlayers;

    public int[] hubLocation = new int[6];
    public int[] pLocation = new int[6];

    public int currentHub;

    public GameObject enemyObjPrefab;

    public Material Hub1;
    public Material Hub2;
    public Material Hub3;
    public GameObject Object;

    private ReadLocations locationsScript;
    public GameObject LocationsObj;
    public List<Location> locations = new List<Location>();
    public List<Enemy> enemies = new List<Enemy>();
    public GameObject[] players = new GameObject[6];
    public List<GameObject> enemiesObj = new List<GameObject>();
    public Vector3 vector;
    public Vector3 destination;
    public int turn;
    public bool startOfTurn;




    void Awake()
    {
      locationsScript = LocationsObj.GetComponent<ReadLocations>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //m_someOtherScriptOnAnotherGameObject = GameObject.FindObjectOfType(typeof(ScriptA)) as ScriptA;


        totalPlayers = GameController.maxPlayers;

        enemies = GlobalController.Instance.enemies;
        startOfTurn = GlobalController.Instance.startOfTurn;
        turn = GameController.playerTurn;

        hubLocation = GlobalController.Instance.hubLocation;
        pLocation = GlobalController.Instance.pLocation;

        locations = locationsScript.locations;


        if (hubLocation[turn - 1] == 1)
        {
          Object.GetComponent<MeshRenderer>().material = Hub1;
          currentHub = 1;
        }
        else if (hubLocation[turn - 1] == 2)
        {
          Object.GetComponent<MeshRenderer>().material = Hub2;
          currentHub = 2;
        }
        else if (hubLocation[turn - 1] == 3)
        {
          Object.GetComponent<MeshRenderer>().material = Hub3;
          currentHub = 3;
        }

      //load all players to their current location
      for (int i = 0; i < 6; i++)
      {
        foreach(Location l in locations)
        {
          if (l.hubNum == hubLocation[i] && l.locationNum == pLocation[i])
          {
          players[i].transform.position = new Vector3(l.xPos + Random.Range(-10f, 10f), 0 + Random.Range(0,7.5f), l.zPos + Random.Range(-10f,10f));
          GlobalController.Instance.players = players;
          }
        }
      }

      //move any players not in the current hub off the screen
      for (int i = 0; i < 6; i++)
      {
        if (hubLocation[i] != currentHub)
        {
          players[i].transform.position = new Vector3(2000,2000,2000);
        }
      }

      //add enemies to Screen
      foreach(Enemy e in enemies)
      {
        foreach(Location l in locations)
        {
          if (e.hubNum == l.hubNum && e.locationNum == l.locationNum && e.hubNum == currentHub)
          {
            spawnEnemy(l.xPos, l.zPos);
          }
        }
      }
    }


    private void spawnEnemy(float xPos, float zPos)
    {
      GameObject a = Instantiate(enemyObjPrefab) as GameObject;
      a.transform.position = new Vector3(xPos, 30, zPos);
    }
    // Update is called once per frame
    void Update()
    {
        switch (turn)
        {

            case 1:
                turnHighlighter[0].gameObject.SetActive(true);
                turnHighlighter[1].gameObject.SetActive(false);
                turnHighlighter[2].gameObject.SetActive(false);
                turnHighlighter[3].gameObject.SetActive(false);
                turnHighlighter[4].gameObject.SetActive(false);
                turnHighlighter[5].gameObject.SetActive(false);

                break;

            case 2:

                turnHighlighter[0].gameObject.SetActive(false);
                turnHighlighter[1].gameObject.SetActive(true);
                turnHighlighter[2].gameObject.SetActive(false);
                turnHighlighter[3].gameObject.SetActive(false);
                turnHighlighter[4].gameObject.SetActive(false);
                turnHighlighter[5].gameObject.SetActive(false);

                break;
            case 3:
                turnHighlighter[0].gameObject.SetActive(false);
                turnHighlighter[1].gameObject.SetActive(false);
                turnHighlighter[2].gameObject.SetActive(true);
                turnHighlighter[3].gameObject.SetActive(false);
                turnHighlighter[4].gameObject.SetActive(false);
                turnHighlighter[5].gameObject.SetActive(false);

                break;
            case 4:

                turnHighlighter[0].gameObject.SetActive(false);
                turnHighlighter[1].gameObject.SetActive(false);
                turnHighlighter[2].gameObject.SetActive(false);
                turnHighlighter[3].gameObject.SetActive(true);
                turnHighlighter[4].gameObject.SetActive(false);
                turnHighlighter[5].gameObject.SetActive(false);

                break;
            case 5:
                turnHighlighter[0].gameObject.SetActive(false);
                turnHighlighter[1].gameObject.SetActive(false);
                turnHighlighter[2].gameObject.SetActive(false);
                turnHighlighter[3].gameObject.SetActive(false);
                turnHighlighter[4].gameObject.SetActive(true);
                turnHighlighter[5].gameObject.SetActive(false);

                break;

            case 6:
                turnHighlighter[0].gameObject.SetActive(false);
                turnHighlighter[1].gameObject.SetActive(false);
                turnHighlighter[2].gameObject.SetActive(false);
                turnHighlighter[3].gameObject.SetActive(false);
                turnHighlighter[4].gameObject.SetActive(false);
                turnHighlighter[5].gameObject.SetActive(true);

                break;

            default:
                //Console.WriteLine("Default case");
                break;

        }


        if (totalPlayers == 2)
        {
            playerPrefabs[0].gameObject.SetActive(true);
            playerPrefabs[1].gameObject.SetActive(true);
            playerPrefabs[2].gameObject.SetActive(false);
            playerPrefabs[3].gameObject.SetActive(false);
            playerPrefabs[4].gameObject.SetActive(false);
            playerPrefabs[5].gameObject.SetActive(false);

            playerTokens[0].gameObject.SetActive(true);
            playerTokens[1].gameObject.SetActive(true);
            playerTokens[2].gameObject.SetActive(false);
            playerTokens[3].gameObject.SetActive(false);
            playerTokens[4].gameObject.SetActive(false);
            playerTokens[5].gameObject.SetActive(false);
        }
        if (totalPlayers == 3)
        {
            playerPrefabs[0].gameObject.SetActive(true);
            playerPrefabs[1].gameObject.SetActive(true);
            playerPrefabs[2].gameObject.SetActive(true);
            playerPrefabs[3].gameObject.SetActive(false);
            playerPrefabs[4].gameObject.SetActive(false);
            playerPrefabs[5].gameObject.SetActive(false);

            playerTokens[0].gameObject.SetActive(true);
            playerTokens[1].gameObject.SetActive(true);
            playerTokens[2].gameObject.SetActive(true);
            playerTokens[3].gameObject.SetActive(false);
            playerTokens[4].gameObject.SetActive(false);
            playerTokens[5].gameObject.SetActive(false);
        }
        if (totalPlayers == 4)
        {
            playerPrefabs[0].gameObject.SetActive(true);
            playerPrefabs[1].gameObject.SetActive(true);
            playerPrefabs[2].gameObject.SetActive(true);
            playerPrefabs[3].gameObject.SetActive(true);
            playerPrefabs[4].gameObject.SetActive(false);
            playerPrefabs[5].gameObject.SetActive(false);

            playerTokens[0].gameObject.SetActive(true);
            playerTokens[1].gameObject.SetActive(true);
            playerTokens[2].gameObject.SetActive(true);
            playerTokens[3].gameObject.SetActive(true);
            playerTokens[4].gameObject.SetActive(false);
            playerTokens[5].gameObject.SetActive(false);
        }
        if (totalPlayers == 5)
        {
            playerPrefabs[0].gameObject.SetActive(true);
            playerPrefabs[1].gameObject.SetActive(true);
            playerPrefabs[2].gameObject.SetActive(true);
            playerPrefabs[3].gameObject.SetActive(true);
            playerPrefabs[4].gameObject.SetActive(true);
            playerPrefabs[5].gameObject.SetActive(false);

            playerTokens[0].gameObject.SetActive(true);
            playerTokens[1].gameObject.SetActive(true);
            playerTokens[2].gameObject.SetActive(true);
            playerTokens[3].gameObject.SetActive(true);
            playerTokens[4].gameObject.SetActive(true);
            playerTokens[5].gameObject.SetActive(false);
        }
        if (totalPlayers == 6)
        {
            playerPrefabs[0].gameObject.SetActive(true);
            playerPrefabs[1].gameObject.SetActive(true);
            playerPrefabs[2].gameObject.SetActive(true);
            playerPrefabs[3].gameObject.SetActive(true);
            playerPrefabs[4].gameObject.SetActive(true);
            playerPrefabs[5].gameObject.SetActive(true);

            playerTokens[0].gameObject.SetActive(true);
            playerTokens[1].gameObject.SetActive(true);
            playerTokens[2].gameObject.SetActive(true);
            playerTokens[3].gameObject.SetActive(true);
            playerTokens[4].gameObject.SetActive(true);
            playerTokens[5].gameObject.SetActive(true);
        }
    }

}

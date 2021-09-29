using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MapController : MonoBehaviour
{

    public int[] hubLocation = new int[6];
    public int[] pLocation = new int[6];
    public int[] newHub = new int[6];
    public int[] newLocation = new int[6];

    public int currentHub;

    public Material Hub1;
    public Material Hub2;
    public Material Hub3;
    public GameObject Object;

    private ReadLocations locationsScript;
    public GameObject LocationsObj;
    public List<Location> locations = new List<Location>();
    public GameObject[] players = new GameObject[6];
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


        startOfTurn = GlobalController.Instance.startOfTurn;
        turn = GameController.playerTurn;

        hubLocation = GlobalController.Instance.hubLocation;
        pLocation = GlobalController.Instance.pLocation;

        locations = locationsScript.locations;

        newLocation = GlobalController.Instance.newLocation;
        newHub = GlobalController.Instance.newHub;

        if (newHub[turn - 1] == 1)
        {
          Object.GetComponent<MeshRenderer>().material = Hub1;
          currentHub = 1;
        }
        else if (newHub[turn - 1] == 2)
        {
          Object.GetComponent<MeshRenderer>().material = Hub2;
          currentHub = 2;
        }
        else if (newHub[turn - 1] == 3)
        {
          Object.GetComponent<MeshRenderer>().material = Hub3;
          currentHub = 3;
        }



        if (startOfTurn)
        {
          if (hubLocation[turn - 1] != newHub[turn - 1] || pLocation[turn - 1] != newLocation[turn -1])
          {
              foreach(Location l in locations)
              {
                if (l.hubNum == newHub[turn - 1])
                {
                  if (l.locationNum == newLocation[turn - 1])
                  {
                    players[turn - 1].transform.position = new Vector3(l.xPos, 0, l.zPos);

                    pLocation[turn - 1] = newLocation[turn - 1];
                    hubLocation[turn - 1] = newHub[turn - 1];


                    GlobalController.Instance.hubLocation = hubLocation;
                    GlobalController.Instance.pLocation = pLocation;
                    GlobalController.Instance.newHub = newHub;
                    GlobalController.Instance.newLocation = newLocation;
                    GlobalController.Instance.players = players;
                  }
                }

            }
          }

        startOfTurn = false;
        GlobalController.Instance.startOfTurn = startOfTurn;
      }

      for (int i = 0; i < 6; i++)
      {
        foreach(Location l in locations)
        {
          if (l.hubNum == hubLocation[i])
          {
            if (l.locationNum == pLocation[i])
            {
              players[i].transform.position = new Vector3(l.xPos + Random.Range(-10f, 10f), 0 + Random.Range(0,7.5f), l.zPos + Random.Range(-10f,10f));

              GlobalController.Instance.players = players;
            }
          }
        }
      }


      for (int i = 0; i < 6; i++)
      {
        if (hubLocation[i] != currentHub)
        {
          players[i].transform.position = new Vector3(2000,2000,2000);
        }
      }
    }

    // Update is called once per frame
    void Update()
    {
        GlobalController.Instance.newHub = newHub;
        GlobalController.Instance.newLocation = newLocation;

        pLocation = GlobalController.Instance.pLocation;
        hubLocation = GlobalController.Instance.hubLocation;

        //locations[0].x;
        //locations[0].y;

        //locations[0].xPos;
        //locations[0].zPos;
    }
}

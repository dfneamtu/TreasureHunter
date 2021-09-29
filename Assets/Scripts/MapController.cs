using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{

    public int[] hubLocation = new int[6];
    public int[] pLocation = new int[6];
    public int[] newHub = new int[6];
    public int[] newLocation = new int[6];



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

        startOfTurn = GlobalController.Instance.startOfTurn;
        turn = GameController.playerTurn;

        hubLocation = GlobalController.Instance.hubLocation;
        pLocation = GlobalController.Instance.pLocation;

        locations = locationsScript.locations;

        newLocation = GlobalController.Instance.newLocation;
        newHub = GlobalController.Instance.newHub;

        if (startOfTurn)
        {
          Debug.Log("Start of Turn");
          if (hubLocation[turn - 1] != newHub[turn - 1] || pLocation[turn - 1] != newLocation[turn -1])
          {
              foreach(Location l in locations)
              {
                Debug.Log("player: " + turn + " loc: " + hubLocation[turn - 1] + ", " + pLocation[turn - 1] + " going to " + newHub[turn - 1] + " , " + newLocation[turn - 1]);

                if (l.hubNum == newHub[turn - 1])
                {
                  if (l.locationNum == newLocation[turn - 1])
                  {
                    players[turn - 1].transform.position = new Vector3(l.xPos, 0, l.zPos);
                    pLocation[turn - 1] = newLocation[turn - 1];
                    hubLocation[turn - 1] = newHub[turn - 1];

                    GlobalController.Instance.hubLocation = hubLocation;
                    GlobalController.Instance.pLocation = pLocation;
                    GlobalController.Instance.players = players;
                  }
                }

            }
          }


        // foreach(Location l in locations)
        // {
        //   if (newHub[turn - 1] == l.hubNum)
        //   {
        //     if (newLocation[turn - 1] == l.locationNum)
        //     {
        //       Debug.Log("player: " + turn + " loc: " + hubLocation[turn - 1] + ", " + pLocation[turn - 1] + " going to " + newHub[turn - 1] + " , " + newLocation[turn - 1]);
        //       players[turn - 1].transform.position = new Vector3(l.xPos, 0, l.zPos);
        //       pLocation[turn - 1] = newLocation[turn - 1];
        //       hubLocation[turn - 1] = newHub[turn - 1];
        //
        //       GlobalController.Instance.hubLocation = hubLocation;
        //       GlobalController.Instance.pLocation = pLocation;
        //       GlobalController.Instance.players = players;
        //     }
        //   }
        // }

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
              players[i].transform.position = new Vector3(l.xPos, 0, l.zPos);

              GlobalController.Instance.players = players;
            }
          }
        }
      }

      // for (int i = 0; i < 6; i++)
      // {
      //   foreach(Location l in locations)
      //   {
      //     if (hubLocation[i] == l.hubNum)
      //     {
      //       if (pLocation[i] == l.locationNum)
      //       {
      //         //Debug.Log("player: " + turn + " loc: " + hubLocation[turn - 1] + ", " + pLocation[turn - 1] + " going to " + newHub[turn - 1] + " , " + newLocation[turn - 1]);
      //         players[i].transform.position = new Vector3(l.xPos, 0, l.zPos);
      //       }
      //     }
      //   }
      // }
        //Vector3 final = Vector3.MoveTowards(vector, destination, Time.deltaTime * 50f);
        //p1.transform.position = final;
        //p1.transform.position = vector;
        //p1.transform.position = Vector3.MoveTowards(Cube.transform.position, destination, Time.deltaTime * speed);

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

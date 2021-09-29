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
    public GameObject p1;
    public GameObject p2;
    public GameObject p3;
    public GameObject p4;
    public GameObject p5;
    public GameObject p6;
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
        players[0] = p1;
        players[1] = p2;
        players[2] = p3;
        players[3] = p4;
        players[4] = p5;
        players[5] = p6;

        hubLocation = GlobalController.Instance.hubLocation;
        pLocation = GlobalController.Instance.pLocation;
        locations = locationsScript.locations;
        newLocation = GlobalController.Instance.newLocation;
        newHub = GlobalController.Instance.newHub;

        if (startOfTurn)
        {

        //vector = new Vector3(locations[2].xPos, 0, locations[2].zPos);
        //destination = new Vector3(locations[0].xPos, 0, locations[0].zPos);

        foreach(Location l in locations)
        {
          if (newHub[turn - 1] == l.hubNum)
          {
            if (newLocation[turn - 1] == l.locationNum)
            {
              Debug.Log("player: " + turn + " loc: " + hubLocation[turn - 1] + ", " + pLocation[turn - 1]);
              players[turn - 1].transform.position = new Vector3(l.xPos, 0, l.zPos);
              pLocation[turn - 1] = newLocation[turn-1];
              hubLocation[turn - 1] = newHub[turn - 1];
            }
          }
        }

        startOfTurn = false;
        GlobalController.Instance.startOfTurn = startOfTurn;
      }
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

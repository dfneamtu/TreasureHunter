using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapController : MonoBehaviour
{

    public int[] hubLocation = new int[6];
    public int[] pLocation = new int[6];
    private ReadLocations locationsScript;
    public GameObject LocationsObj;
    public List<Location> locations = new List<Location>();
    //public GameObject Cube;
    public Vector3 vector;
    public Vector3 destination;

    void Awake()
    {
      locationsScript = LocationsObj.GetComponent<ReadLocations>();
    }
    // Start is called before the first frame update
    void Start()
    {
        hubLocation = GlobalController.Instance.hubLocation;
        pLocation = GlobalController.Instance.pLocation;
        locations = locationsScript.locations;
        vector = new Vector3(locations[2].xPos, 0, locations[2].zPos);
        destination = new Vector3(locations[0].xPos, 0, locations[0].zPos);

        //Cube.transform.position = vector;
        //Vector3 final = Vector3.MoveTowards(vector, destination, Time.deltaTime * 50f);
        //Cube.transform.position = final;
        //Cube.transform.position = vector;
        //Cube.transform.position = Vector3.MoveTowards(Cube.transform.position, destination, Time.deltaTime * speed);

    }

    // Update is called once per frame
    void Update()
    {


      //locations[0].x
      //locations[0].y

      //locations[0].xPos
      //locations[0].zPos
    }
}

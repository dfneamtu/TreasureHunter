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
    Vector3 thing;

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


    }

    // Update is called once per frame
    void Update()
    {
      thing = transform.position;
      thing.x = locations[0].xPos;
      thing.z = locations[0].zPos;

      transform.position = thing;
      //locations[0].x
      //locations[0].y

      //locations[0].xPos
      //locations[0].zPos
    }
}

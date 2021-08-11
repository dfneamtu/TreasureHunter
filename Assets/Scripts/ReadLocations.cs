using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadLocations : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Location> locations = new List<Location>();
    public List<Location> hostileLocations = new List<Location>();
    // Start is called before the first frame update
    void Start()
    {
        TextAsset locationData = Resources.Load<TextAsset>("Locations");

        string[] data = locationData.text.Split(new char[] { '\n'});

        for (int i = 1; i < data.Length - 1; i++)
        {
          string[] row = data[i].Split(new char[] { ','});
          Location l = new Location();
          int.TryParse(row[1], out l.hubNum);
          int.TryParse(row[2], out l.locationNum);
          l.locationStr = row[3];
          int.TryParse(row[4], out l.x);
          int.TryParse(row[5], out l.y);
          int.TryParse(row[6], out l.diff);
          int.TryParse(row[7], out l.isAirport);
          int.TryParse(row[8], out l.isSpawner);
          float.TryParse(row[9], out l.xPos);
          float.TryParse(row[10], out l.zPos);
          l.enemiesPresent = 0;

          locations.Add(l);
          //Debug.Log(l.hubNum + "," + l.locationNum + "," + l.locationStr + "," + l.x + "," + l.y + "," + l.diff + "," + l.isAirport + "," + l.isSpawner);

          if (l.isSpawner == 1)
          {
            //Debug.Log("ADDING !");
            hostileLocations.Add(l);
          }
        }

        foreach (Location l in hostileLocations)
        {
          //Debug.Log(l.locationStr + " IS HOSTILE!");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

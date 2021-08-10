using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadLocations : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Location> locations = new List<Location>();
    // Start is called before the first frame update
    void Start()
    {
        TextAsset locationData = Resources.Load<TextAsset>("Locations");

        string[] data = locationData.text.Split(new char[] { '\n'});

        for (int i = 1; i < data.Length - 1; i++)
        {
          string[] row = data[i].Split(new char[] { ','});
          Location l = new Location();
          int.TryParse(row[0], out l.hubNum);
          int.TryParse(row[1], out l.locationNum);
          l.locationStr = row[2];
          int.TryParse(row[3], out l.x);
          int.TryParse(row[4], out l.y);
          int.TryParse(row[5], out l.diff);
          //l.isAirport = bool.Parse(row[6]);
          //l.isSpawner = bool.Parse(row[7]);
          //Boolean.TryParse(row[6], out l.isAirport);
          //Boolean.TryParse(row[7], out l.isSpawner);

          locations.Add(l);
        }


        foreach (Location l in locations)
        {
          Debug.Log(l.locationStr);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ReadLocationPaths : MonoBehaviour
{
    public List<LocationPath> locationPaths = new List<LocationPath>();
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("working");
        TextAsset locationPathData = Resources.Load<TextAsset>("LocationPaths");

        string[] data = locationPathData.text.Split(new char[] { '\n'});

        for (int i = 1; i < data.Length - 1; i++)
        {
          string[] row = data[i].Split(new char[] { ',' });
          LocationPath lp = new LocationPath();
          int.TryParse(row[0], out lp.hubNum);
          int.TryParse(row[1], out lp.locationNum);
          lp.locationStr = row[2];
          lp.travelType = row[3];
          int.TryParse(row[4], out lp.ticketNum);
          lp.travelToStr = row[5];
          int.TryParse(row[6], out lp.hubToNum);
          int.TryParse(row[7], out lp.travelToNum);

          locationPaths.Add(lp);
        }

        List<LocationPath> adjacentLocationPaths = new List<LocationPath>();
        foreach (LocationPath lp in locationPaths)
        {
          if (lp.hubNum == 1)
          {
            if (lp.locationNum == 1)
            {
              adjacentLocationPaths.Add(lp);
              Debug.Log("Player can travel to: " + lp.travelToStr + " with " + lp.ticketNum + " " + lp.travelType + " tickets. FROM: " + lp.locationStr);
            }
          }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}

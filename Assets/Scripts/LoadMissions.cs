using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;


public class LoadMissions : MonoBehaviour
{
  public static LoadMissions Instance;
  public GameObject LocationsObj;
  private ReadLocations locationsScript;

  public List<Mission> missions = new List<Mission>();


  public void Awake()
  {
    if (Instance == null)
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }
    else if (Instance != this)
    {
        Destroy(gameObject);
    }
  }

  public void Start()
  {
    locationsScript = LocationsObj.GetComponent<ReadLocations>();
    generateMissions();
  }

  public void generateMissions()
  {
    List<Location> potentialLocationsHub1 = new List<Location>();
    List<Location> potentialLocationsHub2 = new List<Location>();
    List<Location> potentialLocationsHub3 = new List<Location>();

    foreach(Location l in locationsScript.locations)
    {
      if (l.isSpawner == 0 && l.isAirport == 0)
      {
        if (l.hubNum == 1)
        {
          potentialLocationsHub1.Add(l);
        }
        if (l.hubNum == 2)
        {
          potentialLocationsHub2.Add(l);
        }
        if (l.hubNum == 3)
        {
          potentialLocationsHub3.Add(l);
        }
      }
    }

    IListExtensions.Shuffle(potentialLocationsHub1);
    IListExtensions.Shuffle(potentialLocationsHub2);
    IListExtensions.Shuffle(potentialLocationsHub3);

    int[] skillsHub1 = new int[7];
    int[] skillsHub2 = new int[7];
    int[] skillsHub3 = new int[7];

    for (int i = 0; i < 7; i++)
    {
      skillsHub1[i] = i + 1;
      skillsHub2[i] = i + 1;
      skillsHub3[i] = i + 1;
    }

    IListExtensions.Shuffle(skillsHub1);

    for (int i = 0; i < 3; i++)
    {
      Mission m1 = new Mission(1, potentialLocationsHub1[i].locationNum, skillsHub1[i]);
      Mission m2 = new Mission(2, potentialLocationsHub2[i].locationNum, skillsHub2[i]);
      Mission m3 = new Mission(3, potentialLocationsHub3[i].locationNum, skillsHub3[i]);

      missions.Add(m1);
      missions.Add(m2);
      missions.Add(m3);
    }
    return;
  }

  public List<Mission> GetMissions()
  {
    return missions;
  }

}

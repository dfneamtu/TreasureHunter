using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission : MonoBehaviour
{
    public int hubNum;
    public int locationNum;
    public int skillNum;
    public int pointsReq;
    public int victoryPoints;
    public bool[] completedBy = new bool[6];

    public Mission(int h, int l, int s)
    {
      hubNum = h;
      locationNum = l;
      skillNum = s;

      pointsReq = ML_Algo.ML() + 1;
      victoryPoints = ML_Algo.ML() + 1;

      for (int i = 0; i < 6; i++)
      {
        completedBy[i] = false;
      }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class LoadLocation : MonoBehaviour
{

    public GameObject UIObject;

    public TextAsset textAssetData;

    [System.Serializable]

    public class Info
    {
        public int hubNum;
        public int locationNum;
        public string locationStr;
        public string travelType;
        public int ticketNum;
        public string traveltoStr;
        public int HubtoNum;
        public int traveltoNum;

    }

    [System.Serializable]

    public class InfoList
    {
        public Info[] info;
    }

    public InfoList myInfoList = new InfoList();

    // Start is called before the first frame update
    public void Start()
    {
        ReadCSV();

    }

    public void ReadCSV()
    {
        string[] data = textAssetData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

        int tableSize = data.Length / 8;
        myInfoList.info = new Info[tableSize];

        for (int i = 0; i < tableSize; i++)
        { 
            myInfoList.info[i] = new Info();
            myInfoList.info[i].hubNum = int.Parse(data[8 * (i)]);
            myInfoList.info[i].locationNum = int.Parse(data[8 * (i ) + 1]);
            myInfoList.info[i].locationStr = (data[8 * (i) + 2]);
            myInfoList.info[i].travelType = (data[8 * (i) + 3]);
            myInfoList.info[i].ticketNum = int.Parse(data[8 * (i) + 4]);
            myInfoList.info[i].traveltoStr = (data[8 * (i) + 5]);
            myInfoList.info[i].HubtoNum = int.Parse(data[8 * (i) + 6]);
            myInfoList.info[i].traveltoNum = int.Parse(data[8 * (i) + 7]);

        }
    }

}

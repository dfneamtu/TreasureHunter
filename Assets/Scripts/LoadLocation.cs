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
        public int locationnum;
        public string location;
        public string travel;
        public int tickets;
        public string travelto;

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

        int tableSize = data.Length / 5;
        myInfoList.info = new Info[tableSize];

        for (int i = 0; i < tableSize; i++)
        {
            myInfoList.info[i] = new Info();
            myInfoList.info[i].locationnum = int.Parse(data[5 * (i)]);
            myInfoList.info[i].location = (data[5 * (i ) + 1]);
            myInfoList.info[i].travel = (data[5 * (i) + 2]);
            myInfoList.info[i].tickets = int.Parse(data[5 * (i) + 3]);
            myInfoList.info[i].travelto = (data[5 * (i) + 4]);

        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class LoadFaction : MonoBehaviour
{
    public GameObject UIObject;

    public TextAsset textAssetData;

    [System.Serializable]

    public class Info
    {
        public string team;
        public int info1;
        public int info2;
        public int info3;
        public int info4;
        public int info5;
        public int info6;
        public int info7;


    }

    [System.Serializable]

    public class InfoList
    {
        public Info[] info;
    }

    public InfoList myInfoList = new InfoList();

    // Start is called before the first frame update
    void Start()
    {
        ReadCSV();

    }

    void ReadCSV()
    {

        string[] data = textAssetData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

        int tableSize = data.Length / 8;
        myInfoList.info = new Info[tableSize];

        for (int i = 0; i < tableSize; i++)
        {
            myInfoList.info[i] = new Info();
            myInfoList.info[i].team = (data[8 * (i)]);
            myInfoList.info[i].info1 = int.Parse(data[8 * (i) + 1]);
            myInfoList.info[i].info2 = int.Parse(data[8 * (i) + 2]);
            myInfoList.info[i].info3 = int.Parse(data[8 * (i) + 3]);
            myInfoList.info[i].info4 = int.Parse(data[8 * (i) + 4]);
            myInfoList.info[i].info5 = int.Parse(data[8 * (i) + 5]);
            myInfoList.info[i].info6 = int.Parse(data[8 * (i) + 6]);
            myInfoList.info[i].info7 = int.Parse(data[8 * (i) + 7]);

        }



    }
}

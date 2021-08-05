using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;


public class LoadMissions : MonoBehaviour
{

    public GameObject UIObject;

    public TextAsset textAssetData;

    [System.Serializable]

    public class Info
    {
        public string mission;
        public string mission1;
        public string mission2;
        public string mission3;
        public string mission4;
        public string mission5;
        public string mission6;
        public string mission7;
        public string mission8;
        public string mission9;
        public string mission10;
        public string mission11;
        public string mission12;
        public string mission13;
        public string mission14;
        public string mission15;
        public string mission16;

    }

    [System.Serializable]

    public class InfoList
    {
        public Info[] info;
    }

    public InfoList myInfoList = new InfoList();

    public void Start()
    {
        ReadCSV();

    }

    public void ReadCSV()
    {
        string[] data = textAssetData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

        int tableSize = data.Length / 17;
        myInfoList.info = new Info[tableSize];

        for (int i = 0; i < tableSize; i++)
        {
            myInfoList.info[i] = new Info();
            myInfoList.info[i].mission = data[17 * (i)];
            myInfoList.info[i].mission1 = data[17 * (i) + 1];
            myInfoList.info[i].mission2 = data[17 * (i) + 2];
            myInfoList.info[i].mission3 = data[17 * (i) + 3];
            myInfoList.info[i].mission4 = data[17 * (i) + 4];
            myInfoList.info[i].mission5 = data[17 * (i) + 5];
            myInfoList.info[i].mission6 = data[17 * (i) + 6];
            myInfoList.info[i].mission7 = data[17 * (i) + 7];
            myInfoList.info[i].mission8 = data[17 * (i) + 8];
            myInfoList.info[i].mission9 = (data[17 * (i) + 9]);
            myInfoList.info[i].mission10 = (data[17 * (i) + 10]);
            myInfoList.info[i].mission11 = (data[17 * (i) + 11]);
            myInfoList.info[i].mission12 = (data[17 * (i) + 12]);
            myInfoList.info[i].mission13 = (data[17 * (i) + 13]);
            myInfoList.info[i].mission14 = (data[17 * (i) + 14]);
            myInfoList.info[i].mission15 = (data[17 * (i) + 15]);
            myInfoList.info[i].mission16 = (data[17 * (i) + 16]);
        }
    }

}
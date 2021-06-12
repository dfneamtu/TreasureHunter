using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;


public class LoadPlayer : MonoBehaviour
{

    public GameObject UIObject;
    //public Skills skills;

    public TextAsset textAssetData;

    [System.Serializable]

    public class Info
    {
        public int playerid;
        public int faction;
        public int map;
        public int location;
        public string avatar;
        public int skill1;
        public int skill2;
        public int skill3;
        public int skill4;
        public int skill5;
        public int skill6;
        public int skill7;
        public int skill8;
        public int skill9;
        public int skill10;
        public int ticket1;
        public int ticket2;
        public int ticket3;
        public int ticket4;

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
        //skills = GameObject.FindWithTag("Skills").GetComponent<Skills>();

        string[] data = textAssetData.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);

        int tableSize = data.Length / 19;
        myInfoList.info = new Info[tableSize];

        for (int i = 0; i < tableSize; i++)
        {
            myInfoList.info[i] = new Info();
            myInfoList.info[i].playerid = int.Parse(data[19 * (i)]);
            myInfoList.info[i].faction = int.Parse(data[19 * (i) + 1]);
            myInfoList.info[i].map = int.Parse(data[19 * (i) + 2]);
            myInfoList.info[i].location = int.Parse(data[19 * (i) + 3]);
            myInfoList.info[i].avatar = data[19 * (i) + 4];
            myInfoList.info[i].skill1 = int.Parse(data[19 * (i) + 5]);
            myInfoList.info[i].skill2 = int.Parse(data[19 * (i) + 6]);
            myInfoList.info[i].skill3 = int.Parse(data[19 * (i) + 7]);
            myInfoList.info[i].skill4 = int.Parse(data[19 * (i) + 8]);
            myInfoList.info[i].skill5 = int.Parse(data[19 * (i) + 9]);
            myInfoList.info[i].skill6 = int.Parse(data[19 * (i) + 10]);
            myInfoList.info[i].skill7 = int.Parse(data[19 * (i) + 11]);
            myInfoList.info[i].skill8 = int.Parse(data[19 * (i) + 12]);
            myInfoList.info[i].skill9 = int.Parse(data[19 * (i) + 13]);
            myInfoList.info[i].skill10 = int.Parse(data[19 * (i) + 14]);
            myInfoList.info[i].ticket1 = int.Parse(data[19 * (i) + 15]);
            myInfoList.info[i].ticket2 = int.Parse(data[19 * (i) + 16]);
            myInfoList.info[i].ticket3 = int.Parse(data[19 * (i) + 17]);
            myInfoList.info[i].ticket4 = int.Parse(data[19 * (i) + 18]);
        }
        /*
        skills.skillValues[0] = myInfoList.info[0].skill1;
        skills.skillValues[1] = myInfoList.info[0].skill2;
        skills.skillValues[2] = myInfoList.info[0].skill3;
        skills.skillValues[3] = myInfoList.info[0].skill4;
        skills.skillValues[4] = myInfoList.info[0].skill5;
        skills.skillValues[5] = myInfoList.info[0].skill6;
        skills.skillValues[6] = myInfoList.info[0].skill7;
        skills.skillValues[7] = myInfoList.info[0].skill8;
        */
    }

}

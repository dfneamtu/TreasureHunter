using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class LoadInfo : MonoBehaviour
{
    public GameObject UIObject;

    public TextAsset textAssetData;

    [System.Serializable]

    public class Info
    {
        public string playernumber;
        public string health;
        public string score;
        public string location;
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

        int tableSize = data.Length / 4 - 1;
        myInfoList.info = new Info[tableSize];

        for (int i = 0; i < tableSize; i++)
        {
            myInfoList.info[i] = new Info();
            myInfoList.info[i].playernumber = data[4 * (i + 1)];
            myInfoList.info[i].health = data[4 * (i + 1) + 1];
            myInfoList.info[i].score = data[4 * (i + 1) + 2];
            myInfoList.info[i].location = data[4 * (i + 1) + 3];
        }



    }


}

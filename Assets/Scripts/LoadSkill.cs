using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class LoadSkill : MonoBehaviour
{
    public GameObject UIObject;

    public TextAsset textAssetData;

    [System.Serializable]

    public class Info
    {
        public string s;
        public int info1;
        public int info2;
        public string skillType;

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

        int tableSize = data.Length / 4;
        myInfoList.info = new Info[tableSize];

        for (int i = 0; i < tableSize; i++)
        {
            myInfoList.info[i] = new Info();
            myInfoList.info[i].s = data[4 * (i)];
            myInfoList.info[i].info1 = int.Parse(data[4 * (i) + 1]);
            myInfoList.info[i].info2 = int.Parse(data[4 * (i) + 2]);
            myInfoList.info[i].skillType = data[4 * (i) + 3];
        }



    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;

public class LoadTickets : MonoBehaviour
{
    List<Tickets> tickets = new List<Tickets>();


    public GameObject UIObject;

    public TextAsset textAssetData;

    // Start is called before the first frame update
    void Start()
    {

    string[] data = textAssetData.text.Split(new char[] { '\n' });

        for(int i = 1; i<data.Length - 1; i++)
            {
                string[] row = data[i].Split(new char[] { ',' });
                Tickets t = new Tickets();
                t.ticket = row[0];
                int.TryParse(row[1], out t.location);
                int.TryParse(row[2], out t.ticketnum);
                t.travel = row[3];

                tickets.Add(t);
        }

        foreach(Tickets t in tickets )
        {
            Debug.Log(t.ticket);
            Debug.Log(t.location);
            Debug.Log(t.ticketnum);
            Debug.Log(t.travel);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

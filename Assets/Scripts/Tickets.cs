/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random=UnityEngine.Random;

public class Tickets : MonoBehaviour
{
	 
	public int boatTickets = 0;
    public int planeTickets = 0;
    public int roadTickets = 0;
    public int trainTickets = 0;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++) 
        {
        	ticketTexts[i] = this.gameObject.transform.GetChild(i).GetComponent<TMP_Text>();
        }
    }

    public void addTickets() 
    {
    	int ticketGained = 0;
    	while (ticketGained == 0) 
    	{
    		ticketGained = ML_Algo.ML();
    	}

        if (ticketGained == 1) 
        {
            roadTickets++;
            ticketTexts[3].text = roadTickets.ToString();
        }
        else if (ticketGained == 2)
        {
            trainTickets++;
            ticketTexts[2].text = trainTickets.ToString();
        }
        else if (ticketGained == 3) 
        {
            boatTickets++;
            ticketTexts[0].text = boatTickets.ToString();
        }
        else
        {
            planeTickets++;
            ticketTexts[1].text = planeTickets.ToString();
        }

        Actions.reduceActions();
    }

    void Update()
    {
    	
    }

}
*/

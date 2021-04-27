using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random=UnityEngine.Random;

public class PlayersTickets : MonoBehaviour
{
	public TMP_Text[] ticketTexts = new TMP_Text[4];
	public int boatTickets;
    public int planeTickets;
    public int roadTickets;
    public int trainTickets;

    // Start is called before the first frame update
    void Start()
    {
        boatTickets = 0;
        planeTickets = 0;
        roadTickets = 0;
        trainTickets = 0;
        for (int i = 0; i < 4; i++) 
        {
        	ticketTexts[i] = this.gameObject.transform.GetChild(i).GetComponent<TMP_Text>();
        	ticketTexts[i].text = "0";
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
    }

    void Update()
    {
    	
    }

}

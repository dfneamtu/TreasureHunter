using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random=UnityEngine.Random;

public class PlayersTickets : MonoBehaviour
{
	public TMP_Text[] ticketTexts = new TMP_Text[4];
	public int[] ticketValues = new int[4];
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++) 
        {
        	ticketTexts[i] = this.gameObject.transform.GetChild(i).GetComponent<TMP_Text>();
        	ticketTexts[i].text = "0";
        	ticketValues[i] = 0;
        }
    }

    public void addTickets() 
    {
    	int ticketGained = 0;
    	while (ticketGained == 0) 
    	{
    		ticketGained = ML_Algo.ML();
            Debug.Log(ticketGained.ToString());
    	}

    	ticketValues[ticketGained - 1] += 1;
    	ticketTexts[ticketGained - 1].text = ticketValues[ticketGained - 1].ToString();
    }

    void Update()
    {
    	
    }

}

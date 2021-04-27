using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random=UnityEngine.Random;

public class AddTicketsScript : MonoBehaviour
{
	public Button addTicketsButton;
	private PlayersTickets parentTickets;
    // Start is called before the first frame update
    void Start()
    {
    	parentTickets = GetComponentInParent<PlayersTickets>();
    	addTicketsButton.onClick.AddListener(buttonClicked);

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buttonClicked()
    {
    	parentTickets.addTickets();
    }
}

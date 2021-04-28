using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollThroughTickets : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject ticket;
    private SpriteRenderer ticketColor;
    private int ticketState;

    [SerializeField]
    private Sprite[] switchSprite;
    private Image switchImage;

    void Start()
    {
        ticketColor = ticket.GetComponent<SpriteRenderer>();
        //ticketState[] = { 1, 2, 3, 4 };

        switchImage = GetComponent<Button>().image;
        switchImage.sprite = switchSprite[ticketState];

        gameObject.GetComponent<Button>().onClick.AddListener(SwitchTickets);

    }

    private void SwitchTickets()
    {
        //ticketColor.color = new Color(1f, 1f, ticketState, 1f);
        ticketState = 1 - ticketState;
        switchImage.sprite = switchSprite[ticketState];
    }
}

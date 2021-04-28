using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollThroughTickets : MonoBehaviour
{   
    public Button nextImg; //Button to view next image
    public Button prevImg; //Button to view previous image
    // Start is called before the first frame update
    [SerializeField]
    private GameObject ticket;
    //private SpriteRenderer ticketColor;
    private int ticketState = 0;

    [SerializeField]
    private Sprite[] switchSprite;
    private Image switchImage;

    void Start()
    {
        //ticketColor = ticket.GetComponent<SpriteRenderer>();

        switchImage = GetComponent<Button>().image;
        //switchImage.sprite = switchSprite[ticketState];

        gameObject.GetComponent<Button>().onClick.AddListener(BtnNext);
        gameObject.GetComponent<Button>().onClick.AddListener(BtnPrev);
    }

    private void SwitchTickets()
    {
        //ticketColor.color = new Color(1f, 1f, ticketState, 1f);
        ticketState = 1 - ticketState;
        switchImage.sprite = switchSprite[ticketState];
    }
    //public Sprite[] gallery; //store all your images in here at design time
    //public Image displayImage; //The current image thats visible

    //public int i = 0; //Will control where in the array you are

    public void BtnNext()
    {
        if (ticketState + 1 < switchSprite.Length)
        {
            ticketState++;
        }
    }

    public void BtnPrev()
    {
        if (ticketState - 1 > 0)
        {
            ticketState--;
        }
    }

    void Update()
    {
        switchImage.sprite = switchSprite[ticketState];
    }

}

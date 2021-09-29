using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMap : MonoBehaviour
{
    public int[] pLocation = new int[6];
    public int[] hubLocation = new int[6];

    public int playerTurnTickets;

    public Material Hub1;
    public Material Hub2;
    public Material Hub3;

    //in the editor this is what you would set as the object you wan't to change
    public GameObject Object;

    void Start()
    {
        playerTurnTickets = GameController.playerTurn;



        //if (hubLocation[playerTurnTickets - 1] == 1)
        //{
        //    Object.GetComponent<MeshRenderer>().material = Hub1;
        //}

        //if (hubLocation[playerTurnTickets - 1] == 2)
        //{
        //    Object.GetComponent<MeshRenderer>().material = Hub2;
        //}

        //if (hubLocation[playerTurnTickets - 1] == 3)
        //{
        //    Object.GetComponent<MeshRenderer>().material = Hub3;
        //}


    }
    void Update()
    {
        pLocation = GlobalController.Instance.pLocation;
        hubLocation = GlobalController.Instance.hubLocation;

    }

    public void Hub1Click()
    {
      //Object.GetComponent<MeshRenderer>().material = Hub1;


    }
    public void Hub2Click()
    {
        //Object.GetComponent<MeshRenderer>().material = Hub2;


    }
    public void Hub3Click()
    {
        //Object.GetComponent<MeshRenderer>().material = Hub3;


    }
}

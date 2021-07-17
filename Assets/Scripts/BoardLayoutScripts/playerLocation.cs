using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerLocation : MonoBehaviour
{
    public int pLocation = 0;

    //Player 1 Tickets
    public int p1BoatTickets;
    public int p1PlaneTickets;
    public int p1RoadTickets;
    public int p1TrainTickets;

    //Player 2 Tickets
    public int p2BoatTickets;
    public int p2PlaneTickets;
    public int p2RoadTickets;
    public int p2TrainTickets;

    public Transform[] spawnPoint;

    ////Player 1 info to load
    //p1BoatTickets = GameController.p1BoatTickets;
    //p1PlaneTickets = GameController.p1PlaneTickets;
    //p1RoadTickets = GameController.p1RoadTickets;
    //p1TrainTickets = GameController.p1TrainTickets;

    ////Player 2 info to load
    //p2BoatTickets = GameController.p2BoatTickets;
    //p2PlaneTickets = GameController.p2PlaneTickets;
    //p2RoadTickets = GameController.p2RoadTickets;
    //p2TrainTickets = GameController.p2TrainTickets;
    void Start()
    {
        if (pLocation == 1)
        {
            transform.position = spawnPoint[1].position;
        }
    }


    public void Location0()
    {
        pLocation = 0;
        Debug.Log("Brussels");
    }
    public void Location1()
    {
        pLocation = 1;
        Debug.Log("1");
    }
    public void Location2()
    {
        pLocation = 2;
        Debug.Log("2");
    }
    public void Location3()
    {
        pLocation = 3;
        Debug.Log("3");
    }
    public void Location4()
    {
        pLocation = 4;
        Debug.Log("4");
    }
    public void Location5()
    {
        pLocation = 5;
        Debug.Log("5");
    }
    public void Location6()
    {
        pLocation = 6;
        Debug.Log("6");
    }
    public void Location7()
    {
        pLocation = 7;
        Debug.Log("7");
    }
    public void Location8()
    {
        pLocation = 8;
        Debug.Log("8");
    }

}

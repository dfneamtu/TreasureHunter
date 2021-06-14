using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        BoatTicket,
        PlaneTicket,
        TrainTicket,
        RoadTicket

    }
    public ItemType itemType;
    public int amount;
}

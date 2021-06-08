using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseItem : BaseStatItem //BaseItem <- BaseStatItem <- BaseObject
{
    public enum ObjectItems
    {
        RIFLE, //weapons
        DYNAMITE, //munitions
        BULLETS, //munitions
        GLOCK, //weapons
        BRIBEMONEY, //intelligence
        MEDKIT, //health
        DRONE, //Electronics
        NIGHTGOGGLES, //Electronics
        SPYPEN, //Electronics

    }
    private ObjectItems objectItem;
   
    public ObjectItems ObjectItem
    {
        get { return objectItem; }

        set { objectItem = value; }
    }
}
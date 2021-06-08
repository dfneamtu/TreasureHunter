using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStatItem : BaseObject
{
    private int strength;
    private int weapons;
    private int intelligence;
    private int stealth;
    private int munitions;
    private int electronics;
    private int vehiclepiloting;
    private int codebreaking;

    public int Strength
    {
        get { return strength; }
        set { strength = value; }
    }

    public int Weapons
    {
        get { return weapons; }
        set { weapons = value; }
    }

    public int Intelligence
    {
        get { return intelligence; }
        set { intelligence = value; }
    }

    public int Stealth
    {
        get { return stealth; }
        set { stealth = value; }
    }

    public int Munitions
    {
        get { return munitions; }
        set { munitions = value; }
    }

    public int Electronics
    {
        get { return electronics; }
        set { electronics = value; }
    }

    public int VehiclePiloting
    {
        get { return vehiclepiloting; }
        set { vehiclepiloting = value; }
    }

    public int CodeBreaking
    {
        get { return codebreaking; }
        set { codebreaking = value; }
    }
}

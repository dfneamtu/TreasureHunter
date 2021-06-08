using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacterClass
{
    private string characterClassName;
    private string characterClassDescription;
    
    private int tickets;
    private int objects;
    private int mission;
    
    //stats
    //all skills 1-8
    private int strength;
    private int weapons;
    private int intelligence;
    private int stealth;
    private int munitions;
    private int electronics;
    private int vehiclepiloting;
    private int codebreaking;


    public string CharacterClassName {
        get { return characterClassName; }
        set { characterClassName = value; }
    }

    public string CharacterClassDescription
    {
        get { return characterClassDescription; }
        set { characterClassDescription = value; }
    }

    public int Tickets
    {
        get { return tickets; }
        set { tickets = value; }
    }

    public int Objects
    {
        get { return objects; }
        set { objects = value; }
    }

    public int Mission
    {
        get { return mission; }
        set { mission = value; }
    }

    //All player skills
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

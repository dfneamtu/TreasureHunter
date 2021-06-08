using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayerClass : BaseCharacterClass
{
    public BasePlayerClass()
    {
        CharacterClassName = "Player 1";
        CharacterClassDescription = "Basic player class to hold values.";
        Tickets = 0;
        Objects = 0;
        Mission = 0;

        Strength = 0;
        Weapons = 0;
        Intelligence = 0;
        Stealth = 0;
        Munitions = 0;
        Electronics = 0;
        VehiclePiloting = 0;
        CodeBreaking = 0;


}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StateMachine : MonoBehaviour
{
    public enum TurnStates
    {
        START,
        PLAYERCHOICE1,
        PLAYERCHOICE2,
        PLAYERCHOICE3,
        ENEMYCHOICE,
        LOSE,
        WIN

    }

    public TurnStates currentState;


    // Start is called before the first frame update
    void Start()
    {
        currentState = TurnStates.START;
    }

    // Update is called once per frame
    void Update()
    {


        switch (currentState)
        {
            case (TurnStates.START):
                //SET FUNCTIONS
                break;
            case (TurnStates.PLAYERCHOICE1):
                break;
            case (TurnStates.PLAYERCHOICE2):

                break;
            case (TurnStates.PLAYERCHOICE3):

                break;
            case (TurnStates.ENEMYCHOICE):

                break;
            case (TurnStates.LOSE):

                break;
            case (TurnStates.WIN):

                break;
        }
    }
    
   
}

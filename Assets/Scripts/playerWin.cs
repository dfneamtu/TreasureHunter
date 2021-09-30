using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class playerWin : MonoBehaviour
{
    public TMP_Text playerWinner;
    //public GameObject playTravelObj;
    public int[] trophyOne = new int[6];
    public int[] trophyTwo = new int[6];
    public int[] trophyThree = new int[6];
    public int[] trophyFour = new int[6];


    // Update is called once per frame
    void Update()
    {
        trophyOne = GlobalController.Instance.trophyOne;
        trophyTwo = GlobalController.Instance.trophyTwo;
        trophyThree = GlobalController.Instance.trophyThree;
        trophyFour = GlobalController.Instance.trophyFour;


        if (trophyOne[0] >= 3 && trophyTwo[0] >= 3 && trophyThree[0] >= 3 && trophyFour[0] >= 3)
        {
            playerWinner.text = "Player 1 wins!!";
        }

        if (trophyOne[1] >= 3 && trophyTwo[1] >= 3 && trophyThree[1] >= 3 && trophyFour[1] >= 3)
        {
            playerWinner.text = "Player 2 wins!!";
        }

        if (trophyOne[2] >= 3 && trophyTwo[2] >= 3 && trophyThree[2] >= 3 && trophyFour[2] >= 3)
        {
            playerWinner.text = "Player 3 wins!!";
        }

        if (trophyOne[3] >= 3 && trophyTwo[3] >= 3 && trophyThree[3] >= 3 && trophyFour[3] >= 3)
        {
            playerWinner.text = "Player 4 wins!!";
        }

        if (trophyOne[4] >= 3 && trophyTwo[4] >= 3 && trophyThree[4] >= 3 && trophyFour[4] >= 3)
        {
            playerWinner.text = "Player 5 wins!!";
        }

        if (trophyOne[5] >= 3 && trophyTwo[5] >= 3 && trophyThree[5] >= 3 && trophyFour[5] >= 3)
        {
            playerWinner.text = "Player 6 wins!!";
        }
        //playerWin.text = "Player " + playerTurn + " wins!!";
    }
}

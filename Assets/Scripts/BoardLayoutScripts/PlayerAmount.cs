using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAmount : MonoBehaviour
{

    private void Update()
    {
        //delets all playerpreff
        if (Input.GetKey(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
        }
    }


    public void TwoPlayers()
    {
        PlayerPrefs.SetInt("players", 2);
    }

    public void ThreePlayers()
    {
        PlayerPrefs.SetInt("players", 3);
    }

    public void FourPlayers()
    {
        PlayerPrefs.SetInt("players", 4);
    }

    public void FivePlayers()
    {
        PlayerPrefs.SetInt("players", 5);
    }

    public void SixPlayers()
    {
        PlayerPrefs.SetInt("players", 6);
    }


}
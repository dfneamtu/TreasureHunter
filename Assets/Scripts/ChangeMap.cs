using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using TMPro;
using UnityEngine.SceneManagement;

public class ChangeMap : MonoBehaviour
{ 
    public GameObject[] turnHighlighter;
    public GameObject[] playerPrefabs;
    public GameObject[] playerTokens;

    public int playerTurnTickets;
    public int totalPlayers;

    void Start()
    {
        playerTurnTickets = GameController.playerTurn;
        totalPlayers = GameController.maxPlayers;

    }
    void Update()
    {
        switch (playerTurnTickets)
        {

            case 1:
                turnHighlighter[0].gameObject.SetActive(true);
                turnHighlighter[1].gameObject.SetActive(false);
                turnHighlighter[2].gameObject.SetActive(false);
                turnHighlighter[3].gameObject.SetActive(false);
                turnHighlighter[4].gameObject.SetActive(false);
                turnHighlighter[5].gameObject.SetActive(false);

                break;

            case 2:

                turnHighlighter[0].gameObject.SetActive(false);
                turnHighlighter[1].gameObject.SetActive(true);
                turnHighlighter[2].gameObject.SetActive(false);
                turnHighlighter[3].gameObject.SetActive(false);
                turnHighlighter[4].gameObject.SetActive(false);
                turnHighlighter[5].gameObject.SetActive(false);

                break;
            case 3:
                turnHighlighter[0].gameObject.SetActive(false);
                turnHighlighter[1].gameObject.SetActive(false);
                turnHighlighter[2].gameObject.SetActive(true);
                turnHighlighter[3].gameObject.SetActive(false);
                turnHighlighter[4].gameObject.SetActive(false);
                turnHighlighter[5].gameObject.SetActive(false);

                break;
            case 4:

                turnHighlighter[0].gameObject.SetActive(false);
                turnHighlighter[1].gameObject.SetActive(false);
                turnHighlighter[2].gameObject.SetActive(false);
                turnHighlighter[3].gameObject.SetActive(true);
                turnHighlighter[4].gameObject.SetActive(false);
                turnHighlighter[5].gameObject.SetActive(false);

                break;
            case 5:
                turnHighlighter[0].gameObject.SetActive(false);
                turnHighlighter[1].gameObject.SetActive(false);
                turnHighlighter[2].gameObject.SetActive(false);
                turnHighlighter[3].gameObject.SetActive(false);
                turnHighlighter[4].gameObject.SetActive(true);
                turnHighlighter[5].gameObject.SetActive(false);

                break;

            case 6:
                turnHighlighter[0].gameObject.SetActive(false);
                turnHighlighter[1].gameObject.SetActive(false);
                turnHighlighter[2].gameObject.SetActive(false);
                turnHighlighter[3].gameObject.SetActive(false);
                turnHighlighter[4].gameObject.SetActive(false);
                turnHighlighter[5].gameObject.SetActive(true);

                break;

            default:
                //Console.WriteLine("Default case");
                break;

        }


        if (totalPlayers == 2)
        {
            playerPrefabs[0].gameObject.SetActive(true);
            playerPrefabs[1].gameObject.SetActive(true);
            playerPrefabs[2].gameObject.SetActive(false);
            playerPrefabs[3].gameObject.SetActive(false);
            playerPrefabs[4].gameObject.SetActive(false);
            playerPrefabs[5].gameObject.SetActive(false);

            playerTokens[0].gameObject.SetActive(true);
            playerTokens[1].gameObject.SetActive(true);
            playerTokens[2].gameObject.SetActive(false);
            playerTokens[3].gameObject.SetActive(false);
            playerTokens[4].gameObject.SetActive(false);
            playerTokens[5].gameObject.SetActive(false);
        }
        if (totalPlayers == 3)
        {
            playerPrefabs[0].gameObject.SetActive(true);
            playerPrefabs[1].gameObject.SetActive(true);
            playerPrefabs[2].gameObject.SetActive(true);
            playerPrefabs[3].gameObject.SetActive(false);
            playerPrefabs[4].gameObject.SetActive(false);
            playerPrefabs[5].gameObject.SetActive(false);

            playerTokens[0].gameObject.SetActive(true);
            playerTokens[1].gameObject.SetActive(true);
            playerTokens[2].gameObject.SetActive(true);
            playerTokens[3].gameObject.SetActive(false);
            playerTokens[4].gameObject.SetActive(false);
            playerTokens[5].gameObject.SetActive(false);
        }
        if (totalPlayers == 4)
        {
            playerPrefabs[0].gameObject.SetActive(true);
            playerPrefabs[1].gameObject.SetActive(true);
            playerPrefabs[2].gameObject.SetActive(true);
            playerPrefabs[3].gameObject.SetActive(true);
            playerPrefabs[4].gameObject.SetActive(false);
            playerPrefabs[5].gameObject.SetActive(false);

            playerTokens[0].gameObject.SetActive(true);
            playerTokens[1].gameObject.SetActive(true);
            playerTokens[2].gameObject.SetActive(true);
            playerTokens[3].gameObject.SetActive(true);
            playerTokens[4].gameObject.SetActive(false);
            playerTokens[5].gameObject.SetActive(false);
        }
        if (totalPlayers == 5)
        {
            playerPrefabs[0].gameObject.SetActive(true);
            playerPrefabs[1].gameObject.SetActive(true);
            playerPrefabs[2].gameObject.SetActive(true);
            playerPrefabs[3].gameObject.SetActive(true);
            playerPrefabs[4].gameObject.SetActive(true);
            playerPrefabs[5].gameObject.SetActive(false);

            playerTokens[0].gameObject.SetActive(true);
            playerTokens[1].gameObject.SetActive(true);
            playerTokens[2].gameObject.SetActive(true);
            playerTokens[3].gameObject.SetActive(true);
            playerTokens[4].gameObject.SetActive(true);
            playerTokens[5].gameObject.SetActive(false);
        }
        if (totalPlayers == 6)
        {
            playerPrefabs[0].gameObject.SetActive(true);
            playerPrefabs[1].gameObject.SetActive(true);
            playerPrefabs[2].gameObject.SetActive(true);
            playerPrefabs[3].gameObject.SetActive(true);
            playerPrefabs[4].gameObject.SetActive(true);
            playerPrefabs[5].gameObject.SetActive(true);

            playerTokens[0].gameObject.SetActive(true);
            playerTokens[1].gameObject.SetActive(true);
            playerTokens[2].gameObject.SetActive(true);
            playerTokens[3].gameObject.SetActive(true);
            playerTokens[4].gameObject.SetActive(true);
            playerTokens[5].gameObject.SetActive(true);
        }
    }

}

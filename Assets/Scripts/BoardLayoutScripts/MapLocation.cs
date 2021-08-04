using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using TMPro;
using UnityEngine.SceneManagement;

public class MapLocation : MonoBehaviour
{
    public GameObject player0_1;
    public GameObject player0_2;
    public GameObject player0_3;
    public GameObject player0_4;
    public GameObject player0_5;
    public GameObject player0_6;
    public GameObject player1_1;
    public GameObject player1_2;
    public GameObject player1_3;
    public GameObject player1_4;
    public GameObject player1_5;
    public GameObject player1_6;
    public GameObject player2_1;
    public GameObject player2_2;
    public GameObject player2_3;
    public GameObject player2_4;
    public GameObject player2_5;
    public GameObject player2_6;
    public GameObject player3_1;
    public GameObject player3_2;
    public GameObject player3_3;
    public GameObject player3_4;
    public GameObject player3_5;
    public GameObject player3_6;
    public GameObject player4_1;
    public GameObject player4_2;
    public GameObject player4_3;
    public GameObject player4_4;
    public GameObject player4_5;
    public GameObject player4_6;
    public GameObject player5_1;
    public GameObject player5_2;
    public GameObject player5_3;
    public GameObject player5_4;
    public GameObject player5_5;
    public GameObject player5_6;
    public GameObject player6_1;
    public GameObject player6_2;
    public GameObject player6_3;
    public GameObject player6_4;
    public GameObject player6_5;
    public GameObject player6_6;
    public GameObject player7_1;
    public GameObject player7_2;
    public GameObject player7_3;
    public GameObject player7_4;
    public GameObject player7_5;
    public GameObject player7_6;
    public GameObject player8_1;
    public GameObject player8_2;
    public GameObject player8_3;
    public GameObject player8_4;
    public GameObject player8_5;
    public GameObject player8_6;
    public GameObject player9_1;
    public GameObject player9_2;
    public GameObject player9_3;
    public GameObject player9_4;
    public GameObject player9_5;
    public GameObject player9_6;


    public int[] pLocation = new int[6];
    // Start is called before the first frame update
    void Start()
    {
        pLocation = GlobalController.Instance.pLocation;
    }

    // Update is called once per frame
    void Update()
    {
        playerTokens();
    }

    void playerTokens()
    {
        //Location 0
        if (pLocation[0] == 0) {
            player0_1.gameObject.SetActive(true);
        } else
        {
            player0_1.gameObject.SetActive(false);
        }

        if (pLocation[1] == 0) {
            player0_2.gameObject.SetActive(true);
        } else
        {
            player0_2.gameObject.SetActive(false);
        }

        if (pLocation[2] == 0) {
            player0_3.gameObject.SetActive(true);
        } else
        {
            player0_3.gameObject.SetActive(false);
        }

        if (pLocation[3] == 0) {
            player0_4.gameObject.SetActive(true);
        } else
        {
            player0_4.gameObject.SetActive(false);
        }

        if (pLocation[4] == 0) {
            player0_5.gameObject.SetActive(true);
        } else
        {
            player0_5.gameObject.SetActive(false);
        }

        if (pLocation[5] == 0) {
            player0_6.gameObject.SetActive(true);
        } else
        {
            player0_6.gameObject.SetActive(false);
        }

        //Location 1
        if (pLocation[0] == 1)
        {
            player1_1.gameObject.SetActive(true);
        }
        else
        {
            player1_1.gameObject.SetActive(false);
        }

        if (pLocation[1] == 1)
        {
            player1_2.gameObject.SetActive(true);
        }
        else
        {
            player1_2.gameObject.SetActive(false);
        }

        if (pLocation[2] == 1)
        {
            player1_3.gameObject.SetActive(true);
        }
        else
        {
            player1_3.gameObject.SetActive(false);
        }

        if (pLocation[3] == 1)
        {
            player1_4.gameObject.SetActive(true);
        }
        else
        {
            player1_4.gameObject.SetActive(false);
        }

        if (pLocation[4] == 1)
        {
            player1_5.gameObject.SetActive(true);
        }
        else
        {
            player1_5.gameObject.SetActive(false);
        }

        if (pLocation[5] == 1)
        {
            player1_6.gameObject.SetActive(true);
        }
        else
        {
            player1_6.gameObject.SetActive(false);
        }

        //Location 2
        if (pLocation[0] == 2)
        {
            player2_1.gameObject.SetActive(true);
        }
        else
        {
            player2_1.gameObject.SetActive(false);
        }

        if (pLocation[1] == 2)
        {
            player2_2.gameObject.SetActive(true);
        }
        else
        {
            player2_2.gameObject.SetActive(false);
        }

        if (pLocation[2] == 2)
        {
            player2_3.gameObject.SetActive(true);
        }
        else
        {
            player2_3.gameObject.SetActive(false);
        }

        if (pLocation[3] == 2)
        {
            player2_4.gameObject.SetActive(true);
        }
        else
        {
            player2_4.gameObject.SetActive(false);
        }

        if (pLocation[4] == 2)
        {
            player2_5.gameObject.SetActive(true);
        }
        else
        {
            player2_5.gameObject.SetActive(false);
        }

        if (pLocation[5] == 2)
        {
            player2_6.gameObject.SetActive(true);
        }
        else
        {
            player2_6.gameObject.SetActive(false);
        }

        //Location 3
        if (pLocation[0] == 3)
        {
            player3_1.gameObject.SetActive(true);
        }
        else
        {
            player3_1.gameObject.SetActive(false);
        }

        if (pLocation[1] == 3)
        {
            player3_2.gameObject.SetActive(true);
        }
        else
        {
            player3_2.gameObject.SetActive(false);
        }

        if (pLocation[2] == 3)
        {
            player3_3.gameObject.SetActive(true);
        }
        else
        {
            player3_3.gameObject.SetActive(false);
        }

        if (pLocation[3] == 3)
        {
            player3_4.gameObject.SetActive(true);
        }
        else
        {
            player3_4.gameObject.SetActive(false);
        }

        if (pLocation[4] == 3)
        {
            player3_5.gameObject.SetActive(true);
        }
        else
        {
            player3_5.gameObject.SetActive(false);
        }

        if (pLocation[5] == 3)
        {
            player3_6.gameObject.SetActive(true);
        }
        else
        {
            player3_6.gameObject.SetActive(false);
        }

        //Location 4
        if (pLocation[0] == 4)
        {
            player4_1.gameObject.SetActive(true);
        }
        else
        {
            player4_1.gameObject.SetActive(false);
        }

        if (pLocation[1] == 4)
        {
            player4_2.gameObject.SetActive(true);
        }
        else
        {
            player4_2.gameObject.SetActive(false);
        }

        if (pLocation[2] == 4)
        {
            player4_3.gameObject.SetActive(true);
        }
        else
        {
            player4_3.gameObject.SetActive(false);
        }

        if (pLocation[3] == 4)
        {
            player4_4.gameObject.SetActive(true);
        }
        else
        {
            player4_4.gameObject.SetActive(false);
        }

        if (pLocation[4] == 4)
        {
            player4_5.gameObject.SetActive(true);
        }
        else
        {
            player4_5.gameObject.SetActive(false);
        }

        if (pLocation[5] == 4)
        {
            player4_6.gameObject.SetActive(true);
        }
        else
        {
            player4_6.gameObject.SetActive(false);
        }

        //Location 5
        if (pLocation[0] == 5)
        {
            player5_1.gameObject.SetActive(true);
        }
        else
        {
            player5_1.gameObject.SetActive(false);
        }

        if (pLocation[1] == 5)
        {
            player5_2.gameObject.SetActive(true);
        }
        else
        {
            player5_2.gameObject.SetActive(false);
        }

        if (pLocation[2] == 5)
        {
            player5_3.gameObject.SetActive(true);
        }
        else
        {
            player5_3.gameObject.SetActive(false);
        }

        if (pLocation[3] == 5)
        {
            player5_4.gameObject.SetActive(true);
        }
        else
        {
            player5_4.gameObject.SetActive(false);
        }

        if (pLocation[4] == 5)
        {
            player5_5.gameObject.SetActive(true);
        }
        else
        {
            player5_5.gameObject.SetActive(false);
        }

        if (pLocation[5] == 5)
        {
            player5_6.gameObject.SetActive(true);
        }
        else
        {
            player5_6.gameObject.SetActive(false);
        }

        //Location 6
        if (pLocation[0] == 6)
        {
            player6_1.gameObject.SetActive(true);
        }
        else
        {
            player6_1.gameObject.SetActive(false);
        }

        if (pLocation[1] == 6)
        {
            player6_2.gameObject.SetActive(true);
        }
        else
        {
            player6_2.gameObject.SetActive(false);
        }

        if (pLocation[2] == 6)
        {
            player6_3.gameObject.SetActive(true);
        }
        else
        {
            player6_3.gameObject.SetActive(false);
        }

        if (pLocation[3] == 6)
        {
            player6_4.gameObject.SetActive(true);
        }
        else
        {
            player6_4.gameObject.SetActive(false);
        }

        if (pLocation[4] == 6)
        {
            player6_5.gameObject.SetActive(true);
        }
        else
        {
            player6_5.gameObject.SetActive(false);
        }

        if (pLocation[5] == 6)
        {
            player6_6.gameObject.SetActive(true);
        }
        else
        {
            player6_6.gameObject.SetActive(false);
        }

        //Location 7
        if (pLocation[0] == 7)
        {
            player7_1.gameObject.SetActive(true);
        }
        else
        {
            player7_1.gameObject.SetActive(false);
        }

        if (pLocation[1] == 7)
        {
            player7_2.gameObject.SetActive(true);
        }
        else
        {
            player7_2.gameObject.SetActive(false);
        }

        if (pLocation[2] == 7)
        {
            player7_3.gameObject.SetActive(true);
        }
        else
        {
            player7_3.gameObject.SetActive(false);
        }

        if (pLocation[3] == 7)
        {
            player7_4.gameObject.SetActive(true);
        }
        else
        {
            player7_4.gameObject.SetActive(false);
        }

        if (pLocation[4] == 7)
        {
            player7_5.gameObject.SetActive(true);
        }
        else
        {
            player7_5.gameObject.SetActive(false);
        }

        if (pLocation[5] == 7)
        {
            player7_6.gameObject.SetActive(true);
        }
        else
        {
            player7_6.gameObject.SetActive(false);
        }

        //Location 8
        if (pLocation[0] == 8)
        {
            player8_1.gameObject.SetActive(true);
        }
        else
        {
            player8_1.gameObject.SetActive(false);
        }

        if (pLocation[1] == 8)
        {
            player8_2.gameObject.SetActive(true);
        }
        else
        {
            player8_2.gameObject.SetActive(false);
        }

        if (pLocation[2] == 8)
        {
            player8_3.gameObject.SetActive(true);
        }
        else
        {
            player8_3.gameObject.SetActive(false);
        }

        if (pLocation[3] == 8)
        {
            player8_4.gameObject.SetActive(true);
        }
        else
        {
            player8_4.gameObject.SetActive(false);
        }

        if (pLocation[4] == 8)
        {
            player8_5.gameObject.SetActive(true);
        }
        else
        {
            player8_5.gameObject.SetActive(false);
        }

        if (pLocation[5] == 8)
        {
            player8_6.gameObject.SetActive(true);
        }
        else
        {
            player8_6.gameObject.SetActive(false);
        }

        //Location 9
        if (pLocation[0] == 9)
        {
            player9_1.gameObject.SetActive(true);
        }
        else
        {
            player9_1.gameObject.SetActive(false);
        }

        if (pLocation[1] == 9)
        {
            player9_2.gameObject.SetActive(true);
        }
        else
        {
            player9_2.gameObject.SetActive(false);
        }

        if (pLocation[2] == 9)
        {
            player9_3.gameObject.SetActive(true);
        }
        else
        {
            player9_3.gameObject.SetActive(false);
        }

        if (pLocation[3] == 9)
        {
            player9_4.gameObject.SetActive(true);
        }
        else
        {
            player9_4.gameObject.SetActive(false);
        }

        if (pLocation[4] == 9)
        {
            player9_5.gameObject.SetActive(true);
        }
        else
        {
            player9_5.gameObject.SetActive(false);
        }

        if (pLocation[5] == 9)
        {
            player9_6.gameObject.SetActive(true);
        }
        else
        {
            player9_6.gameObject.SetActive(false);
        }
    }
}

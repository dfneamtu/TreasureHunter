using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Skillsp1 : MonoBehaviour
{
    public TMP_Text[] skillTexts = new TMP_Text[8];
    public int[] skillValues = new int[8];

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < 8; i++)
        {
            skillTexts[i] = this.gameObject.transform.GetChild(i).GetComponent<TMP_Text>();
            skillTexts[i].text = skillValues[i].ToString();
        }

    }
}

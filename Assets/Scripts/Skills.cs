using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Random=UnityEngine.Random;

public class Skills : MonoBehaviour
{
	public TMP_Text[] skillTexts = new TMP_Text[8];
    public int[] skillValues = new int[8];
    
    // Start is called before the first frame update
    void Start()
    {
        

    	for (int i = 0; i < 8; i++) 
    	{
    		skillTexts[i] = this.gameObject.transform.GetChild(i).GetComponent<TMP_Text>();
            skillTexts[i].text = "0";
            skillValues[i] = 0;
    	}

    }

    public void addSkills() 
    {
        int skillToLevel = Random.Range(0, 8);
        int experienceGained = ML_Algo.ML();
    
        skillValues[skillToLevel] += experienceGained;
        skillTexts[skillToLevel].text = skillValues[skillToLevel].ToString();

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddSkillsScript : MonoBehaviour
{
	public Button addSkillsButton;
	private Skills parentSkills;
    // Start is called before the first frame update
    void Start()
    {
    	parentSkills = GetComponentInParent<Skills>();
     	addSkillsButton.onClick.AddListener(buttonClicked);   
        Debug.Log("started adds skills script");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void buttonClicked() 
    {
        Debug.Log("button clicked function in add skills script");
    	parentSkills.addSkills();
    }
}
*/
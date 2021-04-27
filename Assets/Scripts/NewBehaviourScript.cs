using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
	public Button thisIsOurBtn;
    // Start is called before the first frame update
    void Start()
    {
    	thisIsOurBtn.onClick.AddListener(ButtonClicked);

    }

    public void ButtonClicked()
    {
    	Debug.Log("it was clicked");
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}

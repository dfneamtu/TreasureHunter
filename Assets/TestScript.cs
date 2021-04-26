using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
	public Text testText; 
	public int currentNum = 0;

    // Start is called before the first frame update
   void Start() 
   {

   		testText = GameObject.Find("Canvas/Text").GetComponent<Text>();
   		//Script script = testText.GetComponent<Script>();
   		testText.text = currentNum.ToString();



   }
    // Update is called once per frame
    void Update()
    {
    	
    }
}

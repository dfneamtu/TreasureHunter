using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        public Text testText;
        public int currentNum = 0;
        testText.text = currentNum.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        currentNum++;
        testText.text = currentNum.ToString();
    }
}

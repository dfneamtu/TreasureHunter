using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public int hubNum;
    public int locationNum;
    public int damage;

    public void enemyDefeated()
    {
      Destroy(this.gameObject);
      Debug.Log("enemy was destroyed");
    }

    // Start is called before the first frame update
    void Start()
    {
      damage = 3;
      hubNum = 1;
      locationNum = 5;
      Debug.Log("enemy start function called");
      Debug.Log("enemy damage is " + damage);
    }

    // Update is called once per frame
    void Update()
    {

    }


}

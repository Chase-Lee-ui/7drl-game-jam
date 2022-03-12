using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo_Manager : MonoBehaviour
{
    //The current count in the combo
    public int comboCount;
    //Time left remaining in combo
    public float timeLeft;
    //Time combo last
    public int comboTime;
    public Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = 0;
        comboCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeLeft <= 0 && timeLeft >= 0)
        {
            timeLeft = timeLeft - Time.deltaTime;
        }
        else 
        {
            comboCount = 0;
        }
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <=0)
        {
            comboCount++;
            timeLeft = comboTime;
        }
    }
}

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
    public int enemyCount;
    public int lateCount;
    // Start is called before the first frame update
    void Start()
    {
        timeLeft = 0;
        comboCount = 0;
        lateCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (timeLeft > 0)
        {
            timeLeft = timeLeft - Time.deltaTime;
        }
        
        if(timeLeft <= 0)
        {
            comboCount = 0;
            timeLeft = 0;
        }

        //if number of enemies changes
        if (enemyCount != lateCount)
        {
            //if enemy died
            if (enemyCount < lateCount)
            {
                comboCount = comboCount + (lateCount - enemyCount);
                timeLeft = comboTime;
            }

            lateCount = enemyCount;
        }
    }
}

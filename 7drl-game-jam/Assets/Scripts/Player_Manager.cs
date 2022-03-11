using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Manager : MonoBehaviour
{
    public GameObject GameOverScreen;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        //if Player health <= 0 make player inactive and turn on gameoverscreen
        //if player is dead destroy this object after loading start screen
    }
}

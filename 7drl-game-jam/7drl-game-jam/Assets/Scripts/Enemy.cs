using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float Health;
    [SerializeField] public float Attack;
    [SerializeField] public float Attack_Speed;
    [SerializeField] public float Movement_Speed;
    [SerializeField] public float Multiplier;
    [SerializeField] public float Range;
    private GameObject Player;

    void Start()
    {
        //Find Player Get Tag
    }

    virtual public void Update()
    {
        // Follow Player
    }
}
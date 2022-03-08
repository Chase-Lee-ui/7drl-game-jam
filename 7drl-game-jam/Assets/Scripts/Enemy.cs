using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public float Health = 20;
    [SerializeField] public float Attack = 10;
    [SerializeField] public float Attack_Speed = 2;
    [SerializeField] public float Movement_Speed = 3;
    [SerializeField] public float Multiplier = 1.0f;
    [SerializeField] public GameObject Range; // Attack Range
    private bool InRange = false;
    private float Timer = 0;
    private bool Moving = true;
    private GameObject Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    virtual public void Update()
    {
        if (Moving) { transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, Time.deltaTime * Movement_Speed); } //Movement

        if(InRange) { Moving = false; }
        //Attack, stop moving when attacking
        Timer += Time.deltaTime;
        if(Timer >= Attack_Speed && InRange)
        {
            Moving = false;

            //Do attack
            Timer = 0;
            //Invoke attack method
        }

    }

    private void Attacking()
    {
        //Attack Animation
        //SetActive invisible object that has 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") { InRange = true; }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player") { InRange = false; }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player") { Player.GetComponent<Player_Movement>().Health -= Attack; }
    }
}
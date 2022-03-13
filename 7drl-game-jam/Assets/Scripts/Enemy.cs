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
    protected bool InRange = false;
    protected float Timer = 0;
    protected bool Moving = true;
    protected GameObject Player;
    protected Combo_Manager combo;
    public AudioSource dead;
    protected bool DeadAlready = false;
    public Collider2D EnemyCollider;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    virtual public void Update()
    {
        if (Moving) { 
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, Time.deltaTime * Movement_Speed); 
        } //Movement
        Vector3 diff = Player.transform.position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        if (InRange) { Moving = false; } else { Moving = true; }
        //Attack, stop moving when attacking
        Timer += Time.deltaTime;
        if(Timer >= Attack_Speed && InRange)
        {
            Moving = false;

            //Do attack
            Attacking();
        }

        if(Health <= 0 && !this.DeadAlready)
        {
            //if have death animation, run animation then do an invoke to destroy this game object
            //add exp/souls to player
            dead.Play();
            DeadAlready = true;
            EnemyCollider.enabled = false;
            Moving = false;
            StartCoroutine(DestroyEnemy());
        }

    }

    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(1.0f);
        Destroy(this.gameObject);
    }

    private void Attacking() //probably change this to a coroutine
    {
        //Attack Animation
        //SetActive invisible object that has 
        Timer = 0;
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player") { InRange = true; }
    }

    protected void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player") { InRange = false; }
    }

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player") { Player.GetComponent<Player_Movement>().Health -= Attack; }
    }
}
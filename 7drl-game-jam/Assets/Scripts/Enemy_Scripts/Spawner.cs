using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : Enemy
{
    public GameObject[] EnemySpawns;
    public Transform SpellSpawner;
    // Update is called once per frame
    public override void Update()
    {
        if (Moving)
        {
            transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, Time.deltaTime * Movement_Speed);
        } //Movement
        Vector3 diff = Player.transform.position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        if (InRange) { Moving = false; } else { Moving = true; }
        //Attack, stop moving when attacking
        Timer += Time.deltaTime;
        if (Timer >= Attack_Speed && InRange)
        {
            Moving = false;

            //Do attack
            StartCoroutine(Attacking());
            Timer = 0;
        }

        if (Health <= 0)
        {
            //if have death animation, run animation then do an invoke to destroy this game object
            Player.GetComponent<Player_Movement>().souls += soulsDrop;
            Player.GetComponent<Player_Movement>().exp += expDrop;

            Destroy(this.gameObject);
        }
    }

    IEnumerator Attacking()
    {
        var spawned = Instantiate(EnemySpawns[Random.Range(0, EnemySpawns.Length)], SpellSpawner.transform.position, this.gameObject.transform.rotation);
        spawned.GetComponent<Enemy>().Attack = this.Attack;
        yield return new WaitForSeconds(Attack_Speed);
        Timer = 0;
    }
}

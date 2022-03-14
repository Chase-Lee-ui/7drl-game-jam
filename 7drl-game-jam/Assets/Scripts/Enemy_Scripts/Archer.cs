using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Archer : Enemy
{
    public GameObject Arrow;
    public Transform ArrowSpawner;
    public AudioSource dead2;

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
            Attacking();
        }

        if (Health <= 0 && !this.DeadAlready)
        {
            //if have death animation, run animation then do an invoke to destroy this game object
            dead2.Play();
            DeadAlready = true;
            EnemyCollider.enabled = false;
            Moving = false;
            StartCoroutine(DestroyEnemy());
        }

        IEnumerator DestroyEnemy()
        {
            yield return new WaitForSeconds(0.5f);
            Destroy(this.gameObject);
        }
    }
    private void Attacking()
    {
        var arrow = Instantiate(Arrow, ArrowSpawner.transform.position, this.gameObject.transform.rotation);
        arrow.GetComponent<Arrow_Projectile>().Damage = this.Attack;
        Timer = 0;
    }
}

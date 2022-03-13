using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : Enemy
{
    public float KaboomTimer;
    public GameObject KaboomHitBox;
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

        if (InRange)
        { 
            Moving = false;
            KaboomTimer -= Time.deltaTime;
            if(KaboomTimer <= 0)
            {
                KaboomHitBox.GetComponent<Kaboomer>().Damage = this.Attack;
                KaboomHitBox.SetActive(true);
            }
        } 

        if (Health <= 0)
        {
            //if have death animation, run animation then do an invoke to destroy this game object
            Destroy(this.gameObject);
        }
    }

}

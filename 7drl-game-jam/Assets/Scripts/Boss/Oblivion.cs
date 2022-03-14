using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oblivion : Enemy
{
    public GameObject[] Lasers;
    public Transform[] LaserSpawner;
    public Transform[] Positions;
    public float Time_To_Move = 0;
    public int PositionToMoveTo = 0;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Moving = false;
    }

    public override void Update()
    {
        Time_To_Move += Time.deltaTime;
        if(Time_To_Move >= 20f)
        {
            PositionToMoveTo = Random.Range(0, Positions.Length);
            Time_To_Move = 0f;
        }
        transform.position = Vector2.MoveTowards(transform.position, Positions[PositionToMoveTo].position, Time.deltaTime * Movement_Speed);

        Vector3 diff = Player.transform.position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        if (InRange) { Moving = false; } else { Moving = true; }
        //Attack, stop moving when attacking

        Timer += Time.deltaTime;
        if (Timer >= Attack_Speed)
        {
            StartCoroutine(BurstAttack());
        }

        if (Health <= 0)
        {
            //if have death animation, run animation then do an invoke to destroy this game object
            Destroy(this.gameObject);
        }
    }

    IEnumerator BurstAttack()
    {
        Attacking();
        yield return new WaitForSeconds(.1f);
        Attacking();
        yield return new WaitForSeconds(.1f);
        Attacking();
        yield return new WaitForSeconds(.1f);
        Attacking();
        yield return new WaitForSeconds(.5f);

        Attacking();
        yield return new WaitForSeconds(.1f);
        Attacking();
        yield return new WaitForSeconds(.1f);
        Attacking();
        yield return new WaitForSeconds(.1f);
    }
    private void Attacking()
    {
        foreach(var lazi in LaserSpawner)
        {
            var laser = Instantiate(Lasers[Random.Range(0, Lasers.Length)], lazi.transform.position, this.gameObject.transform.rotation);
            laser.GetComponent<Arrow_Projectile>().Damage = this.Attack;
        }
        
        Timer = 0;
    }
}

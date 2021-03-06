using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_Projectile : MonoBehaviour
{
    public float Damage = 5.0f;
    public float Speed = 3.0f;
    public GameObject Player;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Vector3 diff = Player.transform.position - transform.position;
        diff.Normalize();

        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
    }
    void Update()
    {
        transform.position += transform.up * Speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            Destroy(this.gameObject);
        }

        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Player_Movement>().Health -= Damage;
            Destroy(this.gameObject);
        }
    }
}

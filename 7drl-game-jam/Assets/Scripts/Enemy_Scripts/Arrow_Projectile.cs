using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_Projectile : MonoBehaviour
{
    public float Damage = 5.0f;
    public float Speed = 3.0f;
    void Update()
    {
        transform.position += transform.up * Speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Weapon : MonoBehaviour
{
    public Player_Movement Player;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.GetComponent<Enemy>().Health -= Player.PlayerDamage;
        }
    }
}

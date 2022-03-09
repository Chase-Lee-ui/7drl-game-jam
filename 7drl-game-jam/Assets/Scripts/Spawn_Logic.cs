using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Logic : MonoBehaviour
{
    public RoomTemplates rmTemplates;
    public GameObject[] Enemies;
    public GameObject Portal;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnEnemies", 2.0f);
    }

    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Enemy") == null)
        {
            Instantiate(Portal, rmTemplates.rooms[0].transform.position, Quaternion.identity);
        }
    }

    void SpawnEnemies()
    {
        Time.timeScale = 0;
        foreach(var rooms in rmTemplates.rooms)
        {
            if(rooms.name != "Entry Room")
            {
                Instantiate(
                    Enemies[Random.Range(0, Enemies.Length)], 
                    rooms.gameObject.transform.position, 
                    Quaternion.identity);
            }
        }
        Time.timeScale = 1;
    }
}

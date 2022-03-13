using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Logic : MonoBehaviour
{
    public RoomTemplates rmTemplates;
    public GameObject[] Enemies;
    public int NumEnemies;
    public GameObject Portal;
    public Combo_Manager combo;
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
        foreach(var rooms in rmTemplates.rooms)
        {
            for(int i = 0; i < NumEnemies; i++)
            {
                if(rooms.name != "Entry Room")
                {
                    var rmPos = new Vector3(
                        rooms.gameObject.transform.position.x + Random.Range(-2.5f, 2.5f),
                        rooms.gameObject.transform.position.y + Random.Range(-2.5f, 2.0f),
                        rooms.gameObject.transform.position.z + Random.Range(-2.5f, 2.0f)
                    );

                    Instantiate(
                        Enemies[Random.Range(0, Enemies.Length)], 
                        rmPos, 
                        Quaternion.identity);
                }
            }
            
        }
       combo.enabled = true;
    }
}

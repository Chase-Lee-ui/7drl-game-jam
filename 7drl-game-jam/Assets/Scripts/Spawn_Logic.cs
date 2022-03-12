using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Logic : MonoBehaviour
{
    public RoomTemplates rmTemplates;
    public GameObject[] Enemies;
    public int NumEnemies;
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
        for(int i = 0; i < NumEnemies; i++)
        {
            var rmPos = new Vector3(
                        rmTemplates.rooms[Random.Range(1, rmTemplates.rooms.Count)].gameObject.transform.position.x,
                        rmTemplates.rooms[Random.Range(1, rmTemplates.rooms.Count)].gameObject.transform.position.y,
                        rmTemplates.rooms[Random.Range(1, rmTemplates.rooms.Count)].gameObject.transform.position.z
                    );

            Instantiate(
                Enemies[Random.Range(0, Enemies.Length)],
                rmPos,
                Quaternion.identity
            );
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn_Logic : MonoBehaviour
{
    public RoomTemplates rmTemplates;
    public GameObject[] Enemies;
    public int NumEnemies;
    public GameObject Portal;
    private float Modifier;
    // Start is called before the first frame update
    void Start()
    {
        this.Modifier = GameObject.Find("PlayerPrefab").GetComponent<Player_Manager>().Modifier;
        NumEnemies = Mathf.CeilToInt(NumEnemies * Modifier);
        StartCoroutine(Buffer());
    }

    IEnumerator Buffer()
    {
        yield return new WaitForSeconds(2.0f);
        SpawnEnemies();
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
                        rmTemplates.rooms[Random.Range(1, rmTemplates.rooms.Count)].gameObject.transform.position.x + Random.Range(-1.5f, 1.5f),
                        rmTemplates.rooms[Random.Range(1, rmTemplates.rooms.Count)].gameObject.transform.position.y + Random.Range(-1.5f, 1.5f),
                        rmTemplates.rooms[Random.Range(1, rmTemplates.rooms.Count)].gameObject.transform.position.z + Random.Range(-1.5f, 1.5f)
                    );

            Instantiate(
                Enemies[Random.Range(0, Enemies.Length)],
                rmPos,
                Quaternion.identity
            );
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Spawn_Logic : MonoBehaviour
{
    public RoomTemplates rmTemplates;
    public GameObject[] Enemies;
    public int NumEnemies;
    public GameObject Portal;
    private bool Portal_Spawned = false;
    private float Modifier;
    public List<GameObject> EnemiesLeft;
    public float Time_Elapsed;
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
        for(int i = 0; i < EnemiesLeft.Count; i++)
        {
            if(EnemiesLeft[i] == null)
            {
                EnemiesLeft.RemoveAt(i);
            }
        }

        Time_Elapsed += Time.deltaTime;
        if(EnemiesLeft.Count == 0 && Time_Elapsed >= 2.1f && Portal_Spawned == false)
        {
            Instantiate(Portal, rmTemplates.rooms[0].gameObject.transform.position, Quaternion.identity);
            Portal_Spawned = true;
        }
    }

    void SpawnEnemies()
    {
        for(int i = 0; i < NumEnemies; i++)
        {
            var pickedRoom = Random.Range(1, rmTemplates.rooms.Count);
            var rmPos = new Vector3(
                        rmTemplates.rooms[pickedRoom].gameObject.transform.position.x + Random.Range(-1f, 1f),
                        rmTemplates.rooms[pickedRoom].gameObject.transform.position.y + Random.Range(-1f, 1f),
                        rmTemplates.rooms[pickedRoom].gameObject.transform.position.z
                    );

            var spawnedEnemy = Instantiate(
                Enemies[Random.Range(0, Enemies.Length)],
                rmPos,
                Quaternion.identity
            ); 

            EnemiesLeft.Add(spawnedEnemy);
        }
    }
}
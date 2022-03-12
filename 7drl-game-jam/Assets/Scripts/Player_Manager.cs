using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Manager : MonoBehaviour
{
    public GameObject GameOverScreen;
    public float Modifier = 1.0f;
    public float ModifyModifier = 1.5f;
    public int LoopCounter = 0;
    public Player_Movement Player;
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Update()
    {
        if(Player.gameObject.activeInHierarchy && Player.Health <= 0)
        {
            Player.gameObject.SetActive(false);

            SceneManager.UnloadSceneAsync("pHUD");

            SceneManager.LoadScene("GameOver", LoadSceneMode.Additive);
        }

        if(SceneManager.GetActiveScene().name == "Start_Screen") { Destroy(this.gameObject); }
        if(SceneManager.GetActiveScene().name == "Shop") { LoopCounter++; Modifier *= ModifyModifier; }
    }
}

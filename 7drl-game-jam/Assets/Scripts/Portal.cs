using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public GameObject[] Options;
    //0 - Option J
    //1 = Option L
    public string[] NextScene;
    protected bool PlayerIsIn;
    public int LoopNum;
    public int CurrentWave;

    void Start()
    {
        LoopNum = GameObject.Find("PlayerPrefab").GetComponent<Player_Manager>().LoopCounter;
    }

    virtual public void Update()
    {
        if(PlayerIsIn)
        {
            if(Input.GetKey(KeyCode.J) && LoopNum < 5)
            {
                SceneManager.LoadScene("Shop", LoadSceneMode.Single);
            }

            if(Input.GetKey(KeyCode.L))
            {
                SceneManager.LoadScene(NextScene[CurrentWave], LoadSceneMode.Single);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            this.PlayerIsIn = true;
            if(LoopNum < 5)
            {
                this.Options[0].gameObject.SetActive(true);
            }
            this.Options[1].gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            this.PlayerIsIn = false;
            this.Options[0].gameObject.SetActive(false);
            this.Options[1].gameObject.SetActive(false);
        }
    }
}

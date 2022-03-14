using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal_End : MonoBehaviour
{
    public bool PlayerIsIn;
    public string NextScene;
    public GameObject Options;
    void Update()
    {
        if(PlayerIsIn)
        {
            if(Input.GetKey(KeyCode.L))
            {
                SceneManager.LoadScene(NextScene, LoadSceneMode.Single);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            this.PlayerIsIn = true;
            this.Options.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag == "Player")
        {
            this.PlayerIsIn = false;
            this.Options.gameObject.SetActive(false);
        }
    }
}

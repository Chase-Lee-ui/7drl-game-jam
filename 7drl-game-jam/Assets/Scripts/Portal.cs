using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public GameObject Options;
    public string NextScene;
    protected bool PlayerIsIn;

    virtual public void Update()
    {
        if(PlayerIsIn)
        {
            if(Input.GetKeyDown("J"))
            {
                SceneManager.LoadScene("Shop", LoadSceneMode.Single);
            }

            if(Input.GetKeyDown("L"))
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

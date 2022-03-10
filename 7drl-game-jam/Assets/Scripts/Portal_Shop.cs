using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal_Shop : Portal
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public override void Update()
    {
        if(PlayerIsIn)
        {
            if(Input.GetKeyDown("L"))
            {
                SceneManager.LoadScene(NextScene, LoadSceneMode.Single);
            }
        }
    }
}

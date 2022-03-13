using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal_Shop : Portal
{
    public override void Update()
    {
        if(PlayerIsIn)
        {
            if(Input.GetKeyDown("L"))
            {
                SceneManager.LoadScene(NextScene[0], LoadSceneMode.Single);
            }
        }
    }
}
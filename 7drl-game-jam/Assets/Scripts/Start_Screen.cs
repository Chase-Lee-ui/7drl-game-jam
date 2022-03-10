using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Screen : MonoBehaviour
{
    public string NextScene;
    public string CreditsScene;
    public void StartGame()
    {
        SceneManager.LoadScene(NextScene, LoadSceneMode.Single);
    }

    public void Credits()
    {
        SceneManager.LoadScene(CreditsScene, LoadSceneMode.Single);
    }

    public void Exit()
    {
        Application.Quit();
    }
}

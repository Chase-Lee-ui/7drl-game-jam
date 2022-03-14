using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBack : MonoBehaviour
{
    public string leave;
    public void back()
    {
        SceneManager.LoadScene(leave, LoadSceneMode.Single);
    }
}

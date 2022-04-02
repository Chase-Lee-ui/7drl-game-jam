using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Rewind : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    public GameObject[] ToSetActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //im thinking win condition prompts wave clear then leads to choice of rewind / continue
        if (!this.Player.gameObject.activeSelf)
        {
            foreach (var obj in ToSetActive)
            {
                obj.gameObject.SetActive(true);
            }
            //rewind would prompt new map (done by just resettitng scene since scene is procedurally generated) so:
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            //continue would increase enemy frequency/variety
                //this option in different script probably

        }
        //concerns = subtlety of option prompt: whether or not blurred background with text saying wave clear 
    }
}

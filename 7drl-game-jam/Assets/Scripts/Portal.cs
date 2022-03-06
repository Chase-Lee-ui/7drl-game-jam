using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public TextMesh Options;
    private bool PlayerIsIn;

    void Update()
    {
        if(PlayerIsIn)
        {
            if(Input.GetKeyDown("J"))
            {
                //return to shop
            }

            if(Input.GetKeyDown("L"))
            {
                //go to next level
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBossDeath : MonoBehaviour
{
    public GameObject Boss;
    public GameObject Portal;
    void Update()
    {
        if(Boss == null)
        {
            Portal.gameObject.SetActive(true);
        }
    }
}

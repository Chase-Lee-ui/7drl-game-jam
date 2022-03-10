using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UImanager : MonoBehaviour
{
    const float maxTimer = 5.0f;

    private GameObject pPlayer;

    //Player stats
    [SerializeField] private float pHealth;
    [SerializeField] private int pLevel;
    [SerializeField] private float pExp;
    [SerializeField] private int pCombo;
    [SerializeField] private int pSouls;
    [SerializeField] private float pTimer;

    //Abilities


    //Other
    [SerializeField] private int wave;

    // Start is called before the first frame update
    void Start()
    {
        //get everything from player script

    }

    // Update is called once per frame
    void Update()
    {
        //get everything from player script

        //Update combo for show
        if (Input.GetKeyDown(KeyCode.Space))
        {
            pCombo++;
            pTimer = maxTimer;
        }

        if (pCombo > 1)
        {
            pTimer -= Time.deltaTime;

            if (pTimer <= 0)
            {
                pTimer = maxTimer;
                pCombo--;
            }
        }

        //Set combo
        string newCombo = "x" + pCombo.ToString();

        GameObject oCombo = GameObject.Find("uiCombo");
        oCombo.GetComponent<TMP_Text>().text = newCombo;

        GameObject oTimer = GameObject.Find("uiTimer");
        oTimer.GetComponent<Image>().fillAmount = pTimer / maxTimer;

        //Set health level exp
        GameObject oLevel = GameObject.Find("uiLevel");
        oLevel.GetComponent<TMP_Text>().text = pLevel.ToString();

        GameObject oHealth = GameObject.Find("uiHealth");
        oHealth.GetComponent<Image>().fillAmount = pHealth;

        GameObject oExp = GameObject.Find("uiExp");
        oExp.GetComponent<Image>().fillAmount = pExp;

        //Set skills
        GameObject oSkill1;
    }
}

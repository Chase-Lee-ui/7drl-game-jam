using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UImanager : MonoBehaviour
{
    const float maxTimer = 5f;
    const float skillOffAlpha = 0.5f;
    const float skillOnAlpha = 0f;

    //Player
    private GameObject pPlayer;
    private Player_Movement pMovement; 

    //Player stats
    [SerializeField] private float pHealth;
    [SerializeField] private int pLevel;
    [SerializeField] private float pExp;
    [SerializeField] private int pCombo;
    [SerializeField] private int pSouls;
    [SerializeField] private float pTimer;
    private bool pDash;

    //Abilities


    //Other
    [SerializeField] private int wave;

    //Children
    private GameObject oCombo;
    private GameObject oTimer;

    private GameObject oLevel;
    private GameObject oHealth;
    private GameObject oExp;

    private GameObject oSkill1;
    private GameObject oSkill1Cool;
    private GameObject oSkill2;
    private GameObject oSkill3;

    // Start is called before the first frame update
    void Start()
    {
        //get player
        pPlayer = GameObject.Find("PlayerPrefab");
        pMovement = pPlayer.GetComponent<Player_Movement>();

        //get child objects
        oCombo = this.transform.Find("Combo/Triangle/Circle/uiCombo").gameObject;
        oTimer = this.transform.Find("Combo/Triangle/Circle/uiTimer").gameObject;
        oLevel = this.transform.Find("Bottom/Back/uiLevel").gameObject;
        oHealth = this.transform.Find("Bottom/Back/uiHealth").gameObject;
        oExp = this.transform.Find("Bottom/Back/uiExp").gameObject;
        oSkill1 = this.transform.Find("Bottom/Back/Skills/uiSkill1").gameObject;
        oSkill1Cool = oSkill1.transform.Find("uiSkill1Cool").gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        //Get combo
        

        //Get health exp
        pHealth = pMovement.Health / pMovement.MaxHealth;

        //Get dash
        pDash = pMovement.dash;

        //Update combo for show
        if (Input.GetKeyDown(KeyCode.RightShift))
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

        oCombo.GetComponent<TMP_Text>().text = newCombo;

        oTimer.GetComponent<Image>().fillAmount = pTimer / maxTimer;

        //Set health level exp
        oLevel.GetComponent<TMP_Text>().text = pLevel.ToString();

        oHealth.GetComponent<Image>().fillAmount = pHealth;

        oExp.GetComponent<Image>().fillAmount = pExp;

        //Set skills
        if (pDash)
        {
            Color oColor = oSkill1Cool.GetComponent<Image>().color;
            oColor.a = skillOffAlpha;
            oSkill1Cool.GetComponent<Image>().color = oColor;
        }
        else
        {
            Color oColor = oSkill1Cool.GetComponent<Image>().color;
            oColor.a = skillOnAlpha;
            oSkill1Cool.GetComponent<Image>().color = oColor;
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UImanager : MonoBehaviour
{
    const float skillOffAlpha = 0.5f;
    const float skillOnAlpha = 0f;

    //Player
    [SerializeField]  private bool hasPlayer;
    private GameObject pPlayer;
    private Player_Movement pMovement;
    private Combo_Manager pCombo;

    //Player stats
    [SerializeField] private float pHealth;
    [SerializeField] private int pLevel;

    [SerializeField] private float pExp;
    [SerializeField] private int pComboNum;
    [SerializeField] private float pTimerMax;
    [SerializeField] private int pSouls;

    private int pHealthNum;
    private float pTimer;
    private int pExpNum;

    //Abilities
    private bool pDash;

    //Other
    [SerializeField] private int pWave;

    //Children
    private GameObject oCombo;
    private GameObject oTimer;

    private GameObject oLevel;
    private GameObject oHealth;
    private GameObject oHealthNum;
    private GameObject oExp;

    private GameObject oSkill1;
    private GameObject oSkill1Cool;
    private GameObject oSkill2;
    private GameObject oSkill3;

    private GameObject oWave;
    private GameObject oSoul;

    // Start is called before the first frame update
    void Start()
    {
        //get player
        GetPlayerRef();

        //get child objects
        GetChildRef();

        //get wave
        UpdateWave();
    }

    // Update is called once per frame
    void Update()
    {
        //Get level health exp 
        if (hasPlayer)
        {
            //pLevel = pMovement
            pHealth = pMovement.Health / pMovement.MaxHealth;
            pHealthNum = (int)pMovement.Health;

        }
        else
        {
            float x = pHealth * 100;
            pHealthNum = (int)(x);
        }

        //Get exp
        // if (hasPlayer)
        // {
        //     pExp = pMovement.exp / pMovement.MaxExp;
        // }

        //Get souls
        if (hasPlayer)
        {
            pSouls = pMovement.souls;
        }
        //Get dash
        if (hasPlayer)
            pDash = pMovement.dash;

        //Update combo
        UpdateCombo();

        //Set combo
        string newCombo = "x" + pComboNum.ToString();

        oCombo.GetComponent<TMP_Text>().text = newCombo;

        oTimer.GetComponent<Image>().fillAmount = pTimer / pTimerMax;

        //Set health level exp
        oLevel.GetComponent<TMP_Text>().text = pLevel.ToString();

        oHealth.GetComponent<Image>().fillAmount = pHealth;
        oHealthNum.GetComponent<TMP_Text>().text = pHealthNum.ToString();

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

        //Set wave souls
        if (pWave == 99)
            oWave.GetComponent<TMP_Text>().text = "FINAL";
        else
            oWave.GetComponent<TMP_Text>().text = pWave.ToString();

        oSoul.GetComponent<TMP_Text>().text = pSouls.ToString();
    }

    //Saves all necessary player references, or sets hasPlayer to true if none
    private void GetPlayerRef()
    {
        pPlayer = GameObject.Find("PlayerPrefab");

        if (pPlayer)
        {
            hasPlayer = true;
            pMovement = pPlayer.GetComponentInChildren<Player_Movement>();
            pCombo = pPlayer.GetComponentInChildren<Combo_Manager>();
            pTimerMax = pCombo.comboTime;
        }
        else
        {
            hasPlayer = false;
        }

    }

    //Saves all necessary UI object references
    private void GetChildRef()
    {
        oCombo = this.transform.Find("Combo/Triangle/Circle/uiCombo").gameObject;
        oTimer = this.transform.Find("Combo/Triangle/Circle/uiTimer").gameObject;
        oLevel = this.transform.Find("Bottom/Back/uiLevel").gameObject;
        oHealth = this.transform.Find("Bottom/Back/uiHealth").gameObject;
        oHealthNum = this.transform.Find("Bottom/Back/uiHealth/uiHealthNum").gameObject;
        oExp = this.transform.Find("Bottom/Back/uiExp").gameObject;
        oSkill1 = this.transform.Find("Bottom/Back/Skills/uiSkill1").gameObject;
        oSkill1Cool = oSkill1.transform.Find("uiSkill1Cool").gameObject;
        oWave = this.transform.Find("BottomRight/Back/uiWaveNum").gameObject;
        oSoul = this.transform.Find("BottomRight/Back/uiSoulNum").gameObject;
    }

    //Automatically animates the combo meter if no player object found
    private void UpdateCombo()
    {
        if (!hasPlayer)
        {
            if (Input.GetKeyDown(KeyCode.RightShift))
            {
                pComboNum++;
                pTimer = pTimerMax;
            }

            if (pComboNum > 1)
            {
                pTimer -= Time.deltaTime;

                if (pTimer <= 0)
                {
                    pTimer = pTimerMax;
                    pComboNum--;
                }
            }
        }
        else
        {
            pComboNum = pCombo.comboCount;
            pTimer = pCombo.timeLeft;
        }
    }

    private void UpdateWave()
    {
        if (hasPlayer)
        {
            string scene = SceneManager.GetActiveScene().name;

            if (scene == "Final_Boss")
            {
                pWave = 99;
                return;
            }

            string[] x = scene.Split('_');

            if (int.TryParse(x[1], out pWave))
                return;
        }
        
        pWave = -1;
    }
}

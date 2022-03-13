//https://www.youtube.com/watch?v=Oie-G5xuQNA&t=625s
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//using UnityEngine.

public class ShopManagerScript : MonoBehaviour
{

    public int[,] shopUpgrades = new int[10,10];   // ItemCost = [ItemID, Upgrade LVL]
    
    public int[,] shopItem = new int[10,10];   // ItemCost = [ItemID, Upgrade LVL]

    //[SerializeField] public int Souls;
    public Text SoulsTXT;
    public Text RerollCostTXT;
    List<int> threeRandomNumber = new List<int>();
    
    //[SerializeField] List<GameObject> ID_Item = new List<GameObject>();

    public GameObject Player;

    [Header("ID GameObject")]
    [SerializeField] int RerollCost;


    [Header("ID GameObject")]
    [SerializeField] public GameObject[] ID_1ArmorObj;
    [SerializeField] public GameObject[] ID_2AtkSpdObj;
    [SerializeField] public GameObject[] ID_3AtkObj;
    [SerializeField] public GameObject[] ID_4DashObj;
    [SerializeField] public GameObject[] ID_5HpObj;
    [SerializeField] public GameObject[] ID_6WaveAttackObj;
    [SerializeField] public GameObject[] ID_7BoardSwordObj;
    [SerializeField] public GameObject[] ID_8ShortSwordObj;
    [SerializeField] public GameObject[] ID_9VampireAttackObj;

    [Header("Upgrade Cost")]
    [SerializeField] int ID_1ArmorCost;
    [SerializeField] int ID_2AtkSpdCost;
    [SerializeField] int ID_3AtkCost;
    [SerializeField] int ID_4DashCost;
    [SerializeField] int ID_5HpCost;
    [SerializeField] int ID_6WaveAttackCost;
    [SerializeField] int ID_7BoardSwordCost;
    [SerializeField] int ID_8ShortSwordCost;
    [SerializeField] int ID_9VampireAttackCost;
    
    [Header("Upgrade Max Level")]
    [SerializeField] int ID_1ArmorMaxLvl;
    [SerializeField] int ID_2AtkSpdMaxLvl;
    [SerializeField] int ID_3AtkMaxLvl;
    [SerializeField] int ID_4DashMaxLvl;
    [SerializeField] int ID_5HpMaxLvl;
    [SerializeField] int ID_6WaveAttackMaxLvl;
    [SerializeField] int ID_7BoardSwordMaxLvl;
    [SerializeField] int ID_8ShortSwordMaxLvl;
    [SerializeField] int ID_9VampireAttackMaxLvl;

    [Header("Stats")]
    [SerializeField] int ID_1ArmorStatMultiplier;
    [SerializeField] int ID_2AtkSpdStatMultiplier;
    [SerializeField] int ID_3AtkStatMultiplier;
    [SerializeField] int ID_4DashStatMultiplier;
    [SerializeField] int ID_5HpStatMultiplier;
    [SerializeField] int ID_6WaveAttackStatMultiplier;
    [SerializeField] int ID_7BoardSwordStatMultiplier;
    [SerializeField] int ID_8ShortSwordStatMultiplier;
    [SerializeField] int ID_9VampireAttackStatMultiplier;


    // Start is called before the first frame update
    void Start()
    {
        //Souls = Player.souls;
        //Souls = Player.GetComponent<Player_Movement>().souls.ToString();

        //SoulsTXT.text = "Souls:" + Souls.ToString();
        SoulsTXT.text = "Souls: " + Player.GetComponent<Player_Movement>().souls.ToString();
        RerollCostTXT.text = "Reroll Cost: " + RerollCost.ToString();

        // ID's
        shopUpgrades[1, 1] = 1;        //Armor Upgrade
        shopUpgrades[1, 2] = 2;        //Atk Spd Upgrade
        shopUpgrades[1, 3] = 3;        //Atk Upgrade
        shopUpgrades[1, 4] = 4;        //Dash Upgrade
        shopUpgrades[1, 5] = 5;        //HP Upgrade
        shopUpgrades[1, 6] = 6;        //Wave Attack
        shopUpgrades[1, 7] = 7;        //Board Sword
        shopUpgrades[1, 8] = 8;        //Short Sword
        shopUpgrades[1, 9] = 9;        //Vampire Atk

        // Price 
        shopUpgrades[2, 1] = ID_1ArmorCost;
        shopUpgrades[2, 2] = ID_2AtkSpdCost;
        shopUpgrades[2, 3] = ID_3AtkCost;
        shopUpgrades[2, 4] = ID_4DashCost;
        shopUpgrades[2, 5] = ID_5HpCost;
        shopUpgrades[2, 6] = ID_6WaveAttackCost;
        shopUpgrades[2, 7] = ID_7BoardSwordCost;
        shopUpgrades[2, 8] = ID_8ShortSwordCost;
        shopUpgrades[2, 9] = ID_9VampireAttackCost;

        // Current Lvl
        shopUpgrades[3, 1] = 0;
        shopUpgrades[3, 2] = 0;
        shopUpgrades[3, 3] = 0;
        shopUpgrades[3, 4] = 0;
        shopUpgrades[3, 5] = 0;
        shopUpgrades[3, 6] = 0;
        shopUpgrades[3, 7] = 0;
        shopUpgrades[3, 8] = 0;
        shopUpgrades[3, 9] = 0;

        // Max Lvl
        shopUpgrades[4, 1] = ID_1ArmorMaxLvl;
        shopUpgrades[4, 2] = ID_2AtkSpdMaxLvl;
        shopUpgrades[4, 3] = ID_3AtkMaxLvl;
        shopUpgrades[4, 4] = ID_4DashMaxLvl;
        shopUpgrades[4, 5] = ID_5HpMaxLvl;
        shopUpgrades[4, 6] = ID_6WaveAttackMaxLvl;
        shopUpgrades[4, 7] = ID_7BoardSwordMaxLvl;
        shopUpgrades[4, 8] = ID_8ShortSwordMaxLvl;
        shopUpgrades[4, 9] = ID_9VampireAttackMaxLvl;

        RandomUpgradeIDCard();

    }

    // Update is called once per frame
    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if(Player.GetComponent<Player_Movement>().souls >= shopUpgrades[2, ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
            Player.GetComponent<Player_Movement>().souls -= shopUpgrades[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
            shopUpgrades[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
            
            switch(ButtonRef.GetComponent<ButtonInfo>().ItemID)
            {
                case 1:
                    //Player.GetComponent<Player_Movement>().Armor = ID_1ArmorStatMultiplier * shopUpgrades[1, 1];
                    Debug.Log("You Bought: Armor");
                    break;
                case 2:
                    Player.GetComponent<Player_Movement>().AttackSpeed = ID_2AtkSpdStatMultiplier * shopUpgrades[1, 2];
                    Debug.Log("You Bought: Attack Speed");
                    break;
                case 3:
                    Player.GetComponent<Player_Movement>().PlayerDamage = ID_3AtkStatMultiplier * shopUpgrades[1, 3];
                    Debug.Log("You Bought: Attack Damage");
                    break;
                case 4:
                    //Player.GetComponent<Player_Movement>().MaxDashes = ID_4DashStatMultiplier * shopUpgrade[1,4];
                    break;
                case 5:
                    Player.GetComponent<Player_Movement>().MaxHealth = ID_5HpStatMultiplier * shopUpgrades[3, 5];
                    Debug.Log("You Bought: Health");
                    break;
                case 6:
                    //TODO: INSERT WAVE ATTACK STATS
                    //Player.GetComponent<Player_Movement>().MaxHealth = ID_5HpStatMultiplier * shopUpgrades[3, 5];
                    Debug.Log("You Bought: Wave Attack");
                    break;
                case 7:
                    //TODO: INSERT BOARDSWORD STATS
                    Debug.Log("You Bought: Board Sword");
                    break;
                case 8:
                    //TODO: INSERT SHORTSWORD STATS
                    Debug.Log("You Bought: Board Sword");
                    break;
            }

            SoulsTXT.text = "Souls:" + Player.GetComponent<Player_Movement>().souls.ToString();
            Debug.Log("You Bought: " + shopUpgrades[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString());
            RandomUpgradeIDCard();
            //ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopUpgrades[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
        }
    }

    public void BuyRoll()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if(Player.GetComponent<Player_Movement>().souls >= RerollCost)
        {
            Player.GetComponent<Player_Movement>().souls -= RerollCost;
            RandomUpgradeIDCard();
        }
        SoulsTXT.text = "Souls: " + Player.GetComponent<Player_Movement>().souls.ToString();
            //ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopUpgrades[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
        
    }

    public void RandomUpgradeIDCard()
    {
        int Rand;
        int Length = 4;
        
        threeRandomNumber = new List<int>(new int[Length]);

        for(int runs = 1; runs < Length; runs++)
        {
            Rand = Random.Range(1, 10);
            
            while(threeRandomNumber.Contains(Rand))
            {
                Rand = Random.Range(1, 10);
                if (shopUpgrades[3, Rand] == shopUpgrades[4, Rand])
                    Rand = Random.Range(1, 10);
            }

            threeRandomNumber[runs] = Rand;
            Debug.Log(threeRandomNumber[runs]);
        }
        // Debug.Log(threeRandomNumber[1]);
        RandomSelectThreeIDCard();
    }


    public void RandomSelectThreeIDCard()
    {        

        int k = 0;
        
        while(k != 3)
        {
            ID_1ArmorObj[k].SetActive(false);
            ID_2AtkSpdObj[k].SetActive(false);
            ID_3AtkObj[k].SetActive(false);
            ID_4DashObj[k].SetActive(false);
            ID_5HpObj[k].SetActive(false);
            ID_6WaveAttackObj[0].SetActive(false);
            ID_7BoardSwordObj[0].SetActive(false);
            ID_8ShortSwordObj[0].SetActive(false);
            ID_9VampireAttackObj[0].SetActive(false);
            k++;     
        }

        foreach(int random in threeRandomNumber)
        {
            switch(random)
            {
                case 1:
                    ID_1ArmorObj[shopUpgrades[3,1]].SetActive(true);
                    Debug.Log("Item 1: Armor");
                    break;
                case 2:
                    ID_2AtkSpdObj[shopUpgrades[3,2]].SetActive(true);
                    Debug.Log("Item 2: Attack Speed");
                    break;
                case 3:
                    ID_3AtkObj[shopUpgrades[3,3]].SetActive(true);
                    Debug.Log("Item 3: Attack Damage");
                    break;
                case 4:
                    ID_4DashObj[shopUpgrades[3,4]].SetActive(true);
                    Debug.Log("Item 4: Dash");
                    break;
                case 5:
                    ID_5HpObj[shopUpgrades[3,5]].SetActive(true);
                    Debug.Log("Item 5: Health");
                    break;
                case 6:
                    ID_6WaveAttackObj[shopUpgrades[3,6]].SetActive(true);
                    Debug.Log("Item 6: Wave Attack");
                    break;
                case 7:
                    ID_7BoardSwordObj[shopUpgrades[3,7]].SetActive(true);
                    Debug.Log("Item 7: Board Sword");
                    break;
                case 8:
                    ID_8ShortSwordObj[shopUpgrades[3,8]].SetActive(true);
                    Debug.Log("Item 8: Board Sword");
                    break;
                case 9:
                    ID_9VampireAttackObj[shopUpgrades[3,9]].SetActive(true);
                    Debug.Log("Item 9: Vampire Attack");
                    break;
            }
        }
    }
}

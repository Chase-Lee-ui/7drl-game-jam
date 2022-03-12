using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManagerScript : MonoBehaviour
{

    public int[,] shopUpgrades = new int[9,9];
    public float souls;
    public Text SoulsTXT;

    // Start is called before the first frame update
    void Start()
    {
        SoulsTXT.text = "Souls:" + souls.ToString();

        // ID's
        shopUpgrades[1, 1] = 1;
        shopUpgrades[1, 2] = 2;
        shopUpgrades[1, 3] = 3;
        shopUpgrades[1, 1] = 4;
        shopUpgrades[1, 2] = 5;
        shopUpgrades[1, 3] = 6;
        shopUpgrades[1, 1] = 7;
        shopUpgrades[1, 2] = 8;


        // Price 
        shopUpgrades[2, 1] = 10;
        shopUpgrades[2, 2] = 20;
        shopUpgrades[2, 3] = 30;
        shopUpgrades[2, 4] = 40;
        shopUpgrades[2, 5] = 50;
        shopUpgrades[2, 6] = 60;
        shopUpgrades[2, 7] = 70;
        shopUpgrades[2, 8] = 80;
    }

    // Update is called once per frame
    public void Buy()
    {
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if(souls >= shopUpgrades[2, ButtonRef.GetComponent<ButtonInfo>().ItemID])
        {
            souls -= shopUpgrades[2, ButtonRef.GetComponent<ButtonInfo>().ItemID];
            shopUpgrades[3, ButtonRef.GetComponent<ButtonInfo>().ItemID]++;
            SoulsTXT.text = "Souls:" + souls.ToString();
            //ButtonRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopUpgrades[3, ButtonRef.GetComponent<ButtonInfo>().ItemID].ToString();
        }
    }
}

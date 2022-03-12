//https://www.youtube.com/watch?v=Oie-G5xuQNA
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonInfo : MonoBehaviour
{
    
    public int ItemID;
    public Text PriceTxt;
    public GameObject ShopManager;

    // Update is called once per frame
    void Update()
    {
        PriceTxt.text = "Price: " + ShopManager.GetComponent<ShopManagerScript>().shopUpgrades[2, ItemID].ToString();

    }
}

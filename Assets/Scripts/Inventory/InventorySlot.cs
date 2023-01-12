using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    [Header("UI Stuff to change")]
    [SerializeField] private TextMeshProUGUI itemNumberText;
    [SerializeField] private Image itemImage;
    // Start is called before the first frame update

    [Header("Variable form the item")]
    public Sprite itemSprite;
    public int numberHeld;
    public string itemDescription;
    public InventoryItem thisItem;
    public InventoryManager thisManager;

    public void Setup(InventoryItem newItem, InventoryManager newManager){
        thisItem = newItem;
        thisManager = newManager;
        if(thisItem){
            itemImage.sprite = thisItem.itemImage;
            itemNumberText.text = ""+ thisItem.numberHeld;
        }
    }
    
    public void ClickedOn(){
        if(thisItem){
            thisManager.SetuDescriptionAndButton(thisItem.itemDescription, thisItem.usable, thisItem);
        }
    }
}
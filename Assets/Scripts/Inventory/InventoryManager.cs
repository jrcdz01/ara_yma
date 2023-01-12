using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    [Header("Inventory Information")]
    public PlayerInventory playerInventory;
    [SerializeField] private GameObject blankInventorySlot;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private GameObject useButton;
    public InventoryItem currentItem;

    //Função que define o texto de descrição e se o botão para usar estara ativo/disponível
    public void SetTextAndButton(string descriptionText, bool setButonActive){

    }
    void MakeInventorySlots(){
        if(playerInventory){
            for(int i = 0; i<playerInventory.myInventory.Count; i++){
                GameObject temp = Instantiate(blankInventorySlot, inventoryPanel.transform.position, Quaternion.identity);
                temp.transform.SetParent(inventoryPanel.transform);
                InventorySlot newSlot = temp.GetComponent<InventorySlot>();
                if(newSlot){
                    newSlot.transform.SetParent(inventoryPanel.transform);
                    newSlot.Setup(playerInventory.myInventory[i], this);
                }
            }
        }
    }

    // Start is called before the first frame update
    void Start(){
        MakeInventorySlots();
        SetTextAndButton("", false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetuDescriptionAndButton(string newDescriptionString, bool isButtonUsable, InventoryItem newItem){
        currentItem = newItem;
        descriptionText.text = newDescriptionString;
        useButton.SetActive(isButtonUsable);
    }

    public void UseButtonPressed(){
        if(currentItem){
            currentItem.Use();
        }
    }
}

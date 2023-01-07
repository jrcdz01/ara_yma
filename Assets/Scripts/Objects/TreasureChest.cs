using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreasureChest : Interactable
{
    // Start is called before the first frame update
    public Item contents;
    public Inventory playerInventory;
    public bool isOpen;
    public Signal raiseItem;
    public GameObject dialogBox;
    public Text dialogText;
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetKeyDown(KeyCode.J) && playerInRange ){
            if(!isOpen){
                OpenChest();
            }else{
                ChestAlredyOpen();
            }
        }
    }

    public void OpenChest(){
        dialogBox.SetActive(true);
        dialogText.text = contents.itemDescription;
        playerInventory.AddItem(contents);
        playerInventory.currentItem = contents;
        raiseItem.Raise();
        isOpen = true;
        // context.Raise();
    }

    public void ChestAlredyOpen(){
        dialogBox.SetActive(false);
        playerInventory.currentItem = null;
        raiseItem.Raise();
    }
}   

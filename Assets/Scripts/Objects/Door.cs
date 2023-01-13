using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Doortype{
    key,
    enemy,
    button
}
public class Door : Interactable {

    [Header("Door variables")]
    public Doortype thisDoorType;
    public bool open = false;
    public Inventory playerInventory;
    public SpriteRenderer doorSprite;
    public BoxCollider2D physicsCollider;
    

    // Update is called once per frame
    void Update()
    {
        if( Input.GetKeyDown(KeyCode.Space)){
            if(playerInRange && thisDoorType == Doortype.key){
                if( playerInventory.numberOfKeys > 0){
                    playerInventory.numberOfKeys--;
                    Open();
                }
            }
        }
    }

    public void Open(){
        open = true;
        physicsCollider.enabled = false;
    }
}

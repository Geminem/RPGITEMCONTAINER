using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChestScript : MonoBehaviour {

    UserInterface userInterface;
    //open lootbox stuff
    [SerializeField] ItemStats itemInChest;
    ItemStats asd;
    Sprite item;
    Sprite itemImage;
    float itemDamage;
    string itemNameString;
    //open lootbox stuff
    // Use this for initialization
  
    void Start () {
        asd = itemInChest;
   
        userInterface = FindObjectOfType<UserInterface>();
        itemImage = itemInChest.GetSprite();//new, previously I did this bit in void Ontrigger and thats why it was fucking up
        itemNameString = itemInChest.giveName();//new
        itemDamage = itemInChest.giveDamage();//new


    }
	
	// Update is called once per frame
	void Update () {
     
        userInterface.openLootPanel();
       
    }
    //when Inside trigger box prompt text and enable lootpanel spawn
    private void OnTriggerEnter2D(Collider2D collision)
    {

        userInterface.getItem(asd);
        
        userInterface.getItemDamage(itemDamage); //new
        userInterface.imgset(itemImage); //new
        userInterface.setItemName(itemNameString);
        userInterface.promptText();
    }
    //destroy lootpanel and (or) text
    private void OnTriggerExit2D(Collider2D collision)
    {
     
        userInterface.destroyBox();
    }



   
       
 
    //get item sprite image
    public Sprite returnImage()
    {
        return itemImage;
    }
    //get damage from iteminside chest


    }

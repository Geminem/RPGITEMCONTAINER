using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UserInterface : MonoBehaviour {
    [SerializeField] GameObject lootPanel;
    [SerializeField] Canvas canvas;
    [SerializeField] GameObject interactText;
    [SerializeField] Image prefabImage;
    ItemStats newitem;
    [SerializeField] Player player;
    string itemName; //new
    float itemDamage;


    public int currentChest;

    GameObject iText;
    float getX, getY;
    GameObject panel;
    //open lootbox stuff
    public bool inBox = false;//is the player inside the chest hitbox
    public bool openedlootPanel = false; // is the lootPanel open?
    
    public void promptText() //prompts use E to interact
    {
        
        iText = Instantiate(interactText, canvas.transform.position, Quaternion.identity);
        iText.transform.SetParent(canvas.transform);
        inBox = true;

    }
    public void destroyBox() //destroys loot panel and (or) interactText
    {
        inBox = false;
        Destroy(panel);
        openedlootPanel = false;
        Destroy(iText);
    }

    void destroyPanel() // for button (futurE)
    {
        Destroy(panel);
    }
    public void openLootPanel()
    {
        if (inBox && Input.GetKeyDown(KeyCode.E) && !openedlootPanel)
        {
            panel = Instantiate(lootPanel, canvas.transform.localPosition, Quaternion.identity);
            panel.transform.SetParent(canvas.transform);
            openedlootPanel = true;
            Destroy(iText);
            Debug.Log(itemName+" is the item inside the chest and " + itemDamage +" is it's damage");
        }
    }


  
  public void imgset(Sprite asd)
    {
        prefabImage.sprite = asd;
    }

   public void setItemName(string namae)
    {
        itemName = namae;
       
    }
    
    public void getItemDamage(float damage)
    {
        itemDamage = damage;
    }

    public void getItem(ItemStats iteem)
    {
        newitem = iteem;
    }

   public void givePlayerItem()
    {
        
        player.setIteminInv(newitem);
        Debug.Log("Player just recieved " + newitem);
    }


}

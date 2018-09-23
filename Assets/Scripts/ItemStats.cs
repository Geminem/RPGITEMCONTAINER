using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[CreateAssetMenu(menuName = "Item")]
public class ItemStats : ScriptableObject
{
    [SerializeField] Sprite itemImage; //new
    [SerializeField] int worldItemID;
    [SerializeField] float Damage;



    public string giveName()
    {
       return name;
       
    }
   

   public float giveDamage()
    {
        return Damage;
    }

    public Sprite GetSprite() //new
    {
        return itemImage;
    }
   
}

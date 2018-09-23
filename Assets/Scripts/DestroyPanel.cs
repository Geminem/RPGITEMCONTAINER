using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPanel : MonoBehaviour {
    //irrelevant\
    UserInterface Uinterface;
    private void Start()
    {
        Uinterface = FindObjectOfType<UserInterface>();
    }
    public void DestroySelf()
    {
        Destroy(gameObject);
    }

    public void buttton()
    
    {
        Uinterface.givePlayerItem();
    }


}

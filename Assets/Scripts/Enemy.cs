using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    Animator animator;
	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();

        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.gameObject.tag!="Ground" && collision.gameObject.tag=="Laser") Destroy(collision.gameObject);
        if (collision.gameObject.tag == "Laser")
        {
            if (animator.GetBool("isWalking") == false)
                animator.SetBool("isWalking", true);
            else
                animator.SetBool("isWalking", false);
        }
    }







}

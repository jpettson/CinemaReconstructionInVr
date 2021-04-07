using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HandleAnim : MonoBehaviour {
    //Script used for testing animations

    private Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }
 
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("playAnim", true);
            anim.Play("ProjectdoorAnim");
            anim.SetBool("playAnim", false);
        }
    }
}


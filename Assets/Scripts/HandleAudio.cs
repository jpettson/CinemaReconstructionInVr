using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class HandleAudio : MonoBehaviour
{
    public AudioSource audio;
   // public AudioClip soundFile;
    // private bool open = false;

    private Interactable interactable;


    private void Awake()
    {
        audio = gameObject.GetComponent<AudioSource>();
        interactable = this.GetComponent<Interactable>();
    }


    private void Start()
    {
        if (interactable)
        {
            audio.Play();

        }
    }

       
    

    // Update is called once per frame
   
}

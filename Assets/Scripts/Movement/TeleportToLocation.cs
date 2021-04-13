using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;
//using UnityEngine.XR.Interaction.Toolkit;

public class TeleportToLocation : MonoBehaviour
{

    public GameObject player;
    //public GameObject entranceDoor;
    public GameObject projectorRoomLocation;

    bool isInside = false;

    private bool state = false;

    bool hastped = false;

    public GameObject handle;

    private Color originalcolor;

    private void Start()
    {
        originalcolor = handle.GetComponent<Renderer>().material.color;
    }
    void Update() {
        state = SteamVR_Input.GetState("X_Button_Press", SteamVR_Input_Sources.LeftHand);
        if (state && isInside) {
            player.transform.position = projectorRoomLocation.transform.position;
        }
    }

    public void OnTriggerEnter(){
        
        isInside = true;
        handle.GetComponent<Renderer>().material.color = new Color32(0,255,40,51);

    }

    public void OnTriggerExit() {
         isInside = false;
         handle.GetComponent<Renderer>().material.color = originalcolor;


     }
 }
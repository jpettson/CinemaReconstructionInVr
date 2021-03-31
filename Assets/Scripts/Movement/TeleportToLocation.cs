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

    void Update() {
        state = SteamVR_Input.GetState("X_Button_Press", SteamVR_Input_Sources.LeftHand);
        if (state && isInside) {
            player.transform.position = projectorRoomLocation.transform.position;
            new WaitForSeconds(5);
        }
    }

    public void OnTriggerEnter(){
        isInside = true;
     }

    public void OnTriggerExit() {
         isInside = false;

    }
}
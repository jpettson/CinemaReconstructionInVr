using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;

public class GroundTriggerProjectorRoom : MonoBehaviour
{
    public GameObject door;
    private Player p;

    private void Start()
    {
        p = Player.instance;
    }

    public void OnTriggerEnter(){
        door.SetActive(true);
        p.GetComponentInChildren<SteamVR_LaserPointer>().enabled = true;
     }
     public void OnTriggerExit(){
        door.SetActive(false);
        p.GetComponentInChildren<SteamVR_LaserPointer>().enabled = false;
    }
}


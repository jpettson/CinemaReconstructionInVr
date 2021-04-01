using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;

public class GroundTriggerProjectorRoom : MonoBehaviour
{
    public GameObject door;
    public GameObject p;

    private void Start()
    {

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


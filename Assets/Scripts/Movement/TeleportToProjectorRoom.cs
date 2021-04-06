using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.Extras;
using Valve.VR.InteractionSystem;
public class TeleportToProjectorRoom : MonoBehaviour
{

    public GameObject player;
    public GameObject entranceDoor;
    public GameObject projectorroomLocation;



    public void Start()
    {
        
        player.GetComponentInChildren<SteamVR_LaserPointer>().PointerClick += PointerClickTeleportToProjectorRoom;

    }

    public void PointerClickTeleportToProjectorRoom(object sender, PointerEventArgs e)
    {
        if (e.target.CompareTag("TeleportDoorEntrance"))
        {
            if (entranceDoor.gameObject.activeSelf)
            {
                player.transform.position = projectorroomLocation.transform.position;
            }
        }
    }
}

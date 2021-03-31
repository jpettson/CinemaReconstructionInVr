using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Mirror;
using UnityEngine.Video;
using Valve.VR;
using Valve.VR.Extras;

public class TeleportToEntrance : MonoBehaviour
{
    public GameObject player;
    public GameObject projectorRoomDoor;
    public GameObject entranceLocation;


    public void Start()
    {
        Player p = Player.instance;
        p.GetComponentInChildren<SteamVR_LaserPointer>().PointerClick += PointerClickTeleportToEntrance;
        
    }

    public void PointerClickTeleportToEntrance(object sender, PointerEventArgs e)
    {
        if (e.target.CompareTag("TeleportDoor"))
        {
            if (projectorRoomDoor.gameObject.activeSelf)
            {
                player.transform.position = entranceLocation.transform.position;
            }
        }
    }
}
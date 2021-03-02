using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToEntrance : MonoBehaviour
{

    public GameObject player;
    public GameObject projectorRoomDoor;
    public GameObject entranceLocation;


    public void OnMouseDown() {

        if(projectorRoomDoor.GetComponent<MeshRenderer>().enabled)
        player.transform.position = entranceLocation.transform.position;
    }
}
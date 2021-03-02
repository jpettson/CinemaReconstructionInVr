using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToProjectorRoom : MonoBehaviour
{

    public GameObject player;
    public GameObject entranceDoor;
    public GameObject projectorRoomLocation;



    public void OnMouseDown() {

        if(entranceDoor.GetComponent<MeshRenderer>().enabled)
        Debug.Log("open door");
        player.transform.position = projectorRoomLocation.transform.position;
    }
}

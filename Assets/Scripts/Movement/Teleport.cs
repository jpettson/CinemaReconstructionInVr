using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    public GameObject player;
    public GameObject door;
    public GameObject teleportLocation;



    public void OnMouseDown() {

        if(door.GetComponent<MeshRenderer>().enabled)
        Debug.Log("open door");
        player.transform.position = teleportLocation.transform.position;
    }
}

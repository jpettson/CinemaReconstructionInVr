using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject player;

    public void OnMouseDown() {
        if(GetComponent<MeshRenderer>().enabled)
        player.transform.position = teleportTarget.transform.position;
    }
}

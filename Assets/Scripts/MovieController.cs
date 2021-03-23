using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.Extras;

public class MovieController : MonoBehaviour
{

    public GameObject movieMenU;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            movieMenU.SetActive(true);
            // movieMenU.GetComponent<Billboard>().cam = other.gameObject.GetComponentInChildren<Camera>().transform;
            other.gameObject.GetComponentInChildren<SteamVR_LaserPointer>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            movieMenU.SetActive(false);
            other.gameObject.GetComponentInChildren<SteamVR_LaserPointer>().enabled = false;
        }
    }
}

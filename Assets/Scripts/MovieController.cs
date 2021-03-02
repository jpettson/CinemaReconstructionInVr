using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovieController : MonoBehaviour
{

    public GameObject movieMenU;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            movieMenU.SetActive(true);
            movieMenU.GetComponent<Billboard>().cam = other.gameObject.GetComponentInChildren<Camera>().transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            movieMenU.SetActive(false);
        }
    }
}

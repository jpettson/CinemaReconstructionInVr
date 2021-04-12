using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class MovementTypeController : MonoBehaviour
{

    public SteamVR_Action_Boolean menuPress = null;
    public GameObject teleport;
    public GameObject teleportPoints;

    private bool usingTeleport = true;

    // Start is called before the first frame update
    void Start()
    {
        teleport.SetActive(true);
        teleportPoints.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (menuPress.GetState(SteamVR_Input_Sources.LeftHand))
        {
            SwitchMovement();
        }
    }

    void SwitchMovement()
    {
        if (usingTeleport)
        {
            teleport.SetActive(false);
            teleportPoints.SetActive(false);

            GetComponent<ContinuousMovement>().enabled = true;

        } else
        {
            teleport.SetActive(true);
            teleportPoints.SetActive(true);

            GetComponent<ContinuousMovement>().enabled = false;
        }


        usingTeleport = !usingTeleport;
        
    }
}

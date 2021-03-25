using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class Tutorial : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    public SteamVR_Action_Boolean menuPress = null;
    public GameObject tutorialScreen;

    // Update is called once per frame
    void Update()
    {
        if (menuPress.GetState(SteamVR_Input_Sources.RightHand))
        {
            tutorialScreen.SetActive(!tutorialScreen.activeSelf);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ToggleKeybind : MonoBehaviour
{
    // Start is called before the first frame update
    public SteamVR_Action_Boolean menuPress = null;

    public GameObject keybindScreen;


    // Update is called once per frame
    void Update()
    {
        if (menuPress.GetStateUp(SteamVR_Input_Sources.RightHand))
        {
            keybindScreen.SetActive(!keybindScreen.activeSelf);
        } 
    }
}

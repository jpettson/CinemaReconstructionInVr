using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ToggleKeybind : MonoBehaviour
{
    // Start is called before the first frame update
    public SteamVR_Action_Boolean menuPress = null;

    public GameObject keybindScreen;

    private float delay = 30f;
    private float currentDelay = 0;

    // Update is called once per frame
    void Update()
    {
        if (menuPress.GetStateUp(SteamVR_Input_Sources.RightHand))
        {
            if (currentDelay == 0)
            {
                keybindScreen.SetActive(!keybindScreen.activeSelf);
                currentDelay = delay;
            } else
            {
                currentDelay -= Time.deltaTime;
            }
            
        } 
    }
}

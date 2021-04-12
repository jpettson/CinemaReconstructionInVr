using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class ChangeOnControllerType : MonoBehaviour
{
    // Start is called before the first frame update
    private string controllerType = "";

    public GameObject riftScreen;
    public GameObject viveScreen;
    public GameObject knucklesScreen;

    void Start()
    {
        Debug.Log(SteamVR.instance.hmd_Type);


        if (controllerType.Equals("rift"))
        {
            riftScreen.SetActive(true);
        }
        else if (controllerType.Equals("knuckles"))
        {
     //       knucklesScreen.SetActive(true);
        } else
        {
            viveScreen.SetActive(true);
        }
    }

}

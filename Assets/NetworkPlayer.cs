using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Mirror;

public class NetworkPlayer : NetworkBehaviour
{
    [SerializeField]
    public Transform head;
    [SerializeField]
    public Transform leftHand;
    [SerializeField]
    public Transform rightHand;

    private Player p;
    // Start is called before the first frame update
    void Start()
    {
        p = Player.instance;
    }

    // Update is called once per frame
    void Update()
    {

        if (isLocalPlayer)
        {
            head.gameObject.SetActive(false);
            leftHand.gameObject.SetActive(false);
            rightHand.gameObject.SetActive(false);


            MapPosition(head, p.hmdTransform);
            if (p.hands[0].handType == Valve.VR.SteamVR_Input_Sources.LeftHand)
            {
                MapPosition(leftHand, p.hands[0].transform);
            }
            else if (p.hands[0].handType == Valve.VR.SteamVR_Input_Sources.RightHand)
            {
                MapPosition(rightHand, p.hands[0].transform);
            }

            if (p.hands[1].handType == Valve.VR.SteamVR_Input_Sources.LeftHand)
            {
                MapPosition(leftHand, p.hands[1].transform);
            }
            else if (p.hands[1].handType == Valve.VR.SteamVR_Input_Sources.RightHand)
            {
                MapPosition(rightHand, p.hands[1].transform);
            }
        }
        

    }

    void MapPosition(Transform target, Transform x)
    {
        target.position = x.position;
        target.rotation = x.rotation;
        
    }
}

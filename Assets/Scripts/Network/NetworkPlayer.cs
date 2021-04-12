using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;
using Mirror;
using UnityEngine.Video;
using Valve.VR;
using Valve.VR.Extras;
using System.IO;

public class NetworkPlayer : NetworkBehaviour
{
    [SerializeField]
    public Transform head;
    [SerializeField]
    public Transform leftHand;
    [SerializeField]
    public Transform rightHand;

    public SteamVR_Action_Boolean pauseButton = SteamVR_Input.GetBooleanAction("PauseButton");
    private VideoScreen videoScreen;
    private Player p;
    private bool isVideoPlaying = false;
    // Start is called before the first frame update
    void Start()
    {
        p = Player.instance;
        videoScreen = VideoScreen.instance;
        p.gameObject.GetComponentInChildren<SteamVR_LaserPointer>().PointerClick += PointerClick;
    }

    // Update is called once per frame
    void Update()
    {

        if (isLocalPlayer)
        {
            p = Player.instance;
            videoScreen = VideoScreen.instance;
            head.gameObject.SetActive(false);
            leftHand.gameObject.SetActive(false);
            rightHand.gameObject.SetActive(false);


            MapPosition(head, p.hmdTransform);
            if (p.hands[0].handType == Valve.VR.SteamVR_Input_Sources.LeftHand)
            {
                MapPosition(leftHand, p.hands[0].gameObject.transform);
            }
            else if (p.hands[0].handType == Valve.VR.SteamVR_Input_Sources.RightHand)
            {
                MapPosition(rightHand, p.hands[0].gameObject.transform);
            }

            if (p.hands[1].handType == Valve.VR.SteamVR_Input_Sources.LeftHand)
            {
                MapPosition(leftHand, p.hands[1].gameObject.transform);
            }
            else if (p.hands[1].handType == Valve.VR.SteamVR_Input_Sources.RightHand)
            {
                MapPosition(rightHand, p.hands[1].gameObject.transform);
            }


            if (Input.GetKey("space") || pauseButton.GetStateUp(SteamVR_Input_Sources.Any))
            {
                CmdPause();
                
                
            }



        }
        

    }


    public void PointerClick(object sender, PointerEventArgs e)
    {
        if (e.target.CompareTag("MovieListItem"))
        {
            
            CmdLoadVideo(Application.streamingAssetsPath + "/" + Path.GetFileName(e.target.gameObject.GetComponent<MovieListItem>().GetFilePath()));
            
        } 
    }


    void MapPosition(Transform target, Transform x)
    {
        target.position = x.position;
        target.rotation = x.rotation;
        
    }


    [Command]
    void CmdPause()
    {
        RpcPause();
    }

    [ClientRpc]
    void RpcPause()
    {
        VideoPlayer videoPlayer = videoScreen.gameObject.GetComponentInChildren<VideoPlayer>();
        
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
        }
        else
        {
            videoPlayer.Play();
        }
        isVideoPlaying = !isVideoPlaying;

        Debug.Log("memerinos");
    }

    [Command]
    void CmdPlay()
    {
        RpcPlay();
    }

    [ClientRpc]
    void RpcPlay()
    {
        VideoPlayer videoPlayer = videoScreen.gameObject.GetComponentInChildren<VideoPlayer>();
        
        if (!videoPlayer.isPlaying)
        {
            videoPlayer.Play();
        }
        Debug.Log("memerinos2");
    }

    [Command]
    public void CmdLoadVideo(string path)
    {
        RpcLoadVideo(path);
    }

    [ClientRpc]
    void RpcLoadVideo(string path)
    {
        //  InitializeVideoPlayer();

        VideoPlayer videoPlayer = videoScreen.gameObject.GetComponentInChildren<VideoPlayer>();
        videoPlayer.url = path;

        videoPlayer.Prepare();

        CmdPlay();
    }
}

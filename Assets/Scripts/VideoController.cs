using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;
using UnityEngine.Video;
public class VideoController : NetworkBehaviour
{
    [SerializeField]
    public VideoPlayer videoPlayer;

    [SyncVar]
    private bool isVideoPlaying = false;
    [SyncVar]
    private long currentFrame;

    private void Start()
    {
        foreach (KeyValuePair<uint, NetworkIdentity> entry in NetworkIdentity.spawned)
        {
            if (entry.Value.netId == GetComponentInParent<NetworkIdentity>().netId + 1)
            {
                videoPlayer = entry.Value.gameObject.GetComponentInChildren<VideoPlayer>();
                Debug.Log(entry.Value.netId);
            }
        }
        if (isVideoPlaying)
        {
            InitializeVideoPlayer();

            Debug.Log("This does not work");
            // videoPlayer.url = Application.dataPath + "/" + NetworkManagerVideo.videoName;
            StartCoroutine(playVideo());
        }
        else
        {
            Debug.Log(isVideoPlaying);
        }
        
    }

    IEnumerator playVideo()
    {
        videoPlayer.url = "C:\\Users\\adam_\\Downloads\\yt1s.com - Rick Astley  Never Gonna Give You Up Video_360p.mp4";

        videoPlayer.Prepare();

        while (!videoPlayer.isPrepared)
        {
            Debug.Log("Preparing Video");
            yield return null;
        }
        videoPlayer.frame = currentFrame;

        videoPlayer.Play();
    }

    public void InitializeVideoPlayer()
    {
        videoPlayer.targetMaterialRenderer = videoPlayer.GetComponentInParent<MeshRenderer>();
    }

    void Update()
    {
        if (isLocalPlayer && Input.GetKeyDown(KeyCode.Space))
        {
            CmdPause();
            
        } else if (isLocalPlayer && Input.GetKeyDown(KeyCode.G))
        {
            
            CmdLoadVideo("C:\\Users\\adam_\\Downloads\\yt1s.com - Rick Astley  Never Gonna Give You Up Video_360p.mp4");
        }
        if (videoPlayer.isPlaying)
        {
            currentFrame = videoPlayer.frame;
        }
    }
   
    [Command]
    void CmdPause()
    {
        RpcPause();
    }

    [ClientRpc]
    void RpcPause()
    {
        Debug.Log("memes");
        isVideoPlaying = !isVideoPlaying;
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
        }
        else
        {
            videoPlayer.Play();
        }
    }


    [Command]
    public void CmdLoadVideo(string path)
    {
        RpcLoadVideo(path);
    }

    [ClientRpc]
    void RpcLoadVideo(string path)
    {
        InitializeVideoPlayer();

        videoPlayer.url = path;

        videoPlayer.Prepare();
    }

}
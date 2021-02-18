using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;
using UnityEngine.Video;
public class VideoController : NetworkBehaviour
{
    public int x;
    [SerializeField]
    public VideoPlayer videoPlayer;

    private void Start()
    {
        foreach (KeyValuePair<uint, NetworkIdentity> entry in NetworkIdentity.spawned)
        {
           if (entry.Value.netId == GetComponentInParent<NetworkIdentity>().netId + 1)
            {
                videoPlayer = entry.Value.gameObject.GetComponentInChildren<VideoPlayer>();
            }
        }
        if (NetworkManagerVideo.isVideoPlaying)
        {
            InitializeVideoPlayer();

            // videoPlayer.url = Application.dataPath + "/" + NetworkManagerVideo.videoName;
            videoPlayer.url = "C:\\Users\\adam_\\Downloads\\yt1s.com - Rick Astley  Never Gonna Give You Up Video_360p.mp4";
            videoPlayer.Prepare();

            videoPlayer.frame = NetworkManagerVideo.currentFrame;
            videoPlayer.Play();
        }
    }

    public void InitializeVideoPlayer()
    {
        Debug.Log(x);
        videoPlayer.targetMaterialRenderer = videoPlayer.GetComponentInParent<MeshRenderer>();
    }

    void Update()
    {
        if (isLocalPlayer && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("memes2");
            CmdPause();
            
        } else if (isLocalPlayer && Input.GetKeyDown(KeyCode.G))
        {
            
            CmdLoadVideo("C:\\Users\\adam_\\Downloads\\yt1s.com - Rick Astley  Never Gonna Give You Up Video_360p.mp4");
        }
        if (videoPlayer.isPlaying)
        {
            NetworkManagerVideo.currentFrame = videoPlayer.frame;
        }
    }
   
    [Command]
    void CmdPause()
    {
        RpcPause();
        NetworkManagerVideo.isVideoPlaying = !NetworkManagerVideo.isVideoPlaying;
    }
    [ClientRpc]
    void RpcPause()
    {
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
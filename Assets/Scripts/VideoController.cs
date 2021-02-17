using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;
using UnityEngine.Video;
public class VideoController : NetworkBehaviour
{
    [SerializeField]
    private GameObject videoPlayerPrefab;
    private VideoPlayer videoPlayer;
    [SerializeField]
    private string path;

    private void Start()
    {
       CmdCreateVideo();        
    }


    void Update()
    {
        if (this.isLocalPlayer && Input.GetKeyDown(KeyCode.Space))
        {
            this.RpcPause();
        }
    }

    public void CmdCreateVideo()
    {
        videoPlayer = GameObject.FindGameObjectWithTag("VideoPlayer").GetComponent<VideoPlayer>();

        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = path;

        videoPlayer.Prepare();

        videoPlayer.Play();
    }

    [ClientRpc]
    void RpcPause()
    {
        if (videoPlayer.isPlaying)
        {
            videoPlayer.Pause();
        } else
        {
            videoPlayer.Play();
        }
    }
}
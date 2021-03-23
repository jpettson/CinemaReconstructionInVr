using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;
using UnityEngine.Video;
using Valve.VR;

public class VideoController : NetworkBehaviour
{

    public VideoPlayer videoPlayer;


    

    [SyncVar]
    private bool isVideoPlaying = false;
    [SyncVar]
    private long currentFrame;

    private void Start()
    {

        videoPlayer = GameObject.FindGameObjectWithTag("VideoPlayer").GetComponent<VideoPlayer>();

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
        if (videoPlayer.isPlaying)
        {
            currentFrame = videoPlayer.frame;
        }
    }

   

}
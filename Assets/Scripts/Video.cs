using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.Video;

using System;

public class Video : MonoBehaviour{

public string path;
private VideoPlayer videoPlayer;
private VideoSource videoSource;
private AudioSource audioSource;

public void Start()
{
    Destroy(videoPlayer);
    Application.runInBackground = true;
    StartCoroutine(playVideo());
}

 public void Update()
 {
      if (Input.GetKeyDown(KeyCode.Space))
     {
         if (videoPlayer.isPlaying) {
            videoPlayer.Pause();
         } else if (videoPlayer.isPaused) {
             videoPlayer.Play();
         }
     }

     if (Input.GetKeyDown(KeyCode.RightArrow)) {
         videoPlayer.frame += 100;
         videoPlayer.Play();
     } else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
         videoPlayer.frame -= 100;
         videoPlayer.Play();
     }

 }

IEnumerator playVideo()
{
    videoPlayer = gameObject.AddComponent<VideoPlayer>();

    videoPlayer.playOnAwake = true;

    videoPlayer.source = VideoSource.Url;
    videoPlayer.url = path;

    videoPlayer.Prepare();

    while (!videoPlayer.isPrepared)
    {
        Debug.Log("Preparing Video");
        yield return null;
    }

    videoPlayer.Play();
}

}

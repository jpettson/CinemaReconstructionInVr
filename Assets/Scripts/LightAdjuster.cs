using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.Video;
using Mirror;


public class LightAdjuster : NetworkBehaviour
{

       public VideoPlayer videoPlayer;
       public float maxIntensity = 3.0f;
       Light lightToDim;
       public bool downDimmer = false;
       public bool upDimmer = true;
       void initialize() {
        videoPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<VideoPlayer>();
        lightToDim = GetComponent<Light>();
        lightToDim.intensity = maxIntensity;
        downDimmer = videoPlayer.isPlaying;
        upDimmer = !videoPlayer.isPlaying;
       }
       public float intestitySpeed = 0.5f; //30 seconds
       private void Update()
       {
        downDimmer = videoPlayer.isPlaying;
        upDimmer = !videoPlayer.isPlaying;
        if(lightToDim){
                if(downDimmer){
                  if(lightToDim.intensity <= 0)   downDimmer = false;
                  lightToDim.intensity -= Time.deltaTime * intestitySpeed;
                } 
                if(upDimmer){
                  if(lightToDim.intensity >= maxIntensity)   upDimmer = false;
                  lightToDim.intensity  += Time.deltaTime * intestitySpeed;
                } 
            }
       }
         
}
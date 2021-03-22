using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightAdjuster : MonoBehaviour {
       public float maxIntensity = 10.0f;
       Light lightToDim;
       float startTime;
       public bool downDimmer = false;
       public bool upDimmer = true;
       void Start() {
        lightToDim = GetComponent<Light>();
        startTime = Time.time;
        lightToDim.intensity = maxIntensity;
       }
       public float intestitySpeed = 0.5f; //30 seconds
       private void Update()
       {
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;
using UnityEngine.Video;
using Valve.VR;

public class LightAdjuster : NetworkBehaviour
{

    public VideoPlayer videoPlayer;



    public GameObject[] walkwaylights;
    public GameObject[] projectorlights;
    public GameObject[] frontlights;
    public GameObject[] ceilinglights;
    public GameObject[] misclights;

    public float intensitySpeed = 0.5f; //30 seconds
    public float frontIntensity = 2f;
    public float walkwayIntensity = 2f;
    public float ceilingIntensity = 3f;
    public float miscIntensity = 0.5f;

    private void Start()
    {

        videoPlayer = GameObject.FindGameObjectWithTag("VideoPlayer").GetComponent<VideoPlayer>();

        walkwaylights = GameObject.FindGameObjectsWithTag("Walkwaylight");
        projectorlights = GameObject.FindGameObjectsWithTag("VideoPlayerlight");
        frontlights = GameObject.FindGameObjectsWithTag("Frontlight");
        ceilinglights = GameObject.FindGameObjectsWithTag("Ceilinglight");    
        misclights = GameObject.FindGameObjectsWithTag("Misclight");

    }

    void Update()
    {
        if (videoPlayer.isPlaying)
        {
            foreach (GameObject light in walkwaylights)
            {
                if (light.GetComponent<Light>().intensity > 0)
                {
                    light.GetComponent<Light>().intensity -= Time.deltaTime * walkwayIntensity;
                }
            }
            foreach (GameObject light in projectorlights)
            {
                light.SetActive(true);
            }
            foreach (GameObject light in frontlights)
            {
                if (light.GetComponent<Light>().intensity > 0)
                {
                    light.GetComponent<Light>().intensity -= Time.deltaTime * frontIntensity;
                }
            }
            foreach (GameObject light in ceilinglights)
            {
                if (light.GetComponent<Light>().intensity > 0)
                {
                    light.GetComponent<Light>().intensity -= Time.deltaTime * ceilingIntensity;
                }
            }
            foreach (GameObject light in misclights)
            {
                if (light.GetComponent<Light>().intensity > 0)
                {
                    light.GetComponent<Light>().intensity -= Time.deltaTime * miscIntensity;
                }
            }

        }
        else if (!videoPlayer.isPlaying)
        {
            foreach (GameObject light in walkwaylights)
            {
                if (light.GetComponent<Light>().intensity <= walkwayIntensity)
                {
                    light.GetComponent<Light>().intensity += Time.deltaTime * walkwayIntensity;
                }
            }
            foreach (GameObject light in projectorlights)
            {
                light.SetActive(false);
            }

            foreach (GameObject light in frontlights)
            {
                if (light.GetComponent<Light>().intensity <= frontIntensity)
                {
                    light.GetComponent<Light>().intensity += Time.deltaTime * frontIntensity;
                }
            }
            foreach (GameObject light in ceilinglights)
            {
                if (light.GetComponent<Light>().intensity <= ceilingIntensity)
                {
                    light.GetComponent<Light>().intensity += Time.deltaTime * ceilingIntensity;
                }
            }
            foreach (GameObject light in misclights)
            {
                if (light.GetComponent<Light>().intensity <= miscIntensity)
                {
                    light.GetComponent<Light>().intensity += Time.deltaTime * miscIntensity;
                }
            }
        }


    }



}
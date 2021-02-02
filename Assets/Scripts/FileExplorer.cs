using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System;

public class FileExplorer : MonoBehaviour
{

    public Video video;

    public AudioSource audioSource;

    string path;
    //Plane plane;

    public void OpenExplorer() {

        path = EditorUtility.OpenFilePanel("Overwrite with mp4", "", "mp4");
        GameObject.Find("Plane1").GetComponent<Video>().path = path;
        GameObject.Find("Plane1").GetComponent<Video>().Start();
    }

    public void Update() {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
        audioSource.volume += 0.25f;
        Debug.Log("UP " + audioSource.volume);
    } else if (Input.GetKeyDown(KeyCode.DownArrow)) {
        audioSource.volume -= 0.25f;
        Debug.Log("DOWN " + audioSource.volume);
    }
    }
 
}
 
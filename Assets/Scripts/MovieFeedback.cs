using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Valve.VR.Extras;
using TMPro;
using Mirror;
using System.IO;
using System.Text.RegularExpressions;
using UnityEngine.UI;

public class MovieFeedback : MonoBehaviour
{
    public GameObject feedbackMenu;
    private Image image;
    public GameObject text;
    private VideoPlayer videoPlayer;
    private TextMeshProUGUI title;
    private string filePath;
    //public Animator anim;
    private List<string> fileNames;


    private bool inside = false;



    public void setText(string textfield)
    {
        text.GetComponent<TextMeshProUGUI>().text = textfield;
    }
    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        //   videoPlayer.targetMaterialRenderer = GetComponentInParent<MeshRenderer>();
        videoPlayer = GameObject.FindGameObjectWithTag("VideoPlayer").GetComponent<VideoPlayer>();

        // image = GetComponent<Image>();
        //text = GetComponentInChildren<Text>();
        // text.GetComponentInChildren<Text>().text = title + "is playing!";

    }

    void Update()
    {

        //videoPlayer = GameObject.FindGameObjectWithTag("VideoPlayer").GetComponent<VideoPlayer>();
        /* if (inside) {
            Debug.Log("Videoplayer is playing?");
        } */
        if (inside && videoPlayer.isPlaying)
        {
            Debug.Log("VIDEO IS PLAYING");
            //anim.SetTrigger("Action");
            feedbackMenu.SetActive(true);
            string path = videoPlayer.url;
            string name = Regex.Replace(Path.GetFileName(path).ToString(), ".mp4", "").Trim();
      
            Debug.Log("TITLE: " + name);
            text.GetComponent<TextMeshProUGUI>().text = name + " is playing!";
            //text.text = name + "is playing!";
        }
        else
        {
            feedbackMenu.SetActive(false);
        }

    }

    /*public void TrimName(string filename)
    {

        string meta = ".mp4";
        if (filename.EndsWith(meta))
        {
           filename= filename.Replace(meta, "");
        
        }
    }*/


    /*  public void Initiate(string filePath)
    {
        this.filePath = filePath;
        Debug.Log(filePath);
        title = GetComponent<TextMeshProUGUI>();
        title.text = Path.GetFileNameWithoutExtension(filePath);
    }  */

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        inside = true;

        /* Debug.Log("ONTRIGGERENTER");
        videoPlayer = GameObject.FindGameObjectWithTag("VideoPlayer").GetComponent<VideoPlayer>();

        if (videoPlayer.isPlaying)
        {
            Debug.Log("VIDEO IS PLAYING");
            //anim.SetTrigger("Action");
            feedbackMenu.SetActive(true);
            string path = videoPlayer.url;
            string name = Path.GetFileName(path).ToString();
            Debug.Log("TITLE: " + name);
            text.GetComponent<Text>().text = name + " is playing!";
            //text.text = name + "is playing!";
        } */
    }

    // Update is called once per frame
    private void OnTriggerExit(Collider other)
    {
        inside = false;
        /* if (!videoPlayer.isPlaying)
        {
            feedbackMenu.SetActive(false);
            other.gameObject.GetComponentInChildren<SteamVR_LaserPointer>().enabled = false;
        } */
    }


    /*  void Update() {

         text.GetComponent<Text>().text = title + "is playing!";
         text.text = title + "is playing!";

     } */
}

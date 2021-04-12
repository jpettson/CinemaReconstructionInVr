using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using Valve.VR.Extras;
using TMPro;
using Mirror;
using System.IO;
using UnityEngine.UI;

public class MovieFeedback : MonoBehaviour
{
    public GameObject feedbackMenu;
    private Image image;
    public Text text;
    private VideoPlayer videoPlayer;
    private TextMeshProUGUI title;
    private string filePath;
    public Animator anim;



    public void setText(string textfield)
    {
        text.text = textfield; 
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


    public void Initiate(string filePath)
    {
        this.filePath = filePath;
        Debug.Log(filePath);
        title = GetComponent<TextMeshProUGUI>();
        title.text = Path.GetFileNameWithoutExtension(filePath);
    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        videoPlayer = GameObject.FindGameObjectWithTag("VideoPlayer").GetComponent<VideoPlayer>();

        if (videoPlayer.isPlaying)
        {
            anim.SetTrigger("Action");
            feedbackMenu.SetActive(true);
            other.gameObject.GetComponentInChildren<SteamVR_LaserPointer>().enabled = true;
           // text.GetComponent<Text>().text = title + "is playing!";
        }
    }

    // Update is called once per frame
    private void OnTriggerExit(Collider other)
    {
        if (!videoPlayer.isPlaying)
        {
            feedbackMenu.SetActive(false);
            other.gameObject.GetComponentInChildren<SteamVR_LaserPointer>().enabled = false;
        }
    }


    void Update() {

        text.GetComponent<Text>().text = title + "is playing!";

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
using Mirror;


public class MovieListItem : MonoBehaviour
{
    // Start is called before the first frame update
    public string filePath;

    private TextMeshProUGUI titleBox;
    private Button btn;

    void Start()
    {
        btn = GetComponentInChildren<Button>();

        //Might have to replace with something else for VR;
        btn.onClick.AddListener(TaskOnClick);


        Rect rT;
        rT = GetComponent<RectTransform>().rect;
        rT.width = GetComponentInParent<RectTransform>().rect.width;
    }

    public void Initiate(string filePath)
    {
        this.filePath = filePath;
        Debug.Log(filePath);
        titleBox = GetComponentInChildren<TextMeshProUGUI>();
        titleBox.text = Path.GetFileNameWithoutExtension(filePath);
    } 



    //Video player in the scene requires the tag "VideoPlayer".
    void TaskOnClick()
    {
        CmdLoadVideo(filePath);
    }

    [Command]
    void CmdLoadVideo(string filePath)
    {
        RpcLoadVideo(filePath);
    }

    [ClientRpc]
    void RpcLoadVideo(string filePath)
    {
        GameObject g = GameObject.FindGameObjectWithTag("VideoPlayer");
        g.GetComponent<Video>().path = filePath;
    }

    
}

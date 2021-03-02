using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
using Mirror;


public class MovieListItem : NetworkBehaviour
{
    // Start is called before the first frame update
    private string filePath;

    private TextMeshProUGUI titleBox;
    private Button btn;

    void Start()
    {
        //btn = GetComponentInChildren<Button>();

        //Might have to replace with something else for VR;
       // btn.onClick.AddListener(TaskOnClick);


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


    void TaskOnClick()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<VideoController>().CmdLoadVideo(filePath);
    }


    public void HighLight()
    {
        transform.GetChild(1).gameObject.SetActive(true);
    }

    public void DeHighLight()
    {
        transform.GetChild(1).gameObject.SetActive(false);
    }



    public string GetFilePath()
    {
        return filePath;
    }



}

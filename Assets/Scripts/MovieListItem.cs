using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;


public class MovieListItem : MonoBehaviour
{
    // Start is called before the first frame update
    public string filePath;

    private TextMeshProUGUI titleBox;
    private Button btn;

    void Start()
    {
        btn = GetComponentInChildren<Button>();
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
        GameObject g = GameObject.FindGameObjectWithTag("VideoPlayer");
        g.GetComponent<Video>().path = filePath;
    }
}

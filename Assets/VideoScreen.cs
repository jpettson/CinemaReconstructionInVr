using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoScreen : MonoBehaviour
{
    private static VideoScreen _instance;

    public static VideoScreen instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }
}

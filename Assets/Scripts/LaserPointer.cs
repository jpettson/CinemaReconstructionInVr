using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.Extras;

public class LaserPointer : MonoBehaviour
{
    public SteamVR_LaserPointer laserPointer;
    private GameObject currentHighlightedObject;


    void Start()
    {
        laserPointer.PointerIn += PointerInside;
        laserPointer.PointerOut += PointerOutside;
    }

    public void PointerInside(object sender, PointerEventArgs e)
    {
        if (e.target.CompareTag("MovieListItem"))
        {
            if (currentHighlightedObject)
            {
                if (currentHighlightedObject != e.target.gameObject)
                {
                    currentHighlightedObject.GetComponent<MovieListItem>().DeHighLight();
                }
            }
            e.target.gameObject.GetComponent<MovieListItem>().HighLight();
            currentHighlightedObject = e.target.gameObject;
        }
    }

    public void PointerOutside(object sender, PointerEventArgs e)
    {
        if (e.target.CompareTag("MovieListItem"))
        {
            if (currentHighlightedObject)
            {
                currentHighlightedObject.GetComponent<MovieListItem>().DeHighLight();
                currentHighlightedObject = null;
            }
        }
    }
}

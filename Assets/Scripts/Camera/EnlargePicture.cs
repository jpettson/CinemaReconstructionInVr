using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnlargePicture : MonoBehaviour
{
    public GameObject picture;
   // public Transform startPosition;
    public GameObject far;
    public GameObject close;

    void update(){
        Vector3 startPosition = far.GetComponent<MeshRenderer>().transform.position;
    }

    public void OnMouseEnter(){
        picture.transform.position = close.transform.position;
      //  picture.transform.localScale += new Vector3(1.1f,1.1f,1.1f);
    }

    public void OnMouseExit(){    
        picture.transform.position = startPosition;
        far.transform position = startPosition;
       // picture.transform.localScale = new Vector3(0,0,0);
    }
}

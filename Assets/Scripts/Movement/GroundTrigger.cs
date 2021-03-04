using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GroundTrigger: MonoBehaviour
{
    public GameObject groundTrigger;
    public GameObject door;

    public void OnTriggerEnter(){
         door.GetComponent<MeshRenderer>().enabled = true;
     }
     public void OnTriggerExit(){
         door.GetComponent<MeshRenderer>().enabled = false;
     }
}

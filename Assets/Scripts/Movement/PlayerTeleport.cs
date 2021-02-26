using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleport : MonoBehaviour
    {
    public Transform teleportTarget;
    public GameObject player;
    
    // Start is called before the first frame update
    void Start(){
       // GetComponent(MeshRenderer).enabled = false;    
    }

    // Update is called once per frame
    void Update() {
       // if (distance < range) { //Checking if player is near enough
         //   GetComponent(MeshRenderer).enabled = true;
        }
     //   else {
       // GetComponent(MeshRenderer).enabled = false;
        //}
  //  }
    void OnMouseDown(){
            // this object was clicked - do something
        player.transform.position = teleportTarget.transform.position;
    }   
    }


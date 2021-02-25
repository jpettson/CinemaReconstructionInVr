using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildColliders : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.tag == "Chair")
        {
            var child = gameObject.GetComponentInChildren<BoxCollider>();
            child.gameObject.AddComponent<BoxCollider>();

        }
  
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

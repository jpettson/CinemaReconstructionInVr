using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddColliderScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

        foreach(Transform childObject in transform)
        {
            Mesh mesh = childObject.gameObject.GetComponent<MeshFilter>().mesh;
            if(mesh != null)
            {
                MeshCollider meshCollider = childObject.gameObject.AddComponent<MeshCollider>();
                meshCollider.sharedMesh = mesh;

            }
        }

        
        }

    // Update is called once per frame
    void Update()
    {


    } 
}

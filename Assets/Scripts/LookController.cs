using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookController : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject VRCamera;
    private float maxDistance = 6f;
    private GameObject currentHighlightedObject;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit hit;
        if (Physics.Raycast(new Vector3(VRCamera.transform.position.x, VRCamera.transform.position.y - 0.02f, VRCamera.transform.position.z), VRCamera.transform.forward, out hit, maxDistance) &&
            (hit.collider.gameObject.CompareTag("LobbyPicture")))
        {

          //  Debug.DrawRay(new Vector3(VRCamera.transform.position.x, VRCamera.transform.position.y - 0.02f, VRCamera.transform.position.z), VRCamera.transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);


            if (currentHighlightedObject)
            {
                if (currentHighlightedObject != hit.collider.gameObject)
                {
                    currentHighlightedObject.GetComponent<EnlargePicture>().Reduce();
                }
            }

            hit.collider.gameObject.GetComponent<EnlargePicture>().Enlarge();
            currentHighlightedObject = hit.collider.gameObject;


        }
    }
}

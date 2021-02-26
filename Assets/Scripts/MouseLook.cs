using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class MouseLook : MonoBehaviour
{
    
    public float mouseSensitivity = 100f;

    int maxDistance = 40;
    public GameObject currentHighlightedObject;



    public Transform playerBody;

    private float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime * 7f;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime * 7f;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);



        // Will contain the information of which object the raycast hit
        RaycastHit hit;

        // if raycast hits, it checks if it hit an object with the tag Player
        if (Physics.Raycast(new Vector3(transform.position.x, transform.position.y-0.05f, transform.position.z), transform.forward, out hit, maxDistance) &&
            (hit.collider.gameObject.CompareTag("MovieListItem")))
        {
            if (currentHighlightedObject)
            {
                if(currentHighlightedObject != hit.collider.gameObject)
                {
                    currentHighlightedObject.GetComponent<MovieListItem>().DeHighLight();
                }
            }

            hit.collider.gameObject.GetComponent<MovieListItem>().HighLight();
            currentHighlightedObject = hit.collider.gameObject;
            

        } else
        {
            currentHighlightedObject.GetComponent<MovieListItem>().DeHighLight();
            currentHighlightedObject = null;
        }
    }


}

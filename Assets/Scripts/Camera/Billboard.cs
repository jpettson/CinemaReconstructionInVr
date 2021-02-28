using UnityEngine;


//A billboard class to ensure that the canvases are being directed towards the camera as the camera.
//
//For this to function as intended the main camera reference must be set in the editor to the Transform cam.
public class Billboard : MonoBehaviour
{
    public Transform cam;

    private void Start()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    void LateUpdate()
    {
        if (cam)
        {
            transform.LookAt(transform.position + cam.forward);
        }
        
    }
}

using UnityEngine;


//A billboard class to ensure that the canvases are being directed towards the camera as the camera.
//
//For this to function as intended the main camera reference must be set in the editor to the Transform cam.
public class Billboard : MonoBehaviour
{
    public Transform cam;


    void LateUpdate()
    {
        transform.LookAt(transform.position + cam.forward);
    }
}

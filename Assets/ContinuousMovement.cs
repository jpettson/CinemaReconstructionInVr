using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;



public class ContinuousMovement : MonoBehaviour
{
    public SteamVR_Action_Boolean movePress = null;
    public SteamVR_Action_Vector2 moveValue = null;


    private CharacterController character;

    public float speed = 0f;
    public float sensitivity = 0.1f;
    public float maxSpeed = 1.0f;
    public float gravity = 9.82f;

    public Transform head;
    public Transform VRCamera;


    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
      //  HandleHead();
        HandleHeight();
        CalculateMovement();
        
    }

    void CalculateMovement()
    {
        Quaternion orientation = CalculateOrientation();
        Vector3 movement = Vector3.zero;

        if (moveValue.axis.magnitude == 0)
        {
            speed = 0;
        }

        speed += moveValue.axis.magnitude * sensitivity;
        speed = Mathf.Clamp(speed, -maxSpeed, maxSpeed);

        movement += orientation * (speed * Vector3.forward);

        movement.y -= gravity * Time.deltaTime;

        character.Move(movement * Time.deltaTime);
    }

    private Quaternion CalculateOrientation() {

        float rotation = Mathf.Atan2(moveValue.axis.x, moveValue.axis.y);
        rotation *= Mathf.Rad2Deg;

        Vector3 orientationEuler = new Vector3(0, head.rotation.eulerAngles.y + rotation, 0);
        return Quaternion.Euler(orientationEuler);


    }


    void HandleHeight()
    {
        float headHeight = Mathf.Clamp(head.localPosition.y, 1, 2);
        character.height = headHeight;

        Vector3 newCenter = Vector3.zero;

        newCenter.y = character.height / 2;
        newCenter.y += character.skinWidth;

        newCenter.x = head.localPosition.x;
        newCenter.z = head.localPosition.z;


        newCenter = Quaternion.Euler(0, -transform.eulerAngles.y, 0) * newCenter;


        character.center = newCenter;


    }

    void HandleHead()
    {
        Vector3 oldPosition = VRCamera.position;
        Quaternion oldRotation = VRCamera.rotation;

        transform.eulerAngles = new Vector3(0.0f, head.rotation.eulerAngles.y, 0.0f);

      //  VRCamera.position = oldPosition;
      //  VRCamera.rotation = oldRotation;
    }
}

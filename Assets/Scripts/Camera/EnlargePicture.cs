using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnlargePicture : MonoBehaviour
{
    public int interpolationFramesCount = 90; // Number of frames to completely interpolate between the 2 positions
    int elapsedFrames = 0;
    private bool isTargeted = false;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector3 startSize;
    private Vector3 endSize;


    private void Start()
    {
        startPosition = transform.localPosition;
        Debug.Log(startPosition);
        endPosition = Vector3.Scale(transform.localPosition, new Vector3(1.08893709328f, 1, 1.054f));
        startSize = transform.localScale;
        endSize = Vector3.Scale(transform.localScale, new Vector3(1.1f, 1.1f, 1.1f));


        //Enlarge();
    }


    void Update()
    {

        if (isTargeted)
        {
            float interpolationRatio = (float)elapsedFrames / interpolationFramesCount;

            if (interpolationRatio < 0.99f)
            {
                Vector3 interpolatedPosition = Vector3.Lerp(startPosition, endPosition, interpolationRatio);
                Vector3 interpolatedSize = Vector3.Lerp(startSize, endSize, interpolationRatio);

                elapsedFrames = (elapsedFrames + 1) % (interpolationFramesCount + 1);  // reset elapsedFrames to zero after it reached (interpolationFramesCount + 1)



                transform.localPosition = interpolatedPosition;
                transform.localScale = interpolatedSize;
            }

            

        }
        
    }

    public void Enlarge()
    {
        isTargeted = true;
    }

    public void Reduce()
    {
        isTargeted = false;
        transform.localScale = startSize;
        transform.localPosition = startPosition;
        elapsedFrames = 0;
    }
}

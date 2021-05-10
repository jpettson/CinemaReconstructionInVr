using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnlargePicture : MonoBehaviour
{
    public int interpolationFramesCount = 120; // Number of frames to completely interpolate between the 2 positions
    int elapsedFrames = 0;
    private bool isTargeted = false;
    public Vector3 startPosition;
    public Vector3 endPosition;
    public Vector3 startSize;
    public Vector3 endSize;



    void Update()
    {

        if (isTargeted)
        {
            Debug.Log("targeted");
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

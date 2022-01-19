using System;
using UnityEngine;
 
/**
 * Multi Resolution Scale Policy Camera.
 *
 * @author Robert Ryu
 * @date 10/13/2014
 */
 
[RequireComponent(typeof(Camera))]
public class MultiScaleCamera : MonoBehaviour
{
    public enum ScalePolicy
    {
        SHOW_ALL,
        EXACT_FIT,
        FIXED_WIDTH,
        FIXED_HEIGHT,
        NO_BORDER,
        STRETCH
    }
 
    public float desiredWidth;
    public float desiredHeight;
    public float pixelsToUnits;
    public ScalePolicy scalePolicy;
 
    void Start()
    {
        if (scalePolicy == ScalePolicy.SHOW_ALL) return;
 
        float desiredRatio = desiredWidth / desiredHeight;
        float currentRatio = (float)Screen.width / (float)Screen.height;
        float differenceInSize = desiredRatio / currentRatio;
        float desiredOrthographicSize = desiredHeight / 2 / pixelsToUnits;
        float targetOrthographicSize = 0.0f;
 
 
        switch (scalePolicy)
        {
            case ScalePolicy.EXACT_FIT:
                Camera.main.aspect = desiredRatio;
                if (currentRatio >= desiredRatio)
                {
                    targetOrthographicSize = desiredOrthographicSize * differenceInSize;
                    
                }
                else
                {
                    targetOrthographicSize = desiredOrthographicSize;
                }
 
                break;
            case ScalePolicy.FIXED_WIDTH:
                targetOrthographicSize = desiredOrthographicSize * differenceInSize;
                break;
 
            case ScalePolicy.FIXED_HEIGHT:
                targetOrthographicSize = desiredOrthographicSize;
                break;
 
            case ScalePolicy.NO_BORDER:
                if (currentRatio >= desiredRatio)
                {
                    
                    targetOrthographicSize = desiredOrthographicSize * differenceInSize;
                }
                else
                {
                    targetOrthographicSize = desiredOrthographicSize;
                }
 
                break;
            case ScalePolicy.STRETCH:
                targetOrthographicSize = desiredOrthographicSize;
                Camera.main.aspect = desiredRatio;
                break;
        }
 
        Camera.main.orthographicSize = targetOrthographicSize;
    }
}
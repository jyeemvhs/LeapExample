using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalmLeftScript : MonoBehaviour
{
    static public Transform palm = null;

    // Start is called before the first frame update
    void Start()
    {
        palm = transform;   //Store transform into a static variable so it can be used from static function.
    }

    // Update is called once per frame
    void Update()
    {
    }

    //Adjust rotation values to be from -180 to 180 degrees.
    public static float GetRotationZ()
    {
        float val = palm.rotation.eulerAngles.z;
        if (val > 180)
            val = val - 360;
        return (val);
    }

    public static float GetDirection()
    {
        float direction = 0;
        if (palm == null)
            return (direction);
        if (!palm.parent.gameObject.activeSelf)
            return (direction);    // return 0 direction if hand is not active.

        float minDegree = 6;
        float valz = GetRotationZ();

        if (valz > minDegree)
        {
            direction = valz * .03f;
        }
        else if (valz < -minDegree)
        {
            direction = valz * .03f;
        }

        return (direction);
    }


    //ADDED CODE
    public static float GetSpeedLeft()
    {
        float speed = 0;
        if (palm == null)
            return (speed);
        if (!palm.parent.gameObject.activeSelf)
            return (speed);    // return 0 speed if hand is not active.

        float minDegree = 6;
        float valx = GetRotationX();

        //Move forward.
        if (valx > minDegree)
        {
            speed = -valx * 4f;
        }
        //Code if you want to be able to move backward.
        else if (valx < -minDegree)
        {
            speed = -valx * .03f;
        }

        return (speed);
    }
    public static float GetRotationX()
    {
        float val = palm.rotation.eulerAngles.x;
        if (val > 180)
            val = val - 360;
        return (val);
    }
}

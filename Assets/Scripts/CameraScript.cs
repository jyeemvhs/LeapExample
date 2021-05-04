using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private float startHeight;


    bool usingLeap = true;

    // Start is called before the first frame update
    void Start()
    {
        startHeight = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        //if (input.anykey)
        // {
        //    usingleap = false;

        //    debug.log("no longer using a leap controller.");
        //}

        // if (usingleap)
        //{


        // float speed = PalmRightScript.GetSpeed();
        //debug.log("" + speed);
        float speed = 0;
        float speedVal = -speed * Time.deltaTime;
        if (Input.GetKey(KeyCode.W))
        {
            speed = 50f;
            speedVal = speed * Time.deltaTime;
        }

        float heightval = 0;
        float height = PalmRightUpDownScript.GetHeight();
        heightval = height * Time.deltaTime * 3f;

        if (Input.GetKey(KeyCode.Space))
        {
            height = 25f;
            heightval = height * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            height = -25f;
            heightval = height * Time.deltaTime;
        }

        //don't go lower than the start height.
        if (transform.position.y < startHeight && heightval < 0)
            heightval = 0;

        transform.Translate(0, heightval, speedVal);

        //float direction = PalmLeftScript.GetDirection();
        float direction = 0;

        float rotz = direction * Time.deltaTime * 180.0f / Mathf.PI;
        if (Input.GetKey(KeyCode.A))
        {
            direction = -1f;
            rotz = direction * Time.deltaTime * 180.0f / Mathf.PI;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction = 1f;
            rotz = direction * Time.deltaTime * 180.0f / Mathf.PI;
        }
        Debug.Log("" + rotz);
        transform.Rotate(0, rotz, 0, Space.Self);      
    }
}

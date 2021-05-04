using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalmRightUpDownScript : MonoBehaviour
{

    static public Transform palm;
    //static public Transform staticTextObj;

    //public Transform textObj;

    static Vector3 startPos;
    static Vector3 newPos;
    static float timeCount;
    static float height;

    // Start is called before the first frame update
    void Start()
    {
        timeCount = 0;
        height = 0;
        palm = transform;
        //staticTextObj = textObj;
    }

    // Update is called once per frame
    void Update()
    {
        timeCount += Time.deltaTime;
    }
    public static Vector3 GetTranslation()
    {
        if (timeCount < 3)
        {
            //staticTextObj.GetComponent<MessageScript>().SetText("Calibrate");
            //staticTextObj.GetComponent<MessageScript>().SetActive(true);

//Calibrate a good origin position for the hand.
            if (palm.parent.gameObject.activeSelf)
                startPos = palm.transform.localPosition;

            return (Vector3.zero);
        }
        else
        {
            if (!palm.parent.gameObject.activeSelf)
            {
//Hand not active so recalibrate.
                timeCount = 0;
                return (Vector3.zero);
            }

            //staticTextObj.GetComponent<MessageScript>().SetActive(false);
//Get the current hand position relative to the calibrated origin position.
            if (palm.parent.gameObject.activeSelf)
                newPos = palm.transform.localPosition - startPos;

            return newPos;
        }
    }


    public static float GetHeight()
    {
        if (palm == null)
        {
            return 0;
        }

        float minDist = .04f;
        float mult = 8f;
        Vector3 handLoc = GetTranslation();

        if (handLoc.y > minDist)
        {
            height = handLoc.y * mult;
        }
        else if (handLoc.y < -minDist)
        {
            height = handLoc.y * mult;
        }
        else
        {
            height = 0;
        }
        
        return (height);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WindowsInput;

public class LeapInputSwitch : MonoBehaviour
{
    InputSimulator IS;
    
    void Start()
    {
        IS = new InputSimulator();
    }  

    void Update()
    {      
            //LEFT PALM FUNCTIONS//
            float directionLeft = PalmLeftScript.GetDirection();
            float rotzLeft = directionLeft * Time.deltaTime * 180.0f / Mathf.PI; // Left Palm Rotation (LEFT & RIGHT)

            float speedLeft = PalmLeftScript.GetSpeedLeft(); //Left Palm Pitch (Z axis rotation)     
            float speedValLeft = -speedLeft * Time.deltaTime;
        
            if (rotzLeft > .6f) //Simulating "D" Key. Tilt hand right.
            {
                IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_D);            
            }

            if (rotzLeft < -.8f) //Simulating "A" Key. Tilt hand left.
            {
                IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_A);
            }
        
            if (speedValLeft < -.008) //Simulating "W" Key. Tilt hand down.
            {
                IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_W);
            }

            if (speedValLeft > 1.5f) //Simulating "S" Key. Tilt hand up.
            {
                IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_S);            
            }

            //RIGHT PALM FUNCTIONS//
            //float directionRight = PalmRightScript.GetDirection();
            //float rotzRight = directionLeft * Time.deltaTime * 180.0f / Mathf.PI; // Left Palm Rotation (LEFT & RIGHT)

            float speedRight = PalmRightScript.GetSpeed(); //Left Palm Pitch (Z axis rotation)     
            float speedValRight = -speedRight * Time.deltaTime;

            float heightVal = 0;
            float height = PalmRightUpDownScript.GetHeight();
            heightVal = height * Time.deltaTime * 3f;

            if (heightVal > .01) //Simulating "SPACE" Key. Lift Right hand up.
            {
                IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.SPACE);
            }
            if (speedValRight < -.15) //Simulating "Z" Key. Lift Left hand up.
            { 
                IS.Keyboard.KeyPress(WindowsInput.Native.VirtualKeyCode.VK_Z);               
            }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ControllerRumble : MonoBehaviour
{
    public static ControllerRumble Instance { get; set; }
  public  Gamepad pad { get;  set; }
    float rumbleTimer;
    // Start is called before the first frame update
    void Start()
    {
       // pad.SetMotorSpeeds(0, 0);
        Instance = this;
    }


    public void RumbleImpulse(float lowFrequency,float hightFrequency,float duration)
    {

        // get ref to our gamepad
        pad = Gamepad.current;

        //if we have a current gamepad
        if(pad != null)
        {

            // startrumble
            pad.SetMotorSpeeds(lowFrequency, hightFrequency);
            rumbleTimer = duration;

        }
    }

    public void RumbleAllImpulse(float lowFrequency, float hightFrequency)
    {

        // get ref to our gamepad
        pad = Gamepad.current;

        //if we have a current gamepad
        if (pad != null)
        {

            // startrumble
            pad.SetMotorSpeeds(lowFrequency, hightFrequency);
          

        }
    }
    // Update is called once per frames
    void Update()
    {
       
       
#if UNITY_EDITOR 
         if (!Application.isPlaying)
        {
            pad.SetMotorSpeeds(0, 0);
        }
#else
       
#endif


        if (rumbleTimer > 0)
        {
            rumbleTimer -= Time.deltaTime;
            if(rumbleTimer <= 0)
            {

                pad.SetMotorSpeeds(0, 0);
            }
            
        }
    }
}

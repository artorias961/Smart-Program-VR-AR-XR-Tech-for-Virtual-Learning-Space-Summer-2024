using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireLogic : MonoBehaviour
{
    public WireEnd1 wireEnd1Script;
    public WireEnd2 wireEnd2Script;
    void Update()
    {
        wire_logic();
    }
     void Start()
    {
        // check if either end is touching a source or a charge
        wireEnd1Script = GetComponentInChildren<WireEnd1>();
        wireEnd2Script = GetComponentInChildren<WireEnd2>();

        
    }


    void wire_logic()
    {

        //save information from wire end 1 & 2 under new name "wireEnd#Transform"
        Transform wireEnd1Transform = transform.Find("wire end 1");
        Transform wireEnd2Transform = transform.Find("wire end 2");
         
        float output; // temp variable to store what we want to consider as the opposite end's output


        // if 1 end is touching a source of voltage, consider the other end an output with that voltage
        if (wireEnd1Script.sourceTouch == true && wireEnd1Script.contactVoltage>0)
        {
            //change tag
            wireEnd1Transform.tag = "wire input";
            wireEnd2Transform.tag = "wire output";
            //assign new output value
            output = wireEnd1Script.contactVoltage;
            wireEnd2Script.outputVoltage = output;
            wireEnd2Script.allowFlow = true;
            Debug.Log("wire end 2 now output with " + output);
            wireEnd1Script.outputVoltage = 0;
        }
        //vice versa
        else if (wireEnd2Script.sourceTouch == true && wireEnd2Script.contactVoltage > 0)
        {
            wireEnd1Transform.tag = "wire output";
            wireEnd2Transform.tag = "wire input";

            output = wireEnd2Script.contactVoltage;
            wireEnd1Script.outputVoltage = output;
            wireEnd1Script.allowFlow = true;
            Debug.Log("wire end 1 now output with " + output);
            wireEnd2Script.outputVoltage = 0;

        }
    }
    public void wire_reset()
    {
        Debug.Log("wire reset activated");
        //save information from wire end 1 & 2 under new name "wireEnd#Transform"
        Transform wireEnd1Transform = transform.Find("wire end 1");
        Transform wireEnd2Transform = transform.Find("wire end 2");

        wireEnd1Transform.tag = "Untagged";
        wireEnd2Transform.tag = "Untagged";
        wireEnd1Script.outputVoltage = 0;
        wireEnd2Script.outputVoltage = 0;

       
    }

    
}

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


    float oldEnd1, oldEnd2 = 0;
    void wire_logic()
    {

        //save information from wire end 1 & 2 under new name "wireEnd#Transform"
        Transform wireEnd1Transform = transform.Find("wire end 1");
        Transform wireEnd2Transform = transform.Find("wire end 2");

        float output;
        float end1Contact = wireEnd1Script.contactVoltage;
        float end2Contact = wireEnd2Script.contactVoltage;


        // if 1 end is touching a source of voltage, consider the other end an output with that voltage
        if (end1Contact > 0)
        {
            

            //change tag
            wireEnd1Transform.tag = "wire input";
            wireEnd2Transform.tag = "wire output";
            //assign new output value
            output = wireEnd1Script.contactVoltage;
            wireEnd2Script.outputVoltage = output;
            Debug.Log("wire end 2 now output with " + output);
        }
        //vice versa
        else if (end2Contact > 0)
        {
            wireEnd1Transform.tag = "wire output";
            wireEnd2Transform.tag = "wire input";

            output = wireEnd2Script.contactVoltage;
            wireEnd1Script.outputVoltage = output;
            Debug.Log("wire end 1 now output with " + output);
        }
    }
        public void wire_reset()
        {
            //save information from wire end 1 & 2 under new name "wireEnd#Transform"
            Transform wireEnd1Transform = transform.Find("wire end 1");
            Transform wireEnd2Transform = transform.Find("wire end 2");
            
            wireEnd1Transform.tag = "Untagged";
            wireEnd2Transform.tag = "Untagged";
            wireEnd1Script.outputVoltage = 0;
            wireEnd2Script.outputVoltage = 0;
        }

    
}

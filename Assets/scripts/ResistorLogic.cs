using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResistorLogic : MonoBehaviour
{
    public ResistorEnd1 resEnd1Script;
    public ResistorEnd2 resEnd2Script;

    public float resistance = 10;
    void Update()
    {
        resistor_logic();
    }
    void Start()
    {
        // check if either end is touching a source or a charge
        resEnd1Script = GetComponentInChildren<ResistorEnd1>();
        resEnd2Script = GetComponentInChildren<ResistorEnd2>();

        float simplifiedResistance = 0; // temp variable to store what we consider as the simplified resistance from up the circuit

    }

    void resistor_logic()
    {

        //save information from wire end 1 & 2 under new name "wireEnd#Transform"
        Transform resEnd1Transform = transform.Find("resistor end 1");
        Transform resEnd2Transform = transform.Find("resistor end 2");



        // if 1 end is touching a source of voltage, consider the other end an output with that voltage
        if (resEnd1Script.sourceTouch == true && resEnd1Script.contactVoltage > 0)
        {
            //change tag
            resEnd1Transform.tag = "resistor input";
            resEnd2Transform.tag = "resistor output";

            // red end 2 will now "carry" teh previous simplified resistance, as well as the new resistance to the breadboard
            /*resEnd2Script.simplifiedResistance = resistance + passedResistance;
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
            Debug.Log("wire end 1 now output with " + output);
            wireEnd2Script.outputVoltage = 0;
*/
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resistor_logc_script : MonoBehaviour
{
    public wire_end1_script wireEnd1Script;
    public wire_end2_script wireEnd2Script;
    void Update()
    {
        wire_logic();
    }

    bool wire1SourceTouch = false;
    bool wire2SourceTouch = false;
    bool wire1ChargeTouch = false;
    bool wire2ChargeTouch = false;


    void wire_logic()
    {
        // check if either end is touching a source or a charge
        wireEnd1Script = GetComponentInChildren<wire_end1_script>();
        wire1SourceTouch = wireEnd1Script.sourceTouch;
        wireEnd2Script = GetComponentInChildren<wire_end2_script>();
        wire2SourceTouch = wireEnd2Script.sourceTouch;

        wireEnd1Script = GetComponentInChildren<wire_end1_script>();
        wire1ChargeTouch = wireEnd1Script.chargeTouch;
        wireEnd2Script = GetComponentInChildren<wire_end2_script>();
        wire2ChargeTouch = wireEnd2Script.chargeTouch;


        float resistance =10;

        // if 1 is touching a source, then 2 is sending the source i.e. is output

        if (wire1SourceTouch == true)
        {
            Transform wireEnd2Transform = transform.Find("wire end 2");
            wireEnd2Transform.tag = "resistor output";
            wireEnd2Script.resistance =resistance;
            Debug.Log("wire end 2 now resitstor with " + resistance);
        }
        //vice versa
        else if (wire2SourceTouch == true)
        {
            Transform wireEnd1Transform = transform.Find("wire end 1");
            wireEnd1Transform.tag = "resistor output";
            wireEnd1Script.resistance = resistance;
            Debug.Log("wire end 1 now resistor with " +resistance);
        }

        // if wire 1 touches active non source bar, carry signal to be output of 2
        else if (wire1ChargeTouch == true)
        {
            Transform wireEnd2Transform = transform.Find("wire end 2");
            wireEnd2Script.resistance = resistance;
            wireEnd2Transform.tag = "resistor output";
            Debug.Log("wire end 2 is now resistor with " + resistance);
        }
        else if (wire2ChargeTouch == true)
        {
            Transform wireEnd1Transform = transform.Find("wire end 1");
            wireEnd1Script.resistance = resistance;
            wireEnd1Transform.tag = "resistor output";
            Debug.Log("wire end 1 is now resistor with " + resistance);
        }




    }
}

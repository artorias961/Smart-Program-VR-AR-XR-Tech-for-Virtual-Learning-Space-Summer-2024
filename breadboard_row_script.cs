using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using Unity.PlasticSCM.Editor.WebApi;
using Unity.VisualScripting;
using UnityEngine;

public class breaboard_row_script : MonoBehaviour
{
    public float rowVoltage=0 ;
    public float outResistance ;
    float voltageDrop ;
    float previousRow = 0;
    bool inTrigger = false;


     void Update()
    {
        if (inTrigger)
        {
            readSourceBar();
        }
    }
    private void readSourceBar()
    {

        //activate RecalculateCurrent fucntion using the newly calculated total resistance
        float totalResistance = transform.parent.Find("source bar").GetComponent<source_bar_script>().totalResistance;
        transform.parent.Find("source bar").GetComponent<source_bar_script>().RecalculateCurrent(totalResistance);

        // save calculated current
        float current = transform.parent.GetComponentInChildren<source_bar_script>().current;

        //calculate voltage drop
        voltageDrop = outResistance * current;
        string vdrop = "vdrop = " + outResistance + " * " + current;
        Debug.Log(vdrop + " = " + voltageDrop);

        
        

        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        inTrigger = true;

        // see if collidng object is labeld as an output, ie is a wire
        if (collision.gameObject.CompareTag("output"))
        {
            Debug.Log(gameObject.name + "is touching an output");

            // check if touching end 2 or end 1
            if (collision.gameObject.name == "wire end 2")
            {
                rowVoltage = collision.gameObject.GetComponent<wire_end2_script>().outputVoltage;
            }
            if (collision.gameObject.name == "wire end 1")
            {
                rowVoltage = collision.gameObject.GetComponent<wire_end1_script>().outputVoltage;
            }
            gameObject.tag = "charged board row";
            Debug.Log(gameObject.transform.name + "is now charged to " + rowVoltage + " volts");
        }
        // check if object is labeled as a resistor output
        if (collision.gameObject.CompareTag("resistor output"))
        {
            Debug.Log(gameObject.name + "is touching an resistor");

            // detect  what resitance of the resistor is 
            if (collision.gameObject.name == "wire end 1")
            {
                 outResistance = collision.gameObject.GetComponent<wire_end1_script>().resistance;
            }
            else if (collision.gameObject.name == "wire end 2")
            {
                outResistance = collision.gameObject.GetComponent<wire_end2_script>().resistance;

            }
            // add component resistance to total resistance acknowldged by circuit
            transform.parent.Find("source bar").GetComponent<source_bar_script>().totalResistance = +outResistance;

            // calcuate current node voltage through votlage drop and last node
            float previousRow = collision.gameObject.transform.parent.GetComponentInChildren<wire_end1_script>().contactVoltage;
            rowVoltage = previousRow - voltageDrop;
            string rowVolt = "rowVolt = " + previousRow + " - " + voltageDrop;
            Debug.Log(rowVolt);

            //consider row charged
            gameObject.tag = "charged board row";
            Debug.Log(gameObject.transform.name + "is now charged to " + rowVoltage + " volts");
            Debug.Log("Previous node had " + previousRow);
            Debug.Log("total resistance is : " + transform.parent.Find("source bar").GetComponent<source_bar_script>().totalResistance);

        }

    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        inTrigger = false;
        rowVoltage = 0;
    }
    

}



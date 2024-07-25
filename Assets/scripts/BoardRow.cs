using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; // necessary for text to work
using UnityEngine;
using Unity.VisualScripting;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Reflection;
using TMPro;
using System.Security.Cryptography;
using UnityEngine.Windows.WebCam;
using System.Numerics;
using System;

public class BoardRow : MonoBehaviour
{
    public WireEnd1 wireEnd1_script;
    public WireEnd2 wireEnd2_script;


    public float simplifiedResistance = 0;
    public float voltage = 0;
    public Text voltageText; // Reference to the Text component on the Canvas
    public void Start()
    {
        // Find the Text component within breadboard info
        voltageText = transform.Find("Breadboard info").GetComponentInChildren<Text>();
    }
    public void OnTriggerStay(Collider collision)
    {
        
            
        Debug.Log(gameObject.transform.name + " touched was touched by " + collision.transform.name);

        //check if we just touched a wire
        Transform parentTransform = collision.transform.parent;
        if (parentTransform.name == "wire")
        {
            //Debug.Log("parent name is " + parentTransform.name);*/

            if (collision.name == "wire end 1" && collision.gameObject.tag == "wire output")
            {
                wireEnd1_script = collision.GetComponent<WireEnd1>();

                Debug.Log(gameObject.transform.name + "touched wire end 1");

                if (wireEnd1_script.allowFlow == true)
                {

                    float detectedOutput = wireEnd1_script.outputVoltage;
                    adoptWireVoltage(detectedOutput);
                }
            }
            else if (collision.name == "wire end 2" && collision.gameObject.tag == "wire output")
            {

                wireEnd2_script = collision.GetComponent<WireEnd2>();

                Debug.Log(gameObject.transform.name + "touched wire end 2");

                if (wireEnd2_script.allowFlow == true)
                {

                    float detectedOutput = wireEnd2_script.outputVoltage;
                    adoptWireVoltage(detectedOutput);
                }

            }
            else
            {
                Debug.Log("wire ends not recognized");
            }
        }



        bool wireOutputPresent = false;
        //save the entire component list of the collided object to varable "components"
        Collider[] colliders = collision.gameObject.GetComponents<Collider>() ;

        //check each component to see if there are any scripts with the variable "outputVoltage" & save under new name detectedOutput
        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag ("wire output"))
            {
                wireOutputPresent = true;
            }
        }

        if (wireOutputPresent == false)
        {
            Debug.Log("breadbaord recogninzes wire exit");
            voltage = 0;
            gameObject.transform.tag = "Untagged";
            breadboardCanvas = transform.Find("Breadboard info").GetComponent<Canvas>();
            numberText = breadboardCanvas.GetComponentInChildren<Text>();
            numberText.text = "0";
        }
        









        /* this note was meant to try and read the values of the wire we are touching, and save them dynamically during the game using the refelctions technique
        //save the entire component list of the collided object to varable "components"
        Component[] components = collision.gameObject.GetComponents<Component>();

        //check each component to see if there are any scripts with the variable "outputVoltage" & save under new name detectedOutput
        foreach (Component comp in components)
        {
            //Debug.Log("one pass for breadboard detection");
            FieldInfo detectedOutput = comp.GetType().GetField("outputVoltage");
            FieldInfo allowFlow = comp.GetType().GetField("allowFlow");
            //Debug.Log("this pass read: "+(float)detectedOutput.GetValue(comp));

            //if there is a voltage to be read, attempt to change the board voltage to match the detected voltage
            if (detectedOutput != null && allowFlow != null && allowFlow != false)   <------ allow flow is now considered a FieldInfo type data, it is not boolean and would have to be chnaged to boolean to complete check.
            {

                    adoptWireVoltage((float)detectedOutput.GetValue(comp));


            }
            else
            {
                //Debug.Log("null check failed");
            }
        }*/


    }
    public void OnTriggerEnter(Collider collision)
    {
        Transform parentTransform = collision.transform.parent;
        Debug.Log("parent name is " + parentTransform.name);


        if (parentTransform.name == "resistor" | parentTransform.name == "resistor(Clone)")
        {
            Debug.Log(gameObject.transform.name + "touched a resistor");
            Component[] components = collision.gameObject.GetComponents<Component>();


            if(collision.gameObject.tag == "resistor output") 
            {
                //check each component to see if there are any scripts with the variable "simplifiedResistance" & save under new name resisantcePassing
                foreach (Component comp in components)
                {

                    FieldInfo resistancePassing = comp.GetType().GetField("simplifiedResistance");
                    //Debug.Log("this pass read: "+(float)detectedOutput.GetValue(comp));

                    //if there is a voltage to be read, attempt to change the board voltage to match the detected voltage
                    if (resistancePassing != null)
                    {
                        if (resistancePassing.FieldType == typeof(float))
                        {
                            simplifiedResistance = (float)resistancePassing.GetValue(comp);
                        }

                    }
                }
            }
        }
    }
    
    public Canvas breadboardCanvas;
    private Text numberText;
    public void adoptWireVoltage(float detectedOutput)
    {
        voltage = detectedOutput;
        gameObject.transform.tag = "source";
        breadboardCanvas = transform.Find("Breadboard info").GetComponent<Canvas>();
        numberText = breadboardCanvas.GetComponentInChildren<Text>();
        numberText.text = voltage.ToString();
    }
    public void OnTriggerExit(Collider collision)
    {
        Transform parentTransform = collision.transform.parent;
        if (parentTransform.name == "wire" | parentTransform.name == "wire(Clone)")
        {
            Debug.Log("breadbaord recogninzes wire exit");
            voltage = 0;
            gameObject.transform.tag = "Untagged";
            breadboardCanvas = transform.Find("Breadboard info").GetComponent<Canvas>();
            numberText = breadboardCanvas.GetComponentInChildren<Text>();
            numberText.text = "0";
        }

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI; // necessary for text to work
using UnityEngine;
using Unity.VisualScripting;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Reflection;
using TMPro;
using System.Security.Cryptography;

public class BoardRow : MonoBehaviour
{
    // Start is called before the first frame update
    public float voltage = 0;
    public Text voltageText; // Reference to the Text component on the Canvas
    public void Start()
    {
        // Find the Text component within breadboard info
        voltageText = transform.Find("Breadboard info").GetComponentInChildren<Text>();
    }
    public  void OnTriggerStay(Collider collision)
    {       
        

        if (collision.gameObject.tag == "wire output")
        {
            //save the entire component list of the collided object to varable "components"
            Component[] components = collision.gameObject.GetComponents<Component>();

            //check each component to see if there are any scripts with the variable "outputVoltage" & save under new name detectedOutput
            foreach (Component comp in components)
            {
                Debug.Log("one pass for breadboard detection");
                FieldInfo detectedOutput = comp.GetType().GetField("outputVoltage");
                //Debug.Log("this pass read: "+(float)detectedOutput.GetValue(comp));

                //if there is a voltage to be read, attempt to change the board voltage to match the detected voltage
                if (detectedOutput != null )
                {
                    if (detectedOutput.FieldType == typeof(float))
                    {
                        adoptWireVoltage((float)detectedOutput.GetValue(comp));
                    }
                    else
                    {
                        Debug.Log("type check failed");
                    }
                }
                else 
                {
                    Debug.Log("null check failed");
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
        if (collision.gameObject.tag == "wire output")
        {
            voltage = 0;
            gameObject.transform.tag = "Untagged";
            breadboardCanvas = transform.Find("Breadboard info").GetComponent<Canvas>();
            numberText = breadboardCanvas.GetComponentInChildren<Text>();
            numberText.text = "0";
        }

    }
}

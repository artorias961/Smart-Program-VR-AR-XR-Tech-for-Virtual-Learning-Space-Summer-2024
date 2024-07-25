using System.Collections;
using System.Collections.Generic;
using System.Reflection;        //genuinely necessary for the refelection technique (getType and getField) 
using UnityEngine;

public class WireEnd2 : MonoBehaviour
{
    public WireLogic wireLogicScript;

    public bool sourceTouch = false;
    public bool allowFlow = false;


    public Color collisionColor = Color.red; // Color to change to upon collision
    private Color originalColor; // Original color of the object's material
    private Renderer rend; // Reference to the Renderer component

    public float contactVoltage = 0;
    public float outputVoltage = 0;

    string nameTouch;

    void Start()
    {
        // Get the Renderer component attached to this GameObject
        rend = GetComponent<Renderer>();

        // Save the original color of the object's material
        originalColor = rend.material.color;
    }

    void OnTriggerStay(Collider collision)
    {
        //ignore constant contact with wire body
        if (collision.tag != "component")
        {
            //recognize if the row being touched is already charged

            if (collision.tag == "source")
            {

                sourceTouch = true;
                nameTouch = collision.gameObject.name;


                //save the entire component list of the collided object to varable "components"
                Component[] components = collision.gameObject.GetComponents<Component>();
                //check each component to see if there are any scripts with the variable "voltage" & save under new name voltageField
                foreach (Component comp in components)
                {
                    //Debug.Log("one pass for wire check");
                    FieldInfo voltageField = comp.GetType().GetField("voltage");

                    //if there is a voltage to be read, consider the wire as now carrying or acknowledging that a voltage exists.
                    if (voltageField != null && voltageField.FieldType == typeof(float))
                    {
                        // If a 'voltage' field of type float is found, get its value
                        contactVoltage = (float)voltageField.GetValue(comp);

                        //the source it touches could be providing 0 volts
                        if (contactVoltage == 0)
                        {
                            wireLogicScript = GetComponentInParent<WireLogic>();
                            wireLogicScript.wire_reset();
                        }
                    }
                }
                //Debug.Log("Detected voltage: " + contactVoltage);

                // Change the color of the object upon collision
                rend.material.color = collisionColor;
            }
        }
    }

    void OnTriggerExit(Collider collision)
    {
        //recognize if the object we are leaving is a source
        Transform parentTransform = collision.transform.parent;

        if (parentTransform != null &&  parentTransform.name == nameTouch)
        {
            // Restore the original color when the collision ends
            rend.material.color = originalColor;
            //reset contact voltage
            contactVoltage = 0;
            wireLogicScript = GetComponentInParent<WireLogic>();
            wireLogicScript.wire_reset();
            sourceTouch = false;
        }

    }
}


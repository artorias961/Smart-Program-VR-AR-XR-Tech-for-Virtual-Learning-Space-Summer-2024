using System.Collections;
using System.Collections.Generic;
using System.Reflection;        //genuinely necessary for the refelection technique (getType and getField) 
using UnityEngine;

public class WireEnd2 : MonoBehaviour
{
    public Color collisionColor = Color.red; // Color to change to upon collision
    private Color originalColor; // Original color of the object's material
    private Renderer rend; // Reference to the Renderer component

    public float contactVoltage = 0;
    public float outputVoltage = 0;
    void Start()
    {
        // Get the Renderer component attached to this GameObject
        rend = GetComponent<Renderer>();

        // Save the original color of the object's material
        originalColor = rend.material.color;
    }

    void OnTriggerEnter(Collider collision)
    {
        //will be in constant contact with wire body
        if (collision.tag != "component")
        {
            //dont treat source bar the same as other rows
            if (collision.tag == "source")
            {

                //save the entire component list of the collided object to varable "components"
                Component[] components = collision.gameObject.GetComponents<Component>();
                //check each component to see if there are any scripts with the variable "voltage" & save under new name voltageField
                foreach (Component comp in components)
                {
                    FieldInfo voltageField = comp.GetType().GetField("voltage");

                    //if there is a voltage to be read, consider the wire as now carrying or acknowledging that a voltage exists.
                    if (voltageField != null && voltageField.FieldType == typeof(float))
                    {
                        // If a 'voltage' field of type float is found, get its value
                        contactVoltage = (float)voltageField.GetValue(comp);
                    }
                }
                Debug.Log("Detected voltage: " + contactVoltage);

                // Change the color of the object upon collision
                rend.material.color = collisionColor;
            }
        }
    }

    void OnTriggerExit(Collider collision)
    {
        // Restore the original color when the collision ends
        rend.material.color = originalColor;
        contactVoltage = 0;
        gameObject.tag = "Untagged";

    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wire_end2_script : MonoBehaviour
{
    public float contactVoltage = 0;
    // we will be taking information from an outside script of a game object
    // with type "breaboard_row_script"

    public breaboard_row_script breadboardRowScript;
    public source_bar_script sourceBarScript;
    public bool sourceTouch = false;
    public bool chargeTouch = false;
    public float outputVoltage { get; set; } = 0;
    public float resistance { get; set; } = 0;


    //check to see if wire is touching anything
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //decalre what it is touching
        string objectName = collision.gameObject.name;
        //Debug.Log("wire end 2 Touched " + objectName);

        //check the script of the object being touched to see if it is a breaboard row or a source bar
        if (collision.gameObject.CompareTag("source"))
        {
            contactVoltage = collision.gameObject.GetComponent<source_bar_script>().voltage;
            Debug.Log("wire end 2 touching source of " + contactVoltage + "volts");
            sourceTouch = true;
        }
        if (collision.gameObject.CompareTag("charged board row"))
        {
            contactVoltage = collision.gameObject.GetComponent<breaboard_row_script>().rowVoltage;
            Debug.Log("wire end 2 touching bar with " + contactVoltage + "volts");
            chargeTouch = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        contactVoltage = 0;
        sourceTouch = false;
        chargeTouch = false;
    }
}
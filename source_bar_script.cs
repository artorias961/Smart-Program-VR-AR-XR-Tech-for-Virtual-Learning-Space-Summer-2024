using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class source_bar_script : MonoBehaviour
{
    
    public float voltage = 5;
    public float totalResistance = 0;
    public float current = 0;


        public void RecalculateCurrent(float totalResistance)
    {
        //Debug.Log("total resitance within function is "+ totalResistance);
        current = voltage / totalResistance;
        //Debug.Log("calculated current is " + current);
    }
}

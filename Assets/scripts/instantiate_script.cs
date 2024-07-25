using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiate_script : MonoBehaviour
{
    public GameObject wire;
    public GameObject resistor;
    public GameObject breadboard;
    // Start is called before the first frame update
    void Start() 
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 breadboardPosition = breadboard.transform.position;
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Vector3 spawnPosition = breadboardPosition + new Vector3(-70, 20,46); // Specify the spawn position
            Quaternion spawnRotation= Quaternion.Euler(new Vector3(0, 0, 90));
            Instantiate(wire, spawnPosition, spawnRotation);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Vector3 spawnPosition = breadboardPosition + new Vector3(-70, 20, 46); // Specify the spawn position
            Quaternion spawnRotation = Quaternion.Euler(new Vector3(0, 0, 90));
            Instantiate(resistor, spawnPosition, spawnRotation);
        }

    }
}

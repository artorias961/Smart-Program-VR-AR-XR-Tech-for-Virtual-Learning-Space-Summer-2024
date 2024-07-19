using System.IO.Ports;
using UnityEngine;

public class SerialCommunication : MonoBehaviour
{
    private SerialPort serialPort;

    void Start()
    {
        // This runs once when the script is loaded
        // Replace "COM3" with your actual COM port <-------------- VERY IMPORTANT
        serialPort = new SerialPort("COM4", 115200);
        serialPort.Open();
        Debug.Log("Serial port opened.");
    }

    void Update()// note, use a different method than UPDATE()
    {
        // This runs once per frame
        if (serialPort.IsOpen)
        {
            try
            {
                // Check if there's incoming data
                if (serialPort.BytesToRead > 0)
                {
                    string incomingData = serialPort.ReadLine();
                    Debug.Log("Received from ESP32: " + incomingData);
                }

                // Send data to ESP32 if the space key is pressed
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    serialPort.WriteLine("Hello from Unity!");
                    Debug.Log("Sent to ESP32: Hello from Unity!");
                }
            }
            catch (System.Exception e)
            {
                Debug.LogWarning("Serial communication error: " + e.Message);
            }
        }
    }

    void OnApplicationQuit()
    {
        // This runs once when the application is quitting
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
            Debug.Log("Serial port closed.");
        }
    }
}

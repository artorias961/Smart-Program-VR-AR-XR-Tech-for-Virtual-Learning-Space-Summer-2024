// #include "BluetoothSerial.h"

// // Defining a static varaible for the serial port
// #define bluetoothModuleSerial Serial1

// // Creating an object for Bluetooth (serial port, verbose mode)
// BluetoothSerial blueSerial(bluetoothModuleSerial, true);

// void setup() {
//   // put your setup code here, to run once:
  
//   // Bluetooth buad rate and serial baud rate 
//   bluetoothModuleSerial.begin(9600);
//   Serial.begin(9600);

//   // Print the status on terminal
//   Serial.println("Setup Complete")
// }


// void loop() {
//   // Read anything if anything is sent
//   blueSerial.readSerial();

//   // Send a message with the incrementing counter
//   String message = "Hello my name is arty, " + String(counter++);
//   bluetoothModuleSerial.println(message);
//   Serial.println("Sent: " + message);

//   // Create a 1 second delay (in Mili Sec)
//   delay(1000);

// }


// /*
//    Hello_World.ino
//    Henry Abrahamsen
//    8/12/23
//    Simple code using the basic features of Bluetooth Serial
//    Details available at https://docs.henhen1227.com/
// */

// #include <BluetoothSerial.h>

// #define bluetoothModuleSerial Serial1

// // Create a BluetoothSerial object
// // Serial port that the bluetooth module is connected
// // Verbose mode: true
// BluetoothSerial blueSerial(bluetoothModuleSerial, true);

// void setup() {
//   // Start communication with bluetooth device
//   bluetoothModuleSerial.begin(9600);
//   Serial.begin(9600);

//   Serial.println("Setup Complete");
// }


// void loop() {
//   blueSerial.readSerial();

//   // If the button with id `B0`
//   if (blueSerial.isButtonPressed(0)) {
//     Serial.println("The button `B0` has been pressed!");

//     // Send alert to the BluetoothSerial Connect App
//     blueSerial.sendAlert("Hello from the Arduino");
//   }

//   // Check if the Joystick with id `J0` has updated
//   if (blueSerial.isJoystickUpdated(0)) {
      
//     // Get the Joystick object
//     BluetoothSerialJoystick joystick = blueSerial.getJoystick(0);

//     // Get the Joysticks rotation and magnitude
//     String rotation = String(joystick.getRotationDeg(), 0);
//     String magnitude = String(joystick.getMagnitude() * 100, 0); // As a percent %

//     /// String(a, 0) is the double a with 0 trailing zeros as a String

//     // Update the display inside the BluetoothSerial Connect App
//     blueSerial.setDisplay("Joystick: " + rotation + "deg, " + magnitude + "%", 0);
//   }
// }



#define LED_PIN 13
// Creating a variable for increment
int counter = 0;

// Setup function runs once when the ESP32 starts
void setup() {
  // Initialize hardware serial communication at 115200 baud rate
  Serial.begin(115200);
   while (!Serial) {
    ; // Wait for serial port to connect
  }
  
  // Print a message to the serial monitor
  Serial.println("ESP32 is ready to communicate with Unity");

  // Initialize the LED pin as an output
  pinMode(LED_PIN, OUTPUT);
}

void loop() {
  // Check if data is available on the hardware serial
  if (Serial.available()) {
    // Read the incoming serial data
    String message = Serial.readString();
    // Print the received message to the serial monitor
    Serial.println("Message from Unity: " + message);
  }
  
  // Write a test message to the serial monitor at regular intervals
  Serial.println("ESP32 is ready to communicate " + String(counter));
  counter++;

  // Turn the LED on
  digitalWrite(LED_PIN, HIGH);
  // Wait for half a second
  delay(500);
  // Turn the LED off
  digitalWrite(LED_PIN, LOW);
  // Wait for half a second
  delay(500);
}
